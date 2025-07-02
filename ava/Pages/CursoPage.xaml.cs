using ava.Models;
using System.Collections.ObjectModel;

namespace ava.Pages;

public partial class CursoPage : ContentPage
{
    ObservableCollection<Curso> cursos = new();

    public CursoPage()
    {
        InitializeComponent();
        listaCursos.ItemsSource = cursos;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarCursos();
    }

    private async Task CarregarCursos()
    {
        var lista = await App.Db.GetAllCursos();
        cursos.Clear();
        foreach (var c in lista)
            cursos.Add(c);
    }

    private async void OnInserirClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CursosInserirPages());
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var curso = (sender as Button)?.BindingContext as Curso;
        var editarPage = new CursosInserirPages
        {
            BindingContext = curso
        };
        await Navigation.PushAsync(editarPage);
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        var curso = (sender as Button)?.BindingContext as Curso;
        bool confirmar = await DisplayAlert("Confirmação", $"Excluir '{curso?.CurNome}'?", "Sim", "Não");

        if (confirmar && curso != null)
        {
            await App.Db.DeleteCurso(curso.CurId);
            cursos.Remove(curso);
        }
    }
}
