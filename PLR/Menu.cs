class Menu
{
    Dictionary<int, string> _opcoes;
    public Menu()
    {
        _opcoes = new Dictionary<int, string>();
        _opcoes.Add(0, "Sair");
    }
    public void AdicionarOpcao(int chave, string descricao)
    {
        _opcoes.Add(chave, descricao);
    }
    public virtual void ExibirMenu()
    {
        foreach (var opcao in _opcoes)
        {
            Console.WriteLine($"{opcao.Key}: {opcao.Value}");
        }
    }
    public virtual int ObterEscolha()
    {
        Console.WriteLine("Digite a opção desejada:");
        var escolha = Console.ReadLine();
        if (int.TryParse(escolha, out int chave) && _opcoes.ContainsKey(chave))
        {
            return chave;
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            ExibirMenu();
            return ObterEscolha();
        }
    }

}