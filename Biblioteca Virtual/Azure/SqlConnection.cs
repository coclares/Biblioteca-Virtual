using System;

namespace Biblioteca_Virtual.Azure
{
    internal class SqlConnection
    {
        public SqlConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}