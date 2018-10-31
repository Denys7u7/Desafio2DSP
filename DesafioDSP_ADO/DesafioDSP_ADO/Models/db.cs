using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DesafioDSP_ADO.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void agregarAsignatura(DatosAsignatura asig)
        {
            try
            {
                SqlCommand com = new SqlCommand("insertarMateria", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@materia", asig.nombreMateria);
                com.Parameters.AddWithValue("@codigo_materia", asig.codigoMateria);
                com.Parameters.AddWithValue("@curso", asig.curso);
                com.Parameters.AddWithValue("@id_tipo_materia", asig.idTipoMateria);
                com.Parameters.AddWithValue("@id_titulacion", asig.idTitulacion);
                com.Parameters.AddWithValue("@creditos_teoricos", asig.creditosTeoricos);
                com.Parameters.AddWithValue("@creditos_laboratorio", asig.creditosLaboratorios);
                com.Parameters.AddWithValue("@duracion", asig.duracion);
                com.Parameters.AddWithValue("@limiteAdmision", asig.limiteAdmision);
                com.Parameters.AddWithValue("@gruposTeoria", asig.gruposTeo);
                com.Parameters.AddWithValue("@gruposLaboratorio", asig.gruposLab);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void modificarAsignatura(int id, DatosAsignatura asig)
        {
            try
            {
                SqlCommand com = new SqlCommand("modificarMateria", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@materia", asig.nombreMateria);
                com.Parameters.AddWithValue("@codigo_materia", asig.codigoMateria);
                com.Parameters.AddWithValue("@curso", asig.curso);
                com.Parameters.AddWithValue("@id_tipo_materia", asig.idTipoMateria);
                com.Parameters.AddWithValue("@id_titulacion", asig.idTitulacion);
                com.Parameters.AddWithValue("@creditos_teoricos", asig.creditosTeoricos);
                com.Parameters.AddWithValue("@creditos_laboratorio", asig.creditosLaboratorios);
                com.Parameters.AddWithValue("@duracion", asig.duracion);
                com.Parameters.AddWithValue("@limiteAdmision", asig.limiteAdmision);
                com.Parameters.AddWithValue("@gruposTeoria", asig.gruposTeo);
                com.Parameters.AddWithValue("@gruposLaboratorio", asig.gruposLab);
                com.Parameters.AddWithValue("@idMateria", id);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void eliminarAsignatura(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("eliminarMateria", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@idMateria", id);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void agregarProfesor(DatosProfesor prof)
        {
            try
            {
                SqlCommand com = new SqlCommand("insertarProfe", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@nombre", prof.nomProfesor);
                com.Parameters.AddWithValue("@apellido", prof.apellido);
                com.Parameters.AddWithValue("@despacho", prof.despacho);
                com.Parameters.AddWithValue("@horario_Consultas", prof.horariosConsultas);
                com.Parameters.AddWithValue("@id_area_conocimiento", prof.idAreaConocimiento);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void modificarProfesor(DatosProfesor prof, int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("modificarProfe", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@nombre", prof.nomProfesor);
                com.Parameters.AddWithValue("@apellido", prof.apellido);
                com.Parameters.AddWithValue("@despacho", prof.despacho);
                com.Parameters.AddWithValue("@horario_Consultas", prof.horariosConsultas);
                com.Parameters.AddWithValue("@id_area_conocimiento", prof.idAreaConocimiento);
                com.Parameters.AddWithValue("@id_profesor", id);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void eliminarProfesor(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("eliminarProfe", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id_profesor", id);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public DataSet verMaterias(int id)
        {
            SqlCommand com = new SqlCommand("mostrarMaterias", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idTipo", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet verMateriasAll()
        {
            SqlCommand com = new SqlCommand("mostrarMateriasAll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet verProfesores()
        {
            SqlCommand com = new SqlCommand("verProfe", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet verProfesoresById(int id)
        {
            SqlCommand com = new SqlCommand("verProfesById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}