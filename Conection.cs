using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ProgramaMantenimiento
{
    public class Conection
    {
        private static string cadena = "server=localhost\\SQLEXPRESS; database=BD_Registros; integrated security=yes"; //cadena de conexión con la BD en SQL Server
                                                                                                                       //con seguridad integrada para este caso
        private SqlConnection con = new SqlConnection(cadena); //declaración de conexión SQL

        public SqlConnection Con { get => con ; } //propiedad pública de conexión

        public void Conectar() //método para abrir conexión
        {
            Con.Open();
        }

        public void Desc() //método para cerrar conexión
        {
            Con.Close();
        }
    }
}
