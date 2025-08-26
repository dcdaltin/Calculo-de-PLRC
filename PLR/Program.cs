using System.Threading.Channels;

T ObterDadoConsole<T>(string mensagem)
{
    while (true)
    {
        try
        {
            Console.WriteLine(mensagem);
            string valor = Console.ReadLine();
            T valorGenerico = (T)Convert.ChangeType(valor, typeof(T));
            return valorGenerico;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Valor inválido. Tente novamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido ao obter dado do console: {ex.Message}");
            throw ex;
        }
    }

}


/*
    - Regra Básica: = SALÁRIO * 0.9 + 3343.04 (limitado ao teto de R$ 17.933,79). 
    - Parcela Adicional: = LUCRO_LIQUIDO * 0.022 (limitado ao teto de R$ 6.942,28). 
    - PLR Social: = LUCRO_LIQUIDO * 0.04 (distribuído linearmente). 
    - Total PLR: = Regra_Básica + Parcela_Adicional + PLR_Social. 
    - IR: Utilize uma tabela ou função para calcular o imposto sobre a PLR, considerando a tabela vigente. 
    - PLR Líquido: = Total_PLR - IR
*/

double CalcularPLRLiquido(double totalPlr, double valorIR)
{
    return totalPlr - valorIR;
}

double CalcularIR(double totalPlr, double percentualIR)
{
    // Calcula o IR sobre o total da PLR
    return totalPlr * (percentualIR / 100);
}

double CalcularTotalPLR(double plrBasica, double parcelaAdicional, double plrSocial)
{
    return plrBasica + parcelaAdicional + plrSocial;
}

double CalcularPLRSocial(double lucroLiquido, int colaboradores)
{
    return (lucroLiquido * 0.04) / colaboradores;
}


double CalcularParcelaAdicional(double lucroLiquido, int colaboradores)
{
    // Parcela Adicional é calculada como 2,2% do lucro líquido, dividido pelo número de colaboradores
    double parcelaAdicional = (lucroLiquido * 0.022) / colaboradores;
    // Limitando ao teto de R$ 6.942,28
    return Math.Min(parcelaAdicional, 6942.28);
}


double CalcularPLRBasica(double salario)
{
    double plrBasica = salario * 0.9 + 3343.04;
    // Limitando ao teto de R$ 17.933,79
    return Math.Min(plrBasica, 17933.79);
}

double CalcularPLR(double salario, double lucroLiquido, int colaboradores, double percentualIR)
{
    double plrBasica = CalcularPLRBasica(salario);
    double parcelaAdicional = CalcularParcelaAdicional(lucroLiquido, colaboradores);
    double plrSocial = CalcularPLRSocial(lucroLiquido, colaboradores);

    double totalPlr = CalcularTotalPLR(plrBasica, parcelaAdicional, plrSocial);
    double valorIR = CalcularIR(totalPlr, percentualIR);

    double plrLiquido = CalcularPLRLiquido(totalPlr, valorIR);

    return plrLiquido;
}

// var salario = ObterDadoConsole<double>("Digite o salário do colaborador:");
// var lucroLiquido = ObterDadoConsole<double>("Digite o lucro líquido da empresa:");
// var colaboradores = ObterDadoConsole<int>("Digite o número de colaboradores:");
// var percentualIR = ObterDadoConsole<double>("Digite o percentual de IR:");

// var relatorioPlr = CalcularPLR(salario, lucroLiquido, colaboradores, percentualIR);

// Console.WriteLine(relatorioPlr);

var num_chances = 3;

foreach (var arg in new[] { 1, 2, 3, 45, 100, 90, 8, 7 , 99, 65 })
{
    if (arg % 2 == 0) num_chances--;
}

var chancesRestante = num_chances;

//Console.WriteLine(chancesRestante);


var menuPrincipal = new Menu();
menuPrincipal.AdicionarOpcao(1, "Menu");
menuPrincipal.AdicionarOpcao(2, "Deveria ser 2");



var submenu = new MenuComSubMenu();
submenu.AdicionarOpcao(1, "Submenu");
submenu.AdicionarSubmenu(1, menuPrincipal);
submenu.ExibirMenu();
var opcao = submenu.ObterEscolha();

Console.WriteLine(opcao);