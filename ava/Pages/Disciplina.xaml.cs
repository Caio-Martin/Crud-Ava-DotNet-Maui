namespace ava.Pages;

public partial class Disciplina : ContentPage
{
	public Disciplina()
	{
		InitializeComponent();
	}
    private async void OnInserirClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DisciplinaInserirPages());
    }
}