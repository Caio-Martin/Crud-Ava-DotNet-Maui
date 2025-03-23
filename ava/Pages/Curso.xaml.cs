namespace ava.Pages;

public partial class Curso : ContentPage
{
	public Curso()
	{
		InitializeComponent();
	}
    private async void OnInserirClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CursosInserirPages());
    }
}