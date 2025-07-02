using ava.Models;

namespace ava.Pages;

public partial class PeriodosInserirPages : ContentPage
{
	public PeriodosInserirPages()
	{
		InitializeComponent();
	}


 protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is Periodo p)
        {
            entryNome.Text = p.PerNome;
            entrySigla.Text = p.PerSigla;
            entryObs.Text = p.PerObservacoes;
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNome.Text))
        {
            await DisplayAlert("Erro", "Nome do período é obrigatório.", "OK");
            return;
        }

        var periodo = (BindingContext as Periodo) ?? new Periodo();

        periodo.PerNome = entryNome.Text;
        periodo.PerSigla = entrySigla.Text;
        periodo.PerObservacoes = entryObs.Text;

        if (periodo.PerId > 0)
            await App.Db.Update(periodo);
        else
            await App.Db.Insert(periodo);

        await DisplayAlert("Sucesso", "Período salvo com sucesso.", "OK");
        await Navigation.PopAsync();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}