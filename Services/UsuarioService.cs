public class UsuarioService
{
    UsuarioModel usuarioCadastrado;
    public bool Cadastrar(string usuario, string senha, GeneroUsuario genero)
    {
        try
        {
            usuarioCadastrado = new UsuarioModel(1, usuario, senha, genero);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar cadastrar: " + e);
            return false;
        }
    }

    public bool Logar(string usuario, string senha)
    {
        try
        {
            if (usuarioCadastrado.Usuario == usuario && usuarioCadastrado.Senha == senha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro tentar logar: " + e);
            return false;
        }
    }

    public void ExibirDados()
    {
        Console.WriteLine("Usuario: " + usuarioCadastrado.Usuario);
        Console.WriteLine("Senha: " + usuarioCadastrado.Senha);
        Console.WriteLine("Genero: " + usuarioCadastrado.Genero);
    }

    public bool TrocarSenha(string senhaAtual)
    {
        if (usuarioCadastrado.Senha == senhaAtual)
        {
            Console.Write("Digite a nova senha: ");
            usuarioCadastrado.Senha = Console.ReadLine();
            return true;
        }
        else
        {
            Console.WriteLine("Senha incorreta, tente novamente");
            return false;
        }
    }
}