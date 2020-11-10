using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Biblioteca_Virtual.Models
{
    public class Libro
    {
        public int idLibro { get; set; }

        public string nombreLibro { get; set; }

        public string generoLibro { get; set; }

        public string autorLibro { get; set; }

        public string editorialLibro { get; set; }

        public Blob portadaLibro { get; set; }


    }
}
