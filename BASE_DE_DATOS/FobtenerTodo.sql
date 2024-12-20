-- FUNCTION: schemasye.obtener_todo_enfermedad()

-- DROP FUNCTION IF EXISTS schemasye.obtener_todo_enfermedad();

CREATE OR REPLACE FUNCTION schemasye.obtener_todo_enfermedad(
	)
    RETURNS TABLE(id_enfermedad integer, nombre character varying, descripcion character varying, fecha_registro date, fecha_inicio date, estado boolean, fecha_actualizacion date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY SELECT * FROM schemasye.tc_enfermedad_cronica ORDER BY id_enfermedad ASC;
END;
$BODY$;

ALTER FUNCTION schemasye.obtener_todo_enfermedad()
    OWNER TO postgres;
