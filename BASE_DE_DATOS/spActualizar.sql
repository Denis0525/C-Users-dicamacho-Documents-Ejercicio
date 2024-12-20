-- PROCEDURE: schemasye.spactualiza_enfermedad(integer, character varying, character varying, boolean)

-- DROP PROCEDURE IF EXISTS schemasye.spactualiza_enfermedad(integer, character varying, character varying, boolean);

CREATE OR REPLACE PROCEDURE schemasye.spactualiza_enfermedad(
	IN idenfermedad integer,
	IN pnombre character varying,
	IN pdescripcion character varying,
	IN pestado boolean)
LANGUAGE 'plpgsql'
AS $BODY$
begin
update schemasye.tc_enfermedad_cronica
set nombre=pnombre, descripcion=pdescripcion,fecha_registro=current_date,fecha_inicio=current_date,estado=pestado,fecha_actualizacion=current_date
where id_enf_cronica=idenfermedad;
end;
$BODY$;
ALTER PROCEDURE schemasye.spactualiza_enfermedad(integer, character varying, character varying, boolean)
    OWNER TO postgres;
