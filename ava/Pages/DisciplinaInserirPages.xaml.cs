using ava.Models;

namespace ava.Pages;

public partial class DisciplinaInserirPages : ContentPage
{
    private List<Curso> cursosDisponiveis;

    public DisciplinaInserirPages()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        cursosDisponiveis = await App.Db.GetAllCursos();
        pickerCurso.ItemsSource = cursosDisponiveis;

        if (BindingContext is Disciplina d)
        {
            entryNomeDisciplina.Text = d.DisNome;
            entrySiglaDisciplina.Text = d.DisSigla;
            editorDescricaoDisciplina.Text = d.DisObservacoes;
            entryCargaHorariaDisciplina.Text = d.DisSigla;

            var cursoSelecionado = cursosDisponiveis.FirstOrDefault(c => c.CurId == d.DisCursoId); 
            if (cursoSelecionado != null)
                pickerCurso.SelectedItem = cursoSelecionado;
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNomeDisciplina.Text))
        {
            await DisplayAlert("Erro", "Nome da disciplina é obrigatório.", "OK");
            return;
        }

        var disciplina = (BindingContext as Disciplina) ?? new Disciplina();

        disciplina.DisNome = entryNomeDisciplina.Text;
        disciplina.DisSigla = entrySiglaDisciplina.Text;
        disciplina.DisSigla = entryCargaHorariaDisciplina.Text;
        disciplina.DisCursoId = (pickerCurso.SelectedItem as Curso)?.CurId ?? 0;
        disciplina.DisObservacoes = editorDescricaoDisciplina.Text;


        if (disciplina.DisId > 0)
            await App.Db.Update(disciplina);
        else
            await App.Db.Insert(disciplina);

        await DisplayAlert("Sucesso", "Disciplina salva com sucesso.", "OK");
        await Navigation.PopAsync();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
