using System;

namespace Biblioteca_Virtual.Azure
{
    internal class Libro
    {
        public string editorialLibro { get; internal set; }
        public string generoLibro { get; internal set; }
        public string autorLibro { get; internal set; }
        public string nombreLibro { get; internal set; }
        public int idLibro { get; internal set; }

        internal void Add(Libro libro)
        {
            throw new NotImplementedException();
        }
    }
}