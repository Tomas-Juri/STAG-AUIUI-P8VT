namespace Application.Frontend.Components.Organisms;

public partial class Layout
{
    private bool _collapseNavMenu = true;

    private string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu() => 
        _collapseNavMenu = !_collapseNavMenu;
}