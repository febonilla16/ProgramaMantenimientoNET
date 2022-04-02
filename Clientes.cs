using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace ProgramaMantenimiento
{
    public class Clientes
    {
        //herramientas para la clase
        private static Conection conexion = new Conection();
        private static SqlDataAdapter dataAdapter;
        private static SqlDataReader dataReader;
        private static SqlCommand cmd;

        //campos de la clase acorde a los campos de la tabla Clientes en la BD
        private int idCliente;
        private string nombres;
        private string apellidos;
        private int telefono;

        //propiedades de la clase
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Telefono { get => telefono; set => telefono = value; }

        //--Métodos de la clase--//

        //método para agregar registros
        public void Insertar()
        {
            conexion.Conectar();
            cmd = new SqlCommand("insertar_registros", conexion.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", Nombres);
            cmd.Parameters.AddWithValue("@LastName", Apellidos);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.ExecuteNonQuery();
            conexion.Desc();
        }

        //método para modificar registros
        public void Modificar()
        {
            conexion.Conectar();
            cmd = new SqlCommand("modificar_registro", conexion.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", IdCliente);
            cmd.Parameters.AddWithValue("@Name", Nombres);
            cmd.Parameters.AddWithValue("@LastName", Apellidos);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.ExecuteNonQuery();
            conexion.Desc();
        }

        //método para ver registros
        public static List<Clientes> Extraer()
        {
            List<Clientes> rclientes = new List<Clientes>(); //lista para guardar registros
            string sql = "SELECT * FROM Clientes";

            try
            {
                //conexión a BD
                conexion.Conectar();
                dataAdapter = new SqlDataAdapter(sql, conexion.Con);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();

                //evalua si hay datos
                if (dataReader.HasRows)
                {
                    //bucle para recorrer los registros
                    while (dataReader.Read())
                    {
                        Clientes cl = new Clientes
                        {
                            IdCliente = Convert.ToInt32(dataReader["IDCliente"].ToString()),
                            Nombres = dataReader["Nombres"].ToString(),
                            Apellidos = dataReader["Apellidos"].ToString(),
                            Telefono = Convert.ToInt32(dataReader["Telefono"].ToString())
                        };

                        //añadimos el registro a la lista
                        rclientes.Add(cl);
                        cl = null;
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros en la BD", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                dataReader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Se produjo un error al extraer datos de la BD, consulte con un administrador: " +err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //cerramos la conexión
                conexion.Desc();
            }
            return rclientes;
        }

        //método para eliminar registros
        public static bool Eliminar(int ID)
        {
            bool borrado = false;
            string sql = "DELETE FROM Clientes WHERE IDCliente = @id";

            try
            {
                conexion.Conectar();
                cmd = new SqlCommand(sql, conexion.Con);
                cmd.Parameters.AddWithValue("@id", ID);

                //evaluamos si se actualizo el producto
                borrado = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al intentar borrar el producto en la DB, contacte con un administrador: " + err.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conexion.Desc();
            }
            return borrado;
        }

        //método para ver un registro
        public static Clientes Ver(int ID)
        {
            Clientes clientes = new Clientes();
            string sql = "SELECT * FROM Clientes WHERE IDCliente = @id";

            try
            {
                conexion.Conectar();
                dataAdapter = new SqlDataAdapter(sql, conexion.Con);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@id", ID);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    clientes.IdCliente = Convert.ToInt32(dataReader["IDCliente"].ToString());
                    clientes.Nombres = dataReader["Nombres"].ToString();
                    clientes.Apellidos = dataReader["Apellidos"].ToString();
                    clientes.Telefono = Convert.ToInt32(dataReader["Telefono"].ToString());
                }
                else
                {
                    MessageBox.Show("No hay registros en la BD", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Se produjo un error al extraer datos de la BD, consulte con un administrador: " + err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conexion.Desc();
            }

            return clientes;
        }
    }
}
