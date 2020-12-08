using System;

namespace Biblioteca_Virtual.Azure
{
    internal class SqlCommand
    {
        private object p;
        private SqlConnection connection;

        public string CommandText { get; internal set; }

        public SqlCommand(object p, SqlConnection connection)
        {
            this.p = p;
            this.connection = connection;
        }

        internal int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        internal void AddWithValue(string v, string editorialLibro)
        {
            throw new NotImplementedException();
        }

        internal void AddWithValue(string v, object editorialLibro)
        {
            throw new NotImplementedException();
        }
    }
}