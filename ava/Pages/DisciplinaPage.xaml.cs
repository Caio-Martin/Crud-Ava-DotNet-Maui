using ava.Models;
using System.Collections.ObjectModel;

namespace ava.Pages;

public partial class DisciplinaPage : ContentPage
{
    ObservableCollection<ava.Models.Disciplina> disciplinas = new();

    public DisciplinaPage()
    {
        InitializeComponent();
        listaDisciplinas.ItemsSource = disciplinas;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarDisciplinas();
    }

    private async Task CarregarDisciplinas()
    {
        var lista = await App.Db.GetAll();
        disciplinas.Clear();
        foreach (var d in lista)
            disciplinas.Add(d);
    }

    private async void OnInserirClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DisciplinaInserirPages());
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var disciplina = (sender as Button)?.BindingContext as ava.Models.Disciplina;
        var editarPage = new DisciplinaInserirPages
        {
            BindingContext = disciplina
        };
        await Navigation.PushAsync(editarPage);
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        var disciplina = (sender as Button)?.BindingContext as ava.Models.Disciplina;
        bool confirmar = await DisplayAlert("Confirmação", $"Excluir '{disciplina?.DisNome}'?", "Sim", "Não");

        if (confirmar && disciplina != null)
        {
            await App.Db.Delete(disciplina.DisId);
            disciplinas.Remove(disciplina);
        }
    }
}
