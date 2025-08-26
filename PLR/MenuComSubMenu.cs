class MenuComSubMenu : Menu
{
    Dictionary<int, Menu> _submenus;
    int _submenuSelecionado;
    const int NENHUM_SUBMENU = -1;

    public MenuComSubMenu() : base()
    {
        _submenus = new Dictionary<int, Menu>();
        _submenuSelecionado = NENHUM_SUBMENU;
    }

    public void AdicionarSubmenu(int chave, Menu submenu)
    {
        _submenus.Add(chave, submenu);
    }

    public override void ExibirMenu()
    {
        base.ExibirMenu();
        var escolha = base.ObterEscolha();
        if (_submenus.ContainsKey(escolha))
        {
            _submenuSelecionado = escolha;
            _submenus[escolha].ExibirMenu();
        }
    }

    public override int ObterEscolha()
    {
        if (_submenuSelecionado == NENHUM_SUBMENU)
        {
            ExibirMenu();
        }

        return _submenus[_submenuSelecionado].ObterEscolha();
    }
}