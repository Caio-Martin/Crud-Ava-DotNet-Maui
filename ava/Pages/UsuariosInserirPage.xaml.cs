using ava.Models;

namespace ava.Pages;

public partial class UsuariosInserirPage : ContentPage
{
    public UsuariosInserirPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is Usuario u)
        {
            entryNome.Text = u.UsuNome;
            entrySenha.Text = u.UsuSenha;
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNome.Text) || string.IsNullOrWhiteSpace(entrySenha.Text))
        {
            await DisplayAlert("Erro", "Preencha todos os campos", "OK");
            return;
        }

        var usuario = (BindingContext as Usuario) ?? new Usuario();

        usuario.UsuNome = entryNome.Text;
        usuario.UsuSenha = entrySenha.Text;

        if (usuario.UsuId > 0)
            await App.Db.UpdateUsuario(usuario);  
        else
            await App.Db.Insert(usuario); 

        await DisplayAlert("Sucesso", "Usuário salvo com sucesso.", "OK");
        await Navigation.PopAsync();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
