namespace FirstApiRest.Models;

public class Post
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Conteudo { get; set; }
    public DateTime Data { get; set; }
}