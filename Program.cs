UsuarioService usuarioService = new UsuarioService();
TelaLogin(usuarioService);

static void TelaLogin(UsuarioService usuarioService)
{
    int option;
    do
    {
        Console.WriteLine("\n-------Bem vindo a tela Login-------");
        Console.Write("1- Login \n2- Sign up\n3- Sair\nEscolha uma opção: ");

        while (!int.TryParse(Console.ReadLine(), out option))
        {
            Console.Write("Escolha novamente uma opção: ");
        }

        switch (option)
        {
            case 1:
                Console.Clear();
                Console.Write("\nDigite o seu usuário: ");
                string usuario = Console.ReadLine();

                Console.Write("Digite sua senha: ");
                string senha = Console.ReadLine();
                
                int? idUsuario = usuarioService.Logar(usuario, senha);
                if (idUsuario != null)
                {
                    Console.WriteLine("Login efetuado com sucesso");
                    TelaHome(usuarioService, idUsuario);
                }
                else
                {
                    Console.WriteLine("Usuario ou senha incorreto, tente novamente.");
                }
                break;
            case 2:
                Console.Clear();
                Console.Write("\nDigite o seu usuário: ");
                usuario = Console.ReadLine();
                Console.Write("Digite sua senha: ");
                senha = Console.ReadLine();

                GeneroUsuario genero = GeneroUsuario.Masculino;
                char generoOption;
                do
                {
                    Console.Write("\nM- Masculino\nF- Feminino\nO- Outro\nEscolha o seu genero: ");
                    char.TryParse(Console.ReadLine().ToUpper(), out generoOption);

                    switch (generoOption)
                    {
                        case 'M': genero = GeneroUsuario.Masculino; break;
                        case 'F': genero = GeneroUsuario.Feminino; break;
                        case 'O': genero = GeneroUsuario.Outro; break;
                        default: Console.WriteLine("Opção inválida, tente novamente"); continue;
                    }
                } while (generoOption != 'M' && generoOption != 'F');
                bool response = usuarioService.Cadastrar(usuario, senha, genero);
                Console.WriteLine(response ? "Usuário cadastrado com sucesso" : "Erro ao tentar cadastrar");
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Fim do programa");
                System.Environment.Exit(0);
                break;
        }
    } while (option != 0);
}

static void TelaHome(UsuarioService usuarioService, int? idUsuario) {
    int option;
    do
    {
        Console.WriteLine("\n-------Bem vindo a tela home-------");
        Console.Write("1- Exibir dados\n2- trocar senha\n3- Log off\nEscolha uma opção: ");

        while (!int.TryParse(Console.ReadLine(), out option))
        {
            Console.Write("Escolha novamente uma opção: ");
        }

        switch (option)
        {
            case 1:
                Console.Clear();
                UsuarioModel usuario = usuarioService.buscarUsuario(idUsuario);
                if (usuario != null)
                {
                    Console.WriteLine("Usuário: " + usuario.Usuario);
                    Console.WriteLine("Senha: " + usuario.Senha);
                    Console.WriteLine("Gênero: " + usuario.Genero);
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado.");
                }
                break;
            case 2:
                bool response;

                Console.Clear();
                do
                {
                    Console.Write("\nDigite a senha atual: ");
                    string senhaAtual = Console.ReadLine();

                    response = usuarioService.TrocarSenha(idUsuario, senhaAtual);
                    Console.WriteLine(response ? "Senha trocada com sucesso." : "Erro ao tentar trocar a senha.");
                } while (!response);
                
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Redirecioando a tela de login...");
                TelaLogin(usuarioService);
                break;
        }
    } while (option != 0);
}

