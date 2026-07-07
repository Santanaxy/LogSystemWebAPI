using MudBlazor;

namespace SISTEMALOGISTICA.WEB.Themes
{
    public static class CustomTheme
    {
        
        public static MudTheme Theme { get; } = new MudTheme
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "rgba(74,92,246,1)",
                Secondary = "rgba(255,255,255,1)",
                Background = "rgba(20, 51, 118, 0.94)",
                Surface = "rgba(255,255,255,1)",
                Error = "rgba(220,53,42,1)",
                TextPrimary = "rgba(255, 255, 255, 1)",
                TextSecondary = "rgba(107,114,128,1)",
                 
            },
        };  
    }
}
