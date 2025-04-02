namespace ava.Pages;

public partial class Periodos : ContentPage
{
	public Periodos()
	{
		InitializeComponent();
	}
    private async void OnInserirClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PeriodosInserirPages());
    }
}