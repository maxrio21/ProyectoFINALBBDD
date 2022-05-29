/*	---------------------------------------------
*			 1. FUNCIONES SIN TRIGGER
*/	---------------------------------------------

/*
Funcion 1
Obtiene un listado de nombres de entidades bancarias de la base de datos
que empiezen por el nombre indicado en el parametro.
*/
--DROP FUNCTION IF EXISTS obtenerCuentaPorIban(varchar) CASCADE;
--SELECT obtenerEntidadesPorLetra('I');

CREATE OR REPLACE FUNCTION obtenerEntidadesPorLetra(letra VARCHAR)
RETURNS VOID AS $$
	DECLARE
	
	op_rec RECORD;
	op_cur CURSOR(letra VARCHAR)
		FOR
		SELECT *
		FROM entidad_bancaria
		WHERE nombre LIKE (CONCAT(letra,'%'));
	BEGIN
		OPEN op_cur(letra);	
			LOOP
			
				FETCH op_cur INTO op_rec;
				EXIT WHEN NOT FOUND;
				
				RAISE INFO '%',op_rec.nombre;

			END LOOP;
		CLOSE op_cur;		
	END;
$$ LANGUAGE plpgsql;

/*
Funcion 2
Obtiene una cuenta bancaria a traves de su iban, esto lo usaremos para 
las interfaces en concreto para realizar una transaccion a otra cuenta.
*/
--SELECT obtenerCuentaPorIban('ES51005001491110000000005');
--DROP FUNCTION obtenerCuentaPorIban(recepIBAN varchar);

CREATE OR REPLACE FUNCTION obtenerCuentaPorIban(recepIBAN varchar)
RETURNS VARCHAR AS $$
	DECLARE
	cuenta VARCHAR :=
	(
		
		SELECT id_cuenta
		FROM cuenta_bancaria
		WHERE iban = UPPER(recepIBAN)
	);
	BEGIN
		return cuenta;
	END;
$$ LANGUAGE plpgsql;
		
/*
Funcion 3
Obtiene el titular de la tarjeta asociada a la cuenta del cliente.
*/
CREATE OR REPLACE FUNCTION obtenerTitular(idCuenta int)
RETURNS VARCHAR AS $$
DECLARE
	titular VARCHAR :=
	(
		SELECT t.titular 
		FROM tarjeta t, cuenta_bancaria c 
		WHERE t.id_cuenta = c.id_cuenta AND t.id_cuenta = $1
	);
BEGIN
	RETURN titular;
END;
$$ LANGUAGE plpgsql;

/*
Funcion 4
Obtiene la entidad bancaria a la que pertenece la cuenta bancaria asociada a la tarjeta.
*/
CREATE OR REPLACE FUNCTION obtenerEntidad(idCuenta int)
RETURNS VARCHAR AS $$
DECLARE
	entidad VARCHAR :=
	(   
		SELECT e.nombre
		FROM tarjeta t, cuenta_bancaria c, entidad_bancaria e
		WHERE 
		t.id_cuenta = c.id_cuenta AND
		c.id_entidad_bancaria = e.codigo AND 
		t.id_cuenta = $1
	);
BEGIN
	RETURN entidad;
END;
$$ LANGUAGE plpgsql;

/*
Funcion 5
Obtiene el registro de los ultimos 10 movimientos por cuenta de usuario.
*/
--DROP FUNCTION verUltimasOperaciones(id_c INT) CASCADE;
--SELECT verUltimasOperaciones(1);

CREATE OR REPLACE FUNCTION verUltimasOperaciones(id_c INT)
RETURNS VOID AS $op$
	
	DECLARE
	
		c INT;
	
		op_rec RECORD;
		op_cur CURSOR(id_c INT)
		FOR
		SELECT *
		FROM realizar_operacion
		WHERE id_emisor = id_c
		ORDER BY fecha DESC
		LIMIT 10;
		
		iban_emisor TEXT;
		iban_receptor TEXT;
		
	BEGIN
	
		SELECT * INTO STRICT c
		FROM realizar_operacion
		WHERE id_emisor = id_c
		LIMIT 1;
	
		RAISE INFO 'ID | EMISOR | RECEPTOR | CANTIDAD | FECHA | TIPO';
		OPEN op_cur(id_c);	
			LOOP
			
				FETCH op_cur INTO op_rec;
				EXIT WHEN NOT FOUND;
			
				iban_emisor :=
				(
					SELECT iban
					FROM cuenta_bancaria
					WHERE id_cuenta = op_rec.id_emisor
				);
				iban_receptor :=
				(
					SELECT iban
					FROM cuenta_bancaria
					WHERE id_cuenta = op_rec.id_receptor
				);
				RAISE INFO '% % % % % %',op_rec.id_operacion,iban_emisor,iban_receptor,op_rec.cantidad,op_rec.fecha,op_rec.tipo;
				
			END LOOP;
		CLOSE op_cur;
	EXCEPTION
		WHEN NO_DATA_FOUND THEN
			RAISE EXCEPTION 'No se ha encotrado ningun cliente con el identificador %.',id_c;
	END;

$op$ LANGUAGE plpgsql;

/*	---------------------------------------------
*			 2. FUNCIONES Y TRIGGERS
*/	---------------------------------------------

/*
Trigger 2.1
Realiza un conjunto de updates y operaciones antes de insertar una operacion 
en la tabla realizar_operacion
*/
DROP FUNCTION realizarOperacion() CASCADE;

CREATE OR REPLACE FUNCTION realizarOperacion()
RETURNS TRIGGER AS $ro$
	DECLARE
	dinero_emisor DECIMAL :=
	(
		SELECT deposito
		FROM cuenta_bancaria
		WHERE id_cuenta = NEW.id_emisor
	);
	
	iban_emisor VARCHAR :=
	(
		SELECT iban
		FROM cuenta_bancaria
		WHERE id_cuenta = NEW.id_emisor
	);
	
	iban_receptor VARCHAR :=
	(
		SELECT iban
		FROM cuenta_bancaria
		WHERE id_cuenta = NEW.id_receptor
	);
	BEGIN
		RAISE INFO '%',NEW.cantidad;
		IF NEW.id_emisor = NEW.id_receptor THEN --Significa que esta realizando una operacion a su cuenta.
			--Comprueba si es una retirada o un ingreso.	
			IF NEW.cantidad < 0 THEN --En esta caso es una retirada.
					150			100
				IF NEW.cantidad > dinero_emisor	THEN --Comprueba la retirada de dinero
					RAISE EXCEPTION 'Lo sentimos pero no dispones del dinero suficiente a retirar.';
				ELSE 
				
					/*
					Retira dinero de la cuenta bancaria 
					*/
					UPDATE cuenta_bancaria
					SET deposito = deposito + NEW.cantidad
					WHERE id_cliente = NEW.id_emisor;

					RAISE INFO 'Se ha realizado una nueva operacion.';
					RAISE INFO '';
					RAISE INFO 'Se ha retirado %€ de la cuenta bancaria %',NEW.cantidad,iban_emisor;

					RETURN NEW;

				END IF;
			
			ELSE -- en este caso es un ingreso.
			
				/*
				Ingresa dinero a la cuenta bancaria 
				*/
				UPDATE cuenta_bancaria
				SET deposito = deposito + NEW.cantidad
				WHERE id_cliente = NEW.id_emisor;

				RAISE INFO 'Se ha realizado una nueva operacion.';
				RAISE INFO '';
				RAISE INFO 'Se ha ingresado %€ a la cuenta bancaria %',NEW.cantidad,iban_emisor;

				RETURN NEW;
				
			END IF;
		ELSE --Significa que esta realizando una transferencia a otra cuenta.
			IF NEW.cantidad > dinero_emisor	THEN --Comprueba la retirada de dinero
				RAISE EXCEPTION 'Lo sentimos pero no dispones del dinero suficiente a transferir.';
			ELSE 
				/*
				Retira dinero de la cuenta bancaria del emisor.
				*/
				UPDATE cuenta_bancaria
				SET deposito = deposito - NEW.cantidad
				WHERE id_cliente = NEW.id_emisor;
				
				/*
				La cuenta bancaria del receptor recibe el dinero del emisor. 
				*/
				UPDATE cuenta_bancaria
				SET deposito = deposito + NEW.cantidad
				WHERE id_cliente = NEW.id_receptor;
				
				RAISE INFO 'Se ha realizado una nueva operacion.';
				RAISE INFO '';
				RAISE INFO 'Se ha realizado una transferencia de la cuenta % a la cuenta %',iban_emisor,iban_receptor;
				RAISE INFO 'Importe transferido: %€',NEW.cantidad;

				RETURN NEW;
				
			END IF;
		END IF;
	EXCEPTION
		WHEN foreign_key_violation THEN
			RAISE EXCEPTION 'No se puede realizar la operacion por que el emisor % o receptor % no existe.',NEW.id_emisor,NEW.id_receptor;
	END;
$ro$ LANGUAGE plpgsql;

/*
--INSERT INTO realizar_operacion(id_emisor,id_receptor,cantidad,fecha,tipo)
VALUES(1,1,100000000.00,TO_CHAR(NOW(),'YYYY-MM-DD HH:MI:SS')::TIMESTAMP,'TRANSFERENCIA');
*/

CREATE TRIGGER realizarOperacionTrigger
BEFORE INSERT
ON realizar_operacion
FOR EACH ROW
EXECUTE PROCEDURE realizarOperacion();

/*
Esta función se modificará siempre que queramos
decidir el tipo de cuenta bancaria y no queramos 
usar la interfaz.
*/

CREATE OR REPLACE FUNCTION establecerTipo()
RETURNS TEXT AS $et$ 
	BEGIN
		RETURN 'CORRIENTE';
	END;
$et$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION establecerTarjeta()
RETURNS TEXT AS $ett$ 
	BEGIN
		RETURN 'CREDITO';
	END;
$ett$ LANGUAGE plpgsql;

/*	---------------------------------------------
*			 3. CADENA DE TRIGGERS
*/	---------------------------------------------

/*
Trigger 3.1
Funcion que creará un cliente nuevo
activando el trigger crearCuenta.
*/
--DROP FUNCTION IF EXISTS crearCliente(dniCliente VARCHAR(9),nombre VARCHAR(50),apellidos VARCHAR(100),telefono VARCHAR(15),domicilio VARCHAR(200),correo VARCHAR(320)) CASCADE;
--SELECT crearCliente('49370546K','Mario','Bellido Jiménez','642338860','Calpe/Alicante','mariobj1999@gmail.com');

CREATE OR REPLACE FUNCTION crearCliente
(
	dniCliente VARCHAR(9),
	nombre VARCHAR(50),
	apellidos VARCHAR(100),
	telefono VARCHAR(15),
	domicilio VARCHAR(200),
	correo VARCHAR(320)
)                                
RETURNS VOID AS $cc$
	BEGIN
		INSERT INTO CLIENTE(dni,nombre,apellidos,telefono,domicilio,correo)
		VALUES($1,$2,$3,$4,$5,$6);
		RAISE INFO 'Se ha introducido al nuevo cliente % % al sistema.',$2,$3;
	END;
$cc$ LANGUAGE plpgsql;

/*
Trigger 3.2
Funcion activada por trigger que comprobará
los datos de clientes para asgurar que 
las inserciones se realizan correctamente.
*/
--DROP FUNCTION IF EXISTS crearCuenta() CASCADE;
CREATE OR REPLACE FUNCTION comprobarDatosCliente()
RETURNS TRIGGER AS $cdc$
	BEGIN
		IF NEW.DNI IN
		(
			SELECT dni
			FROM cliente
		)
		THEN
			RAISE EXCEPTION 'El cliente con dni % ya esta registrado en nuestro sistema bancario.',NEW.dni;
		END IF;
		
		IF NEW.correo NOT LIKE '%@%' THEN
			RAISE EXCEPTION 'El formato del correo electronico introducido es erroneo o no existe.';
		END IF;
		RETURN NEW;
	END;
$cdc$ LANGUAGE plpgsql;

CREATE TRIGGER comprobarDatosClienteTrigger
BEFORE INSERT
ON cliente
FOR EACH ROW
EXECUTE PROCEDURE comprobarDatosCliente();

/*
Trigger 3.3
Funcion activada por trigger que creará una nueva cuenta bancaria
a un nuevo cliente.
*/
--DROP FUNCTION IF EXISTS crearCuenta() CASCADE;
CREATE OR REPLACE FUNCTION crearCuenta()
RETURNS TRIGGER AS $ccu$
	DECLARE
		tipo varchar = establecerTipo();
		iban varchar = 'ES5131903190680000000011';
		dni varchar = 
		(
			SELECT dni
			FROM cliente
			WHERE id_cliente = NEW.id_cliente
		);
	BEGIN
		INSERT INTO cuenta_bancaria(iban,deposito,tipo,contraseña,id_cliente,id_sucursal,id_entidad_bancaria,fecha_creacion)
		VALUES(iban,0.00,tipo,583759,NEW.id_cliente,2100,3029,TO_CHAR(NOW(),'YYYY-MM-DD')::DATE);	
		
		RAISE INFO 'Se le ha creado y asignado la cuenta de tipo % : % al cliente con DNI: %',tipo,iban,dni;
		RAISE INFO '';

		RETURN NEW;
	END;
$ccu$ LANGUAGE plpgsql;

CREATE TRIGGER crearCuentaTrigger
AFTER INSERT
ON cliente
FOR EACH ROW
EXECUTE PROCEDURE crearCuenta();

/*
Trigger 3.4
Funcion que borrará una cuenta bancaria
en caso de borrado de cliente.
*/
--DROP FUNCTION IF EXISTS borrarCuenta() CASCADE;
CREATE OR REPLACE FUNCTION borrarCuenta()
RETURNS TRIGGER AS $bc$
	DECLARE
		cliente VARCHAR :=
		(
			SELECT CONCAT(OLD.nombre,' ',OLD.apellidos)
			FROM cliente
			WHERE id_cliente = OLD.id_cliente
		);
		iban VARCHAR :=
		(SELECT iban FROM cuenta_bancaria WHERE id_cliente = OLD.id_cliente);
	BEGIN
		DELETE FROM cuenta_bancaria WHERE id_cliente = OLD.id_cliente;
		RAISE INFO 'Se ha borrado la cuenta bancaria % asociada al cliente %',iban,cliente;
		RETURN OLD;
	END;
$bc$ LANGUAGE plpgsql;

CREATE TRIGGER borrarCuentaTrigger
BEFORE DELETE
ON cliente
FOR EACH ROW
EXECUTE PROCEDURE borrarCuenta();


/*
Trigger 3.5
Crea una tarjeta de credito seguido de que
se haya creado la cuenta bancaria previa a 
vincular.
*/
--DROP FUNCTION IF EXISTS crearTarjeta() CASCADE;
CREATE OR REPLACE FUNCTION crearTarjeta()
RETURNS TRIGGER AS $ct$
	DECLARE
		titu VARCHAR :=
		(
			SELECT CONCAT(c.nombre,' ',c.apellidos)
			FROM cliente c
			WHERE NEW.id_cliente = c.id_cliente
		);
		newCVC NUMERIC := (SELECT floor(random() * 999 + 1)::int);
		venciDate DATE := CONCAT((TO_CHAR(NOW(),'YYYY')::INT + 3),'-',(TO_CHAR(NOW(),'MM-DD')))::DATE;
		newPass NUMERIC := (SELECT floor(random() * 9999 + 1)::int);
		tipoTarjeta  VARCHAR(20):= establecerTarjeta();
	BEGIN
		IF NEW.tipo = 'CORRIENTE' THEN
			INSERT INTO cuenta_corriente(id_cuenta)
			VALUES(NEW.id_cuenta);	
			
			INSERT INTO tarjeta(titular,cvv,vencimiento,id_cliente,id_cuenta,contraseña,tipo)
			VALUES(titu,newCVC,venciDate,NEW.id_cliente,NEW.id_cuenta,newPass,tipoTarjeta);
			
			RAISE INFO 'Nueva tarjeta creada y vinculada';
			RAISE INFO 'Titular           | %',titu;
			RAISE INFO 'Cuenta vinculada  | %',NEW.iban;
			RAISE INFO 'Vencimiento       | %',venciDate;
			RAISE INFO 'Tipo              | %',tipoTarjeta;
			RAISE INFO 'Contraseña        | %',newPass;
			RAISE INFO '';
			
			RETURN NEW;
			
		ELSE 
			INSERT INTO cuenta_ahorro(id_cuenta)
			VALUES(NEW.id_cuenta);
			RAISE INFO 'No se ha creado ninguna tarjeta puesto que la cuenta bancaria afectada es de tipo ahorro.';

			RETURN NEW;
		END IF;	
	END;
$ct$ LANGUAGE plpgsql;

CREATE TRIGGER crearTarjetaTrigger
AFTER INSERT
ON cuenta_bancaria
FOR EACH ROW
EXECUTE PROCEDURE crearTarjeta();

/*
Trigger 3.6
Actualizará una tarjeta incluso borrandola en caso de 
cambiar el tipo de esta.
*/
--DROP FUNCTION IF EXISTS actualizarTarjeta() CASCADE;
CREATE OR REPLACE FUNCTION actualizarTarjeta()
RETURNS TRIGGER AS $art$
	DECLARE
		titu VARCHAR :=
		(
			SELECT CONCAT(c.nombre,' ',c.apellidos)
			FROM cliente c
			WHERE c.id_cliente = NEW.id_cliente
		);

		newCVC NUMERIC := (SELECT floor(random() * 999 + 1)::int);
		venciDate DATE := CONCAT((TO_CHAR(NOW(),'YYYY')::INT + 3),'-',(TO_CHAR(NOW(),'MM-DD')))::DATE;
		newPass NUMERIC := (SELECT floor(random() * 9999 + 1)::int);
		tipoTarjeta VARCHAR := 'CREDITO';
		
	BEGIN 
		
		IF OLD.tipo = 'CORRIENTE' AND NEW.tipo = 'AHORRO' THEN
			DELETE FROM tarjeta WHERE id_cuenta = NEW.id_cuenta;
			
			RAISE INFO 'Se ha cambiado el tipo de cuenta de CORRIENTE a AHORRO';
			RAISE INFO 'IMPORTANTE!, Se ha borrado la tarjeta de credito dado que la cuenta no es de tipo CORRIENTE.';
			
			RETURN NEW;
		
		END IF;
		
		IF OLD.tipo = 'AHORRO' AND NEW.tipo = 'CORRIENTE' THEN
			INSERT INTO tarjeta(titular,cvv,vencimiento,id_cliente,id_cuenta,contraseña,tipo)
			VALUES(titu,newCVC,venciDate,NEW.id_cliente,NEW.id_cuenta,newPass,tipoTarjeta);
			
			RAISE INFO 'Se ha cambiado el tipo de tarjeta de DEBITO a CREDITO';
			
			RETURN NEW;
		END IF;
		
		RETURN NEW;
		
	END;
$art$ LANGUAGE plpgsql;

CREATE TRIGGER actualizarTarjetaTrigger
BEFORE UPDATE
ON cuenta_bancaria
FOR EACH ROW
EXECUTE PROCEDURE actualizarTarjeta();

/*
Trigger 3.7
Funcion que borrará una tarjeta en caso
de borrado de cuenta bancaria.
*/
--DROP FUNCTION IF EXISTS borrarTarjeta() CASCADE;
CREATE OR REPLACE FUNCTION borrarTarjeta()
RETURNS TRIGGER AS $bt$
	BEGIN
		DELETE FROM tarjeta
		WHERE id_cliente = OLD.id_cliente;
		
		RAISE INFO 'Se ha eliminado la tarjeta correctamente.';
		
		RETURN OLD;
		
		SELECT *
		FROM tarjeta;
		
	END;
$bt$ LANGUAGE plpgsql;

CREATE TRIGGER borrarTarjetaTrigger
BEFORE DELETE
ON cuenta_bancaria
FOR EACH ROW
EXECUTE PROCEDURE borrarTarjeta();

/*
Trigger 3.8
Crea un respaldo de una tarjeta con
más información detallada.
*/
--DROP FUNCTION IF EXISTS crearTarjetaRespaldo() CASCADE;
CREATE OR REPLACE FUNCTION crearTarjetaRespaldo()
RETURNS TRIGGER AS $ct$
	DECLARE
		sucursal VARCHAR := 
		(
			SELECT id_sucursal
			FROM cuenta_bancaria
			WHERE id_cuenta = NEW.id_cuenta		
		);
		entidad VARCHAR := 
		(
			SELECT id_sucursal
			FROM cuenta_bancaria
			WHERE id_cuenta = NEW.id_cuenta		
		);
	BEGIN
	
		IF NEW.tipo = 'CREDITO' THEN
			INSERT INTO credito(id_tarjeta)
			VALUES(NEW.id_tarjeta);
		ELSE
			INSERT INTO debito(id_tarjeta)
			VALUES(NEW.id_tarjeta);		
		END IF;
	
		INSERT INTO crear_tarjeta(id_cliente,id_cc,id_sucursal,id_entidad_bancaria,contraseña,id_tarjeta,fecha_creacion)
		VALUES(NEW.id_cliente,NEW.id_cuenta,sucursal,entidad,NEW.contraseña,NEW.id_tarjeta,TO_CHAR(NOW(),'YYYY-MM-DD')::DATE);
		RAISE INFO 'Se ha guardado un respaldo de la tarjeta con información más detallada con éxito!';
		RAISE INFO '';
		RETURN NEW;
	EXCEPTION
		WHEN foreign_key_violation THEN
			RAISE EXCEPTION 'No se ha podido crear el respaldo por que el cliente o la cuenta corriente no existe.';
	END;
$ct$ LANGUAGE plpgsql;

CREATE TRIGGER crearTarjetaRespaldoTrigger
AFTER INSERT
ON tarjeta
FOR EACH ROW
EXECUTE PROCEDURE crearTarjetaRespaldo();

/*
Trigger 3.9
Actualizará el respaldo de una tarjeta en
caso cambiar los datos.
*/
--DROP FUNCTION IF EXISTS actualizarRespaldoTarjeta() CASCADE;
CREATE OR REPLACE FUNCTION actualizarRespaldoTarjeta()
RETURNS TRIGGER AS $art$
	BEGIN
		IF OLD.tipo = 'CREDITO' AND NEW.tipo = 'DEBITO' THEN
			DELETE FROM credito WHERE id_tarjeta = NEW.id_tarjeta;
			RAISE INFO 'Se ha cambiado el tipo de tarjeta de CREDITO a DEBITO';
			INSERT INTO debito(id_tarjeta)
			VALUES(NEW.id_tarjeta);
			
		END IF;
		
		IF OLD.tipo = 'DEBITO' AND NEW.tipo = 'CREDITO' THEN
			DELETE FROM debito WHERE id_tarjeta = NEW.id_tarjeta;
			RAISE INFO 'Se ha cambiado el tipo de tarjeta de DEBITO a CREDITO';
			INSERT INTO credito(id_tarjeta)
			VALUES(NEW.id_tarjeta);
		END IF;
	
		UPDATE crear_tarjeta
		SET
		contraseña = NEW.contraseña
		WHERE id_cliente = NEW.id_cliente;
		RAISE INFO 'Se ha actualizado el respaldo con éxito.';
		RETURN NEW;
	END;
$art$ LANGUAGE plpgsql;

/*
UPDATE tarjeta 
SET tipo = 'CREDITO'
WHERE id_tarjeta = 12;
*/
CREATE TRIGGER actualizarRespaldoTarjetaTrigger
BEFORE UPDATE
ON tarjeta
FOR EACH ROW
EXECUTE PROCEDURE actualizarRespaldoTarjeta();

/*
Trigger 3.10
Borrará el respaldo de una tarjeta en
caso de su borrado.
*/
--DROP FUNCTION IF EXISTS borrarRespaldoTarjeta() CASCADE;

CREATE OR REPLACE FUNCTION borrarRespaldoTarjeta()
RETURNS TRIGGER AS $brt$
	BEGIN
		DELETE FROM crear_tarjeta
		WHERE id_cliente = OLD.id_cliente;
		
		RAISE INFO 'Se ha eliminado el respaldo de la tarjeta correctamente';
		
		RETURN OLD;
	END;
$brt$ LANGUAGE plpgsql;

CREATE TRIGGER borrarRespaldoTarjetaTrigger
BEFORE DELETE
ON tarjeta
FOR EACH ROW
EXECUTE PROCEDURE borrarRespaldoTarjeta();

/*	---------------------------------------------
*			 		4. VISTAS
*/	---------------------------------------------

/*
Vista 1
Obtiene las operaciones realizados por los clientes, la cantidad de dinero invertido
*/
--SELECT * FROM operacionesClientes
--DROP VIEW operacionesClientes

CREATE OR REPLACE VIEW operacionesClientes
AS
SELECT r.id_operacion,CONCAT(c.nombre,' ',c.apellidos) AS cliente,cb.iban,r.cantidad, r.fecha, r.tipo 
FROM cuenta_bancaria cb, realizar_operacion r, cliente c
WHERE 
r.id_emisor = cb.id_cuenta AND
c.id_cliente = cb.id_cliente;

/*
Vista 2
Obtiene la cantidad de trabajadores que hay asociado a un departamento.
*/
--SELECT * FROM personasPorOficina
--DROP VIEW personasPorOficina
CREATE OR REPLACE VIEW personasPorOficina
AS
SELECT o.seccion, COUNT(*) AS personal
FROM trabajador t,oficina o
WHERE t.id_oficina = o.id_oficina
GROUP BY(o.seccion)



