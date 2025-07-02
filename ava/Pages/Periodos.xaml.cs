using ava.Models;
using System.Collections.ObjectModel;

namespace ava.Pages;
public partial class Periodos : ContentPage
{
    ObservableCollection<Periodo> periodos = new();

    public Periodos()
    {
        InitializeComponent();
        listaPeriodos.ItemsSource = periodos;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var lista = await App.Db.GetAllPeriodos();
        periodos.Clear();
        foreach (var p in lista)
            periodos.Add(p);
    }

    private async void OnInserirClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PeriodosInserirPages());
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var periodo = (sender as Button)?.BindingContext as Periodo;
        var editarPage = new PeriodosInserirPages
        {
            BindingContext = periodo
        };
        await Navigation.PushAsync(editarPage);
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        var periodo = (sender as Button)?.BindingContext as Periodo;
        bool confirmar = await DisplayAlert("Confirmação", $"Excluir '{periodo?.PerNome}'?", "Sim", "Não");

        if (confirmar && periodo != null)
        {
            await App.Db.DeletePeriodo(periodo.PerId);
            periodos.Remove(periodo);
        }
    }
}