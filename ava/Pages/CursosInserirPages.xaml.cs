namespace ava.Pages;

public partial class CursosInserirPages : ContentPage
{
	public CursosInserirPages()
	{
		InitializeComponent();
	}
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volta para a tela anterior
    }
}