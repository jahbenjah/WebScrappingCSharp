using System.Collections.Generic;

namespace AppCore
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }
    }
}