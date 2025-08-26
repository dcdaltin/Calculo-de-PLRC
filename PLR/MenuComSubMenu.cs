class MenuComSubMenu : Menu
{
    Dictionary<int, Menu> _submenus;

    public MenuComSubMenu() : base()
    {
        _submenus = new Dictionary<int, Menu>();
    }

    public void AdicionarSubmenu(int chave, Menu submenu)
    {
        _submenus.Add(chave, submenu);
    }

    public override void ExibirMenu()
    {
        base.ExibirMenu();
        var escolha = ObterEscolha();
        if (_submenus.ContainsKey(escolha))
        {
            _submenus[escolha].ExibirMenu();
        }
    }

    public override int ObterEscolha()
    {
        //base.ExibirMenu();
        var escolha = base.ObterEscolha();
        if (_submenus.ContainsKey(escolha))
        {
            _submenus[escolha].ExibirMenu();
        }
        return escolha;
    }
}