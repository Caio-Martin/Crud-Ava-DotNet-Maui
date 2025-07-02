using ava.Models;

namespace ava.Pages;

public partial class CursosInserirPages : ContentPage
{
    public CursosInserirPages()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is Curso c)
        {
            entryNomeCurso.Text = c.CurNome;
            editorDescricaoCurso.Text = c.CurDescricao;
            entrySiglaCurso.Text = c.CurSigla;
            entryCargaHorariaCurso.Text = c.CurCargaHoraria;
            pickerNivel.SelectedItem = c.CurNivel;
            pickerPeriodo.SelectedItem = c.CurPeriodo;
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNomeCurso.Text))
        {
            await DisplayAlert("Erro", "O nome do curso é obrigatório.", "OK");
            return;
        }

        var curso = (BindingContext as Curso) ?? new Curso();

        curso.CurNome = entryNomeCurso.Text;
        curso.CurDescricao = editorDescricaoCurso.Text;
        curso.CurSigla = entrySiglaCurso.Text;
        curso.CurSigla = entrySiglaCurso.Text;
        curso.CurCargaHoraria = entryCargaHorariaCurso.Text;
        curso.CurNivel = pickerNivel.SelectedItem?.ToString();
        curso.CurPeriodo = pickerPeriodo.SelectedItem?.ToString();

        if (curso.CurId > 0)
            await App.Db.Update(curso);
        else
            await App.Db.Insert(curso);

        await DisplayAlert("Sucesso", "Curso salvo com sucesso.", "OK");
        await Navigation.PopAsync();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
