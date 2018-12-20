namespace AppCore
{
    public class Libro
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string UrlImage { get; set; }

        public string Titulo { get; set; }

        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
