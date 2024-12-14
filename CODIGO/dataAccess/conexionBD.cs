using Npgsql;
using System.Data;
using ejercicio1.Models;

namespace ejercicio1.dataAccess
{    
        public class conexionBD
        {
            private NpgsqlConnection? con;

            private void conexion()
            {
                //string strConexion = "Provider=PostgreSQL OLE DB Provider;Data Source=127.0.0.1;location=Prueba_sye;User ID=postgres;password=;timeout=1000;";
                //string strConexion = "Provider=PostgreSQL OLE DB Provider; Server = localhost; Port = 5432; Database = Prueba_sye; Uid = postgres; Pwd = Rebeca";
                String strConexion = "server=localhost;port=5432;user id=postgres;password=Rebeca;database=Prueba_sye;";
                con = new NpgsqlConnection(strConexion);
            }


            public List<modCatalogo> GetAll()
            {

                List<modCatalogo> listamod = new List<modCatalogo>();
                conexion();
                DataTable dt = new DataTable();
                NpgsqlCommand sqlcmd = new NpgsqlCommand("select * from schemasye.tc_enfermedad_cronica", con);
                sqlcmd.CommandType = CommandType.Text;

                try
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlcmd);
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            modCatalogo mod = new modCatalogo();
                            mod.id_enf_cronica = Convert.ToInt16(dr[0]);
                            mod.nombre = dr[1].ToString();
                            mod.descripcion = dr[2].ToString();
                            mod.fecha_registro = Convert.ToString(dr[3]);
                            mod.fecha_inicio = Convert.ToString(dr[4]);
                            mod.estado = dr[5].ToString();
                            mod.fecha_actualizacion = Convert.ToString(dr[6]);
                            listamod.Add(mod);

                        }
                    }
                }
                catch (Exception e)
                {
                    string horror = e.Message.ToString();
                    return listamod;
                }
                finally
                {

                    if (con != null) { con.Close(); }
                }



                return listamod;
            }
            public List<modCatalogo> GetByID(int Id)
            {

                List<modCatalogo> listamod = new List<modCatalogo>();
                conexion();
                DataTable dt = new DataTable();
                NpgsqlCommand sqlcmd = new NpgsqlCommand("select * from schemasye.tc_enfermedad_cronica where id_enf_cronica=" + Id, con);
                sqlcmd.CommandType = CommandType.Text;


                try
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlcmd);
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            modCatalogo mod = new modCatalogo();
                            mod.id_enf_cronica = Convert.ToInt16(dr[0]);
                            mod.nombre = dr[1].ToString();
                            mod.descripcion = dr[2].ToString();
                            mod.fecha_registro = Convert.ToString(dr[3]);
                            mod.fecha_inicio = Convert.ToString(dr[4]);
                            mod.estado = dr[5].ToString();
                            mod.fecha_actualizacion = Convert.ToString(dr[6]);

                            listamod.Add(mod);

                        }
                    }
                }
                catch (Exception e)
                {
                    string horror = e.Message.ToString();
                    return listamod;
                }
                finally
                {

                    if (con != null) { con.Close(); }
                }

                return listamod;
            }
            public bool EliminarByID(int Id)
            {
                conexion();
                DataTable dt = new DataTable();
                NpgsqlCommand sqlcmd = new NpgsqlCommand("delete  from schemasye.tc_enfermedad_cronica where id_enf_cronica=" + Id, con);
                sqlcmd.CommandType = CommandType.Text;


                try
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlcmd);
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                }
                catch (Exception e)
                {
                    string horror = e.Message.ToString();
                    return false;
                }
                finally
                {

                    if (con != null) { con.Close(); }
                }



                return true;
            }
            public bool Actualizar(modCatalogo mod)
            {
                conexion();
                DataTable dt = new DataTable();
                NpgsqlCommand sqlcmd = new NpgsqlCommand("update schemasye.tc_enfermedad_cronica set descripcion='" + mod.descripcion + "' where id_enf_cronica=" + mod.id_enf_cronica.ToString(), con);
                sqlcmd.CommandType = CommandType.Text;

                try
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlcmd);
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                }
                catch (Exception e)
                {
                    string horror = e.Message.ToString();
                    return false;
                }
                finally
                {

                    if (con != null) { con.Close(); }
                }
                return true;
            }
            public bool Insertar(modCatalogo mod)
            {
                conexion();
                DataTable dt = new DataTable();
                NpgsqlCommand sqlcmd = new NpgsqlCommand("insert into schemasye.tc_enfermedad_cronica (nombre,descripcion,fecha_registro,fecha_inicio,estado,fecha_actualizacion) values('" + mod.nombre + "','" + mod.descripcion + "',current_date,current_date," + mod.estado +",current_date)", con);

            sqlcmd.CommandType = CommandType.Text;

                try
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlcmd);
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                }
                catch (Exception e)
                {
                    string horror = e.Message.ToString();
                    return false;
                }
                finally
                {

                    if (con != null) { con.Close(); }
                }
                return true;
            }
        }
    }