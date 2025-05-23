using System.Threading.Tasks.Dataflow;

public class UsuarioService
{
    private List<UsuarioModel> usuariosCadastrados = new List<UsuarioModel>();
    private int proximoId = 1;
    public bool Cadastrar(string usuario, string senha, GeneroUsuario genero)
    {
        try
        {
            UsuarioModel novoUsuario = new UsuarioModel(proximoId, usuario, senha, genero);
            usuariosCadastrados.Add(novoUsuario);
            proximoId++;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar cadastrar: " + e);
            return false;
        }
    }

    public int? Logar(string usuario, string senha)
    {
        try
        {
            // Varre toda a lista buscando um usuário
            foreach (var usuarioModel in usuariosCadastrados)
            {
                // Verifica se as credenciais são iguais ao do usuário
                if (usuarioModel.Usuario.Equals(usuario) && usuarioModel.Senha.Equals(senha))
                {   
                    // Credenciais compatíveis
                    return usuarioModel.Id;
                }
            }
            return null; // Não encontrou nenhum usuário com as credenciais fornecidas
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro tentar logar: " + e);
            return null;
        }
    }

    public UsuarioModel buscarUsuario(int? id)
    {
        try
        {
            foreach (var usuario in usuariosCadastrados)
            {
                if (usuario.Id == id)
                {
                    return usuario;
                }
            }
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar exibir os dados: " + e);
            return null;
        }
             
    }

    public bool TrocarSenha(int? idUsuario, string senhaAtual)
    {
        try
        {
            foreach (var usuario in usuariosCadastrados)
            {
                if (usuario.Id == idUsuario && usuario.Senha.Equals(senhaAtual))
                {
                    Console.Write("Digite a nova senha: ");
                    usuario.Senha = Console.ReadLine();
                    return true;
                }
            }
            Console.WriteLine("Senha incorreta, tente novamente");
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar trocar a senha: " + e);
            return false;
        }  
    }
}