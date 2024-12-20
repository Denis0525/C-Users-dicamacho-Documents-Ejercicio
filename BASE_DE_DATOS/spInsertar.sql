-- PROCEDURE: schemasye.spinsertar_enfermedad(character varying, character varying, boolean)

-- DROP PROCEDURE IF EXISTS schemasye.spinsertar_enfermedad(character varying, character varying, boolean);

CREATE OR REPLACE PROCEDURE schemasye.spinsertar_enfermedad(
	IN nombre character varying,
	IN descripcion character varying,
	IN estado boolean)
LANGUAGE 'plpgsql'
AS $BODY$
begin
insert into schemasye.tc_enfermedad_cronica(
nombre,descripcion,fecha_registro,fecha_inicio,estado,fecha_actualizacion)
values(nombre,descripcion,current_date,current_date,estado,current_date);
end;
$BODY$;
ALTER PROCEDURE schemasye.spinsertar_enfermedad(character varying, character varying, boolean)
    OWNER TO postgres;
