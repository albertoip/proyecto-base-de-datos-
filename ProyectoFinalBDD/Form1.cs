using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoFinalBDD
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=DESKTOP-28H12S4\\MSSQLSERVER02; database= Proyecto; integrated security = true");
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Conexion exitosa");
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la conexion");
            }
        }

        private void btn_consulta_actor_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from ACTORES", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_actores.DataSource = tabla;

        }

        private void btn_insertar_actor_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO ACTORES(id_actor,nombreActor,fecha_naAc,nacionalidad_Actor,sexoActor) VALUES (@id_actor,@nombreActor,@fecha_naAc,@nacionalidad_Actor,@sexoActor)";
            conexion.Close();
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("id_actor", tb_id_actor.Text);
            comando.Parameters.AddWithValue("nombreActor", tb_nombre_actor.Text);
            comando.Parameters.AddWithValue("fecha_naAc", dtp_nacimiento_actor.Value);
            comando.Parameters.AddWithValue("nacionalidad_Actor", tb_nacionalidad_ac.Text);
            comando.Parameters.AddWithValue("sexoActor", cb_sexo_actor.SelectedItem);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("insertado con exito");
        }

        private void btn_modificar_actor_Click(object sender, EventArgs e)
        {
            string query = "UPDATE ACTORES SET nombreActor = @nombreActor,fecha_naAc = @fecha_naAc,nacionalidad_Actor = @nacionalidad_Actor,sexoActor = @sexoActor WHERE id_actor = @id_actor ";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_actor", tb_id_actor.Text);
            comando.Parameters.AddWithValue("@nombreActor", tb_nombre_actor.Text);
            comando.Parameters.AddWithValue("@fecha_naAc", dtp_nacimiento_actor.Value);
            comando.Parameters.AddWithValue("@nacionalidad_Actor", tb_nacionalidad_ac.Text);
            comando.Parameters.AddWithValue("@sexoActor", cb_sexo_actor.SelectedItem);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("modificado con exito");

        }

        private void btn_eliminar_actor_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM ACTORES WHERE id_actor = @id_actor";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_actor", tb_id_actor.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("eliminado correctamente");
           
        } 
       
        //---------------------------apartado de directores-------------------------------------//
        private void btn_consulta_director_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from DIRECTORES", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_directores.DataSource = tabla;
        }

        private void btn_agregar_director_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO DIRECTORES(id_director,nombre,fecha_na,nacionalidad,sexoDirec) VALUES (@id_director,@nombre,@fecha_na,@nacionalidad,@sexoDirec)";
            conexion.Close();
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_director", txt_id_director.Text);
            comando.Parameters.AddWithValue("@nombre", txt_nombre_director.Text);
            comando.Parameters.AddWithValue("@fecha_na", timepicker_directores.Value);
            comando.Parameters.AddWithValue("@nacionalidad", txt_nacionalidad_director.Text);
            comando.Parameters.AddWithValue("@sexoDirec", cb_sexo_director.SelectedItem);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("insertado con exito");
        }

        private void btn_modificar_director_Click(object sender, EventArgs e)
        {
            string query = "UPDATE DIRECTORES SET nombre = @nombre,fecha_na = @fecha_na,nacionalidad = @nacionalidad,sexoDirec = @sexoDirec WHERE id_director = @id_director ";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_director", txt_id_director.Text);
            comando.Parameters.AddWithValue("@nombre", txt_nombre_director.Text);
            comando.Parameters.AddWithValue("@fecha_na", timepicker_directores.Value);
            comando.Parameters.AddWithValue("@nacionalidad", txt_nacionalidad_director.Text);
            comando.Parameters.AddWithValue("@sexoDirec", cb_sexo_director.SelectedItem);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("modificado con exito");
        }

        private void btn_eliminar_director_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM DIRECTORES WHERE id_director = @id_director";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_director", txt_id_director.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("eliminado correctamente");
        }

        //--------------------------- parte clasificaciones ----------------------------------------------//
        private void btn_consulta_clasi_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from CLASIFI", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_clasifiaciones.DataSource = tabla;
        }

        private void btn_insertar_clasi_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO CLASIFI(id_clasifi,asignacion,descripcion) VALUES (@id_clasifi,@asignacion,@descripcion)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_clasifi", txt_id_clasifi.Text);
            comando.Parameters.AddWithValue("@asignacion", txt_asignacion_clasifi.Text);
            comando.Parameters.AddWithValue("@descripcion", txt_descripcion_clasifi.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("insertado con exito");  
        }

        private void btn_modificar_clasi_Click(object sender, EventArgs e)
        {
            string query = "UPDATE CLASIFI SET asignacion = @asignacion,descripcion = @descripcion  WHERE id_clasifi = @id_clasifi ";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_clasifi", txt_id_clasifi.Text);
            comando.Parameters.AddWithValue("@asignacion", txt_asignacion_clasifi.Text);
            comando.Parameters.AddWithValue("@descripcion", txt_descripcion_clasifi.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("modificado con exito");
        }

        private void btn_eliminar_clasi_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM CLASIFI WHERE id_clasifi = @id_clasifi";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_clasifi", txt_id_clasifi.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("eliminado correctamente");
        }
        //------------------------parte de peliculas---------------------------------------------//
        private void btn_consulta_pelicula_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from PELICULA", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_peliculas.DataSource = tabla;
        }
        private void btn_insertar_pelicula_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO PELICULA(id_pelicula,nombre,id_actor,id_director,genero,fechaEstreno,id_clasifi) VALUES (@id_pelicula,@nombre,@id_actor,@id_director,@genero,@fechaEstreno,@id_clasifi)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_pelicula", txt_id_pelicula.Text);
            comando.Parameters.AddWithValue("@nombre", txt_nombre_pelicula.Text);
            comando.Parameters.AddWithValue("@id_actor", cmb_actor_pelicula.SelectedValue);
            comando.Parameters.AddWithValue("@id_director", cmb_director_pelicula.SelectedValue);
            comando.Parameters.AddWithValue("@genero", txt_genero_pelicula.Text);
            comando.Parameters.AddWithValue("@fechaEstreno", timepicker_pelicula.Value);
            comando.Parameters.AddWithValue("@id_clasifi", cmb_clasifi_pelicula.SelectedValue);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("insertado con exito");
        }
        private void btn_modificar_pelicula_Click(object sender, EventArgs e)
        {
            string query = "UPDATE PELICULA SET nombre = @nombre,id_actor = @id_actor, id_director = @id_director, genero = @genero,fechaEstreno = @fechaEstreno,id_clasifi = @id_clasifi WHERE id_pelicula = @id_pelicula ";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_pelicula", txt_id_pelicula.Text);
            comando.Parameters.AddWithValue("@nombre", txt_nombre_pelicula.Text);
            comando.Parameters.AddWithValue("@id_actor", cmb_actor_pelicula.SelectedValue);
            comando.Parameters.AddWithValue("@id_director", cmb_director_pelicula.SelectedValue);
            comando.Parameters.AddWithValue("@genero", txt_genero_pelicula.Text);
            comando.Parameters.AddWithValue("@fechaEstreno", timepicker_pelicula.Value);
            comando.Parameters.AddWithValue("@id_clasifi", cmb_clasifi_pelicula.SelectedValue);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("modificado con exito");
        }
        private void btn_eliminar_pelicula_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM PELICULA WHERE id_pelicula = @id_pelicula";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_pelicula", txt_id_pelicula.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("eliminado correctamente");
        }

        //----------------------- procedimientos almacenados --------------------------------//
        public DataTable CargarCombo()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("SP_CARGARCOMBOBOX", conexion);
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }

        public DataTable CargarComboActor()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("SP_CARGARACTOR", conexion);
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }
        public DataTable CargarComboClasifi()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("SP_CARGARCLASIFI", conexion);
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //cargar combo box de directores
            cmb_director_pelicula.DataSource = CargarCombo();
            cmb_director_pelicula.DisplayMember = "nombre";
            cmb_director_pelicula.ValueMember = "id_director";
            cmb_director_pelicula.DataSource = CargarCombo();
            //cargar combo box de actores 
            cmb_actor_pelicula.DataSource = CargarComboActor();
            cmb_actor_pelicula.DisplayMember = "nombreActor";
            cmb_actor_pelicula.ValueMember = "id_actor";
            cmb_actor_pelicula.DataSource = CargarComboActor();
            //cargar combo box de clasifi
            cmb_clasifi_pelicula.DataSource = CargarComboClasifi();
            cmb_clasifi_pelicula.DisplayMember = "asignacion";
            cmb_clasifi_pelicula.ValueMember = "id_clasifi";
            cmb_clasifi_pelicula.DataSource = CargarComboClasifi();
        }
        //---------------------vistas------------------------------------------------//
        private void btn_vista_1_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from Vista_por_actor", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_vistas.DataSource = tabla;
        }

        private void btn_vista2_Click(object sender, EventArgs e)
        {
            gv_vistas.DataSource = null;
            SqlCommand comando = new SqlCommand("select * from Vista_2", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_vistas.DataSource = tabla;
        }

        private void btn_vista3_Click(object sender, EventArgs e)
        {
         
            SqlCommand comando = new SqlCommand("select * from Vista_3", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_vistas2.DataSource = tabla;
        }

        private void btn_vista_clasi_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from Vista_4", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_vistas3.DataSource = tabla;
        }

        //-------------------------------triggers---------------------------------------------//
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from HISTORIAL_ACTORES", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_historial_actores.DataSource = tabla;
        }

        private void btn_historial_directores_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from HISTORIAL_DIRECTORES", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_historial_directores.DataSource = tabla;
        }

        private void btn_historial_clasifi_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from HISTORIAL_CLASIFI", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_historial_clasi.DataSource = tabla;
        }

        private void btn_historial_peliculas_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from HISTORIAL_PELICULAS", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gv_historial_peliculas.DataSource = tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
