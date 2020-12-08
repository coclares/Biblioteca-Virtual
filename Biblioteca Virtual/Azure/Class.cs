using Biblioteca_Virtual.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_Virtual.Azure
{
    
    
        public class BibliotecaAzure
        {

        //static string connectionString = @"Server=DESKTOP-FS6N88V\SQLEXPRESS01;Database=BibliotecaVirtual;Trusted_Connection=True;";
        static string connectionString = "Server = tcp:biliotecavirtual.database.windows.net,1433;Database=BibliotecaVirtualDB;User ID =Coclares@biliotecavirtual.database.windows.net;Password=Duoc1234;Trusted_Connection=False;Encrypt=True;";
  

            private static readonly List<Libro> libros;

        internal static List<Libro> Libros => libros;

        public static List<Libro> ObtenerLibros
        {
            get
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var consultaSql = "select * from Libro";

                    var comando = ConsultaSqlLibro(connection, consultaSql);

                    var dataTableLibro = LlenarDataTable(comando);

                    return LLenadoLibro(dataTableLibro);
                }
            }
        }

        private static List<Libro> LLenadoLibro(object dataTableLibro)
        {
            throw new NotImplementedException();
        }

        private static object LlenarDataTable(object comando)
        {
            throw new NotImplementedException();
        }

        private static object ConsultaSqlLibro(SqlConnection connection, string consultaSql)
        {
            throw new NotImplementedException();
        }

        public static Libro ObtenerLibroPorId(int idLibro)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var consultaSql = $"select * from Libro where idLibro = {idLibro}";

                    var comando = ConsultaSqlLibro(connection, consultaSql);

                    var dataTable = LlenarDataTable(comando);

                    return CreacionLibro(dataTable);
                }
            }

        private static Libro CreacionLibro(object dataTable)
        {
            throw new NotImplementedException();
        }

        public static Libro ObtenerLibroPornombreLibro(string nombreLibro)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var consultaSql = $"select * from Libro where nombreLibro = '{nombreLibro}'";

                    var comando = ConsultaSqlLibro(connection, consultaSql);

                    var dataTable = LlenarDataTable(comando);

                    return CreacionLibro(dataTable);

                }
            }

                public static int AgregarLibro(Libro libro)
            {
                int filasAfectadas = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(null, connection);
                    sqlCommand.CommandText = "Insert into Libro (nombreLibro,autorLibro,generoLibro,editorialLibro) values (@nombreLibro,@autorLibro,@generoLibro,@editorialLibro)";
                    sqlCommand.AddWithValue("@nombreLibro", libro.nombreLibro);
                    sqlCommand.AddWithValue("@autorLibro", libro.autorLibro);
                    sqlCommand.AddWithValue("@generoLibro", libro.generoLibro);
                    sqlCommand.AddWithValue("@editorialLibro", libro.editorialLibro);    

                try
                    {
                        connection.Open();
                        filasAfectadas = sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
                return filasAfectadas;
            }

            public static int AgregarLibro(string nombreLibro, string autorLibro,string generoLibro,string editorialLibro)
            {
                int resultado = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(null, connection);
                    sqlCommand.CommandText = "Insert into Libro (nombreLibro,autorLibro,generoLibro,editorialLibro) values (@nombreLibro,@autorLibro,@generoLibro,@editorialLibro)";
                    sqlCommand.AddWithValue("@nombreLibro", nombreLibro);
                    sqlCommand.AddWithValue("@autorLibro", autorLibro);
                    sqlCommand.AddWithValue("@generoLibro", generoLibro);
                    sqlCommand.AddWithValue("@editorialLibro", editorialLibro);
                try
                    {
                        connection.Open();
                        resultado = sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return resultado;
            }

            public static int EliminarLibroPornombreLibro(string nombreLibro)
            {
                int resultado = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(null, connection);
                    sqlCommand.CommandText = "Eliminar from Libro where nombreLibro = @nombreLibro";
                    sqlCommand.AddWithValue("@nombreLibro", nombreLibro);

                    try
                    {
                        connection.Open();
                        resultado = sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return resultado;
                }
            }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

            private static SqlCommand ConsultaSqlLibro(SqlConnection connection, string consulta)
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = consulta;
                connection.Open();
                return sqlCommand;
            }
            private static Libro CreacionLibro(DataTable dataTable)
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    Libro libro = new Libro();
                    libro.idLibro = int.Parse(dataTable.Rows[0]["idLibro"].ToString());
                    libro.nombreLibro = dataTable.Rows[0]["nombreLibro"].ToString();
                    libro.autorLibro = dataTable.Rows[0]["autorLibro"].ToString();
                    libro.generoLibro = dataTable.Rows[0]["generoLibro"].ToString();
                    libro.editorialLibro = dataTable.Rows[0]["editorialLibro"].ToString();

                      return libro;
                }
                else
                {
                    return null;
                }
            }
            private static DataTable LlenarDataTable(SqlCommand comando)
            {
                //2. llenamos el dataTable(conversion)
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter(comando);
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            private static List<Libro> LLenadoLibros(DataTable dataTable)
            {
                List<Libro> Libro = new List<Libro>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Libro libro = new Libro();
                    libro.idLibro = int.Parse(dataTable.Rows[i]["idLibro"].ToString());
                    libro.nombreLibro = dataTable.Rows[i]["nombreLibro"].ToString();
                    libro.autorLibro = dataTable.Rows[i]["autorLibro"].ToString();
                    libro.generoLibro = dataTable.Rows[i]["generoLibro"].ToString();
                    libro.editorialLibro = dataTable.Rows[i]["editorialLibro"].ToString();
                    libro.Add(libro);
                }
                return Libro;
    }
}


    


namespace Biblioteca_Virtual.Azure
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    private class SqlDataAdapter
    {
        private SqlCommand comando;

        public SqlDataAdapter()
        {
        }

        public SqlDataAdapter(SqlCommand comando)
        {
            this.comando = comando;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}