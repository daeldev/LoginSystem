public class UsuarioModel
{
    private int? id;
    private string usuario;
    private string senha;
    private GeneroUsuario genero;

    public UsuarioModel(int id, string usuario, string senha, GeneroUsuario genero)
    {
        this.id = id;
        this.usuario = usuario;
        this.senha = senha;
        this.genero = genero;
    }

    public string Usuario { get => usuario; set => usuario = value; }
    public string Senha { get => senha; set => senha = value; }
    public GeneroUsuario Genero { get => genero; set => genero = value; }
}