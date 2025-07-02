using ava.Models;
using System.Collections.ObjectModel;

namespace ava.Pages;

public partial class UsuariosPage : ContentPage
{
    ObservableCollection<Usuario> usuarios = new();
    List<Usuario> todosUsuarios = new(); 

    public UsuariosPage()
    {
        InitializeComponent();
        listaUsuarios.ItemsSource = usuarios;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        todosUsuarios = await App.Db.GetAllUsuarios();
        AtualizarLista(todosUsuarios);
    }

    private void AtualizarLista(IEnumerable<Usuario> lista)
    {
        usuarios.Clear();
        foreach (var u in lista)
            usuarios.Add(u);
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = e.NewTextValue?.ToLower() ?? "";
        var filtrados = todosUsuarios
            .Where(u => u.UsuNome?.ToLower().Contains(filtro) == true)
            .ToList();

        AtualizarLista(filtrados);
    }

    private async void OnInserirClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UsuariosInserirPage());
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var usuario = (sender as Button)?.BindingContext as Usuario;
        var editarPage = new UsuariosInserirPage
        {
            BindingContext = usuario
        };
        await Navigation.PushAsync(editarPage);
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        var usuario = (sender as Button)?.BindingContext as Usuario;
        bool confirmar = await DisplayAlert("Confirmação", $"Excluir '{usuario?.UsuNome}'?", "Sim", "Cancelar");

        if (confirmar && usuario != null)
        {
            await App.Db.DeleteUsuario(usuario.UsuId);
            todosUsuarios.Remove(usuario);
            AtualizarLista(todosUsuarios);
        }
    }
}
