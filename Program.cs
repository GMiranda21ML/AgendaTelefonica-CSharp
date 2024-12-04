using System.Globalization;

class Program
{
    static void Menu()
    {
        Console.WriteLine(@"
░█████╗░░██████╗░███████╗███╗░░██╗██████╗░░█████╗░
██╔══██╗██╔════╝░██╔════╝████╗░██║██╔══██╗██╔══██╗
███████║██║░░██╗░█████╗░░██╔██╗██║██║░░██║███████║
██╔══██║██║░░╚██╗██╔══╝░░██║╚████║██║░░██║██╔══██║
██║░░██║╚██████╔╝███████╗██║░╚███║██████╔╝██║░░██║
╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝

████████╗███████╗██╗░░░░░███████╗███████╗░█████╗░███╗░░██╗██╗░█████╗░░█████╗░
╚══██╔══╝██╔════╝██║░░░░░██╔════╝██╔════╝██╔══██╗████╗░██║██║██╔══██╗██╔══██╗
░░░██║░░░█████╗░░██║░░░░░█████╗░░█████╗░░██║░░██║██╔██╗██║██║██║░░╚═╝███████║
░░░██║░░░██╔══╝░░██║░░░░░██╔══╝░░██╔══╝░░██║░░██║██║╚████║██║██║░░██╗██╔══██║
░░░██║░░░███████╗███████╗███████╗██║░░░░░╚█████╔╝██║░╚███║██║╚█████╔╝██║░░██║
░░░╚═╝░░░╚══════╝╚══════╝╚══════╝╚═╝░░░░░░╚════╝░╚═╝░░╚══╝╚═╝░╚════╝░╚═╝░░╚═╝
");

        Console.WriteLine(@"
Digite 1 para armazenar um contato
Digite 2 para visualizar seus contatos
Digite 3 para atualizar um de seus contatos
Digite 4 para deletar um de seus contatos
Digite 0 para sair");

    }


    static void LimparTela()
    {
        Console.Write("Digite qualquer tecla para voltar ao menu: ");
        Console.ReadKey();
    }


    static string TitleCase(string text)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(text.ToLower());
    }


    static void Armazenar(Dictionary<string, string> agenda)
    {
        Console.Clear();
        Console.WriteLine(@"
▄▀█ █▀█ █▀▄▀█ ▄▀█ ▀█ █▀▀ █▄░█ ▄▀█ █▀█   █▀▀ █▀█ █▄░█ ▀█▀ ▄▀█ ▀█▀ █▀█
█▀█ █▀▄ █░▀░█ █▀█ █▄ ██▄ █░▀█ █▀█ █▀▄   █▄▄ █▄█ █░▀█ ░█░ █▀█ ░█░ █▄█
");
        Console.Write("Digite o nome da pessoa que você deseja armazenar na agenda: ");
        string nome = Console.ReadLine()!;
        nome = TitleCase(nome);
        Console.Write($"Digite o telefone de {nome}: ");
        string telefone = Console.ReadLine()!;

        agenda[nome] = telefone;
    }


    static void Visualizar(Dictionary<string, string> agenda)
    {
        Console.Clear();
        Console.WriteLine(@"
█▀▀ █▀█ █▄░█ ▀█▀ ▄▀█ ▀█▀ █▀█ █▀
█▄▄ █▄█ █░▀█ ░█░ █▀█ ░█░ █▄█ ▄█
");

        Console.WriteLine("-----------------------------------------");
        foreach (KeyValuePair<string, string> contato in agenda)
        {
            Console.WriteLine(@$"
Nome: {contato.Key}
Telefone: {contato.Value}
");
            Console.WriteLine("-----------------------------------------");
        }

    }


    static void Atualizar(Dictionary<string, string> agenda)
    {
        Console.Clear();
        Console.WriteLine(@"
▄▀█ ▀█▀ █░█ ▄▀█ █░░ █ ▀█ ▄▀█ █▀█   █▀▀ █▀█ █▄░█ ▀█▀ ▄▀█ ▀█▀ █▀█
█▀█ ░█░ █▄█ █▀█ █▄▄ █ █▄ █▀█ █▀▄   █▄▄ █▄█ █░▀█ ░█░ █▀█ ░█░ █▄█"
);

        Console.Write("\nDigite o nome do contato que você deseja atualizar: ");
        string contatoParaAtualizar = Console.ReadLine()!;
        contatoParaAtualizar = TitleCase(contatoParaAtualizar);

        if (agenda.ContainsKey(contatoParaAtualizar))
        {
            Console.WriteLine("Você deseja atualizar o nome ou o telefone deste contato?");
            Console.Write("Digite 1 ou 2 respectivamente: ");
            string opcao = Console.ReadLine()!;

            if (int.TryParse(opcao, out int op))
            {
                switch (op)
                {
                    case 1:
                        Console.Write("Digite o novo nome para o seu contato: ");
                        string nomeNovo = Console.ReadLine()!;
                        nomeNovo = TitleCase(nomeNovo);

                        string tel = agenda[contatoParaAtualizar];

                        agenda.Remove(contatoParaAtualizar);

                        agenda[nomeNovo] = tel;

                        Console.WriteLine($"O nome do contato ({nomeNovo}) foi atualizado com sucesso!");
                        break;
                    
                    case 2:
                        Console.Write("Digite o nome telefone do seu contato: ");
                        string telefoneNovo = Console.ReadLine()!;

                        agenda[contatoParaAtualizar] = telefoneNovo;

                        Console.WriteLine($"O telefone do contato ({contatoParaAtualizar}) foi atualizado com sucesso!");
                        break;

                    default:
                        Console.WriteLine("Opção invalida! Por favor, digite novamente.");
                        break;
                }

            }
            else
            {
                Console.WriteLine("Opção invalida! Por favor, digite novamente.");
            }

        }
        else
        {
            Console.WriteLine("Esse contato não existe!");
        }

    }


    static void Deletar(Dictionary<string, string> agenda)
    {
        Console.Clear();
        Console.WriteLine(@"
█▀▄ █▀▀ █░░ █▀▀ ▀█▀ ▄▀█ █▀█   █▀▀ █▀█ █▄░█ ▀█▀ ▄▀█ ▀█▀ █▀█
█▄▀ ██▄ █▄▄ ██▄ ░█░ █▀█ █▀▄   █▄▄ █▄█ █░▀█ ░█░ █▀█ ░█░ █▄█
");

        Console.Write("Digite o nome do contato que você deseja deletar: ");
        string contatoParaDeletar = Console.ReadLine()!;
        contatoParaDeletar = TitleCase(contatoParaDeletar);

        if (agenda.ContainsKey(contatoParaDeletar))
        {
            agenda.Remove(contatoParaDeletar);

            Console.WriteLine($"Contato ({contatoParaDeletar}) deletado com sucesso!");
        }
        else
        {
            Console.WriteLine("Esse contato não existe!");
        }

    }


    static void Main()
    {
        Dictionary<string, string> agenda = new Dictionary<string, string>();

        while (true)
        {
            Console.Clear();
            Menu();
            Console.Write("Digite sua opção: ");
            string opcao = Console.ReadLine()!;

            if (int.TryParse(opcao, out int op))
            {
                switch (op)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Saindo...");
                        return;
                    
                    case 1:
                        Armazenar(agenda);
                        break;
                    
                    case 2:
                        Visualizar(agenda);
                        break;
                    
                    case 3:
                        Atualizar(agenda);
                        break;

                    case 4:
                        Deletar(agenda);
                        break;
                    
                    default:
                        Console.WriteLine("Opção invalida! Por favor, digite novamente.");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Opção invalida! Por favor, digite novamente.");
            }

            LimparTela();

        }
        
    }

}