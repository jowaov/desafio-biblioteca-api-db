namespace DesafioAPIRocketseat.Communications.Entities
{
    public class RequestLivroCreateJson
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Preco { get; set; }
        public string Genero { get; set; }
        public int Estoque { get; set; }
    }
}