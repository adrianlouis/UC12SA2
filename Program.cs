// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using Cadastro_Pessoa_FS1.Classes;

Console.Clear();
Console.WriteLine(@$"
=================================================
|       Bem vindo ao sistema de cadastro de     |
|           Pessoas Físicas e Jurídicas         |
=================================================
");

ProgressBar("Carregando ");

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
string? opcao;
// string? opcaoPj;

do
{
Console.Clear();

Console.WriteLine(@$"
=================================================
|       Escolha uma das opções abaixo           |
|-----------------------------------------------|
|             1 - Pessoa Física                 |
|             2 - Pessoa Jurídica               |
|                                               |
|             0 - Sair                          |
=================================================

");

opcao = Console.ReadLine();

switch (opcao)
{
    case "1":
    Console.Beep();
Console.Clear();
PessoaFisica metodoPf = new PessoaFisica();

string opcaoPf;
do
{
    Console.Clear();
    Console.WriteLine(@$"
=================================================
|       Escolha uma das opções abaixo           |
|-----------------------------------------------|
|             1 - Cadastrar Pessoa Física       |
|             2 - Mostrar Pessoa Física         |
|                                               |
|             0 - Voltar                        |
=================================================

");

opcaoPf = Console.ReadLine();

switch (opcaoPf)
{
    case "1":
    Console.Beep();

    PessoaFisica novaPf = new PessoaFisica();
    Endereco novoEnd = new Endereco();
    Console.Clear();
    Console.WriteLine($"Digite o nome da pessoa física para cadastro: ");
    novaPf.nome = Console.ReadLine();

    bool sairData = true;
    do
    {
    Console.WriteLine($"Digite a data de nascimento. Ex.: DD/MM/AAAA");
    string novaDataNasc = Console.ReadLine();
    if (metodoPf.ValidarDataNascimento(novaDataNasc))
    {
      novaPf.dataNascimento = novaDataNasc;
      sairData = true;
    }else{
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Data digitada inválida! Digite uma data com o formato: DD/MM/AAAA");
        Console.ResetColor();
        sairData = false;
    }
    
    } while (sairData == false);

    Console.WriteLine($"Digite o CPF:");
    novaPf.cpf = Console.ReadLine();

    Console.WriteLine($"Digite o rendimento mensal. Obs.: Use apenas números!");
    novaPf.rendimento = float.Parse(Console.ReadLine());


    Console.WriteLine($"Digite o logradouro:");
    novoEnd.logradouro = Console.ReadLine();

    Console.WriteLine($"Digite o número:");
    novoEnd.numero = int.Parse(Console.ReadLine());

    Console.WriteLine($"Digite o complemento:");
    novoEnd.complemento = Console.ReadLine();

    Console.WriteLine($"Este endereço é comercial? S/N");
    string endCom = Console.ReadLine().ToLower();
   
    if (endCom == "s"){
    novoEnd.endComercial = true;
    }else{
    novoEnd.endComercial = false;
}

    novaPf.endereco = novoEnd;

    listaPf.Add(novaPf);

    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Beep();
    Console.Clear();

    Console.WriteLine(@$"
Cadastro realizado com sucesso!!!");
    Console.ResetColor();
    Thread.Sleep(2000);

        break;


    case "2":
    Console.Clear();
    Console.Beep();


    if (listaPf.Count > 0)
    {
        
        foreach (PessoaFisica cadaPessoa in listaPf)
        {
            Console.WriteLine(@$"
Nome: {cadaPessoa.nome}
Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
Data de nascimento: {cadaPessoa.dataNascimento}
Taxa de imposto: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")} ");


Console.WriteLine(@$"
Aperte ENTER para continuar");
Console.ReadLine();
        }

    }else{
        Console.WriteLine($"LISTA VAZIA!!!");
        Thread.Sleep(3000);
        
    }

    
        break;


    case "0":
    Console.Beep();
        break;
    default:
     Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Opção inválida, por favor digite outra opção");
    Console.ResetColor();
    Thread.Sleep(2000);
        break;
}


} while (opcaoPf != "0");




        break;
    case "2":
    Console.Beep();
    Console.Clear();
    PessoaJuridica metodoPj = new PessoaJuridica();

    string opcaoPj;
    do
    {
    Console.Clear(); 
    Console.WriteLine(@$"
=================================================
|       Escolha uma das opções abaixo           |
|-----------------------------------------------|
|             1 - Cadastrar Pessoa Jurídica     |
|             2 - Mostrar Pessoa Jurídica       |
|                                               |
|             0 - Voltar                        |
=================================================

");

opcaoPj = Console.ReadLine();

switch (opcaoPj)
{
    case "1":
    //Cadastrar
    Console.Beep();    
    PessoaJuridica novaPj = new PessoaJuridica();
    Endereco newAdress = new Endereco();

    Console.Clear();
    Console.WriteLine($"Digite o nome da pessoa jurídica para cadastro:");
    novaPj.nome = Console.ReadLine();

    bool sairCnpj = true;
    do
    {
    Console.WriteLine($"Digite o CNPJ:");
    string cnpj = Console.ReadLine();
    if (metodoPj.ValidarCnpj(cnpj))
    {
      novaPj.cnpj = cnpj;
      sairCnpj = true;
    }else{
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"CNPJ informado inválido! Digite no formato XX.XXX.XXX/0001-XX ou XXXXXXXX0001XX");
        Console.ResetColor();
        sairCnpj = false;
    }
        
    } while (sairCnpj == false);

    Console.WriteLine($"Digite a Razão Social:");
    novaPj.razaoSocial = Console.ReadLine();

    Console.WriteLine($"Digite o rendimento mensal. Obs.: Use apenas números!");
    novaPj.rendimento = float.Parse(Console.ReadLine());
    
    Console.WriteLine($"Digite o logradouro:");
    newAdress.logradouro = Console.ReadLine();
    
    Console.WriteLine($"Digite o número:");
    newAdress.numero = int.Parse(Console.ReadLine());

    Console.WriteLine($"Digite o complemento:");
    newAdress.complemento = Console.ReadLine();

    Console.WriteLine($"Este endereço é comercial? S/N");
    string endComer = Console.ReadLine().ToLower();

    if (endComer == "s"){
        newAdress.endComercial = true;
    }else{
        newAdress.endComercial = false;
    }

    novaPj.endereco = newAdress;
    
    listaPj.Add(novaPj);

    
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Beep();
    Console.Clear();

    Console.WriteLine(@$"
Cadastro realizado com sucesso!!!");
    Console.ResetColor();
    Thread.Sleep(2000);

        break;
    
    case "2":
    Console.Clear();
    Console.Beep();

    if (listaPj.Count > 0)
    {

        foreach (PessoaJuridica people in listaPj)
        {
    Console.WriteLine(@$"
Nome: {people.nome}
CNPJ: {people.cnpj}
Razão Social: {people.razaoSocial}
Taxa de imposto: {metodoPj.PagarImposto(people.rendimento).ToString("C")} ");


Console.WriteLine(@$"
Aperte ENTER para continuar");
Console.ReadLine();
        }
    }else{
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"LISTA VAZIA!!!");
        Console.ResetColor();
        Thread.Sleep(3000);
    }
        break;
    
    case "0":
    Console.Beep();
        break;

    default:
    Console.Beep();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Opção inválida, por favor digite outra opção");
    Console.ResetColor();
    Thread.Sleep(2000);
        break;
}

} while (opcaoPj != "0");

break;


        break;
    case "0":
    Console.Beep();

    Console.Clear();
    Console.WriteLine($"Au revoir mon amie! :D");
    for (var count = 0; count < 20; count++)
    {
    Console.Write(". ");
        Thread.Sleep(100);
    }
    
        break;
    default:
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Opção inválida, por favor digite outra opção");
    Console.ResetColor();
    Thread.Sleep(2000);
        break;
}
} while (opcao != "0");



static void ProgressBar(string status){

Console.ForegroundColor = ConsoleColor.Green;

for (var contador = 0; contador < 11; contador++)
{
    
    switch (contador)
    {
        case 0:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} -");
            break;

        case 1:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} \\");
            break;
        
        case 2:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} |");
            break;
        
        case 3:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} /");
            break;
        
        case 4:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} -");
            break;
        
        case 5:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} \\");
            break;
            
        case 6:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} |");
            break;
            
        case 7:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} /");
            break;
            
        case 8:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} -");
            break;
            
        case 9:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine($"{status} \\");
            break;
            
        case 10:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine(" ");
            break;
            
        default:
            Console.SetCursorPosition(0, Console.CursorTop -1); Console.WriteLine(":D");

            break;
    }
    
    Thread.Sleep(150);
}

Console.ResetColor();

}





