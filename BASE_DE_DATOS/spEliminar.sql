-- PROCEDURE: schemasye.speliminar_enfermedad(integer)

-- DROP PROCEDURE IF EXISTS schemasye.speliminar_enfermedad(integer);

CREATE OR REPLACE PROCEDURE schemasye.speliminar_enfermedad(
	IN id integer)
LANGUAGE 'plpgsql'
AS $BODY$
begin
	delete from schemasye.tc_enfermedad_cronica where id_enf_cronica=id;
end;
$BODY$;
ALTER PROCEDURE schemasye.speliminar_enfermedad(integer)
    OWNER TO postgres;
