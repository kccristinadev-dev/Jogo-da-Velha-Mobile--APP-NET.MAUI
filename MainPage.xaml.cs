using Microsoft.Maui.Controls;

namespace JogoDaVelhaMaui;

public partial class MainPage : ContentPage
{
    private string jogada = "X";
    private Button[] campos;

    private readonly int[,] vitorias = new int[,]
    {
        {0,1,2},
        {3,4,5},
        {6,7,8},
        {0,3,6},
        {1,4,7},
        {2,5,8},
        {0,4,8},
        {2,4,6}
    };

    public MainPage()
    {
        InitializeComponent();

        campos = new Button[]
        {
            campo1_0, campo1_1, campo1_2,
            campo2_0, campo2_1, campo2_2,
            campo3_0, campo3_1, campo3_2
        };
    }

    private void Jogar(object sender, EventArgs e)
    {
        if (sender is not Button bnt)
            return;

        if (!string.IsNullOrWhiteSpace(bnt.Text))
            return;

        bnt.Text = jogada;
        jogada = jogada == "X" ? "O" : "X";

        VerificarVitoria();
    }

    private async void VerificarVitoria()
    {
        for (int i = 0; i < vitorias.GetLength(0); i++)
        {
            int a = vitorias[i, 0];
            int b = vitorias[i, 1];
            int c = vitorias[i, 2];

            if (!string.IsNullOrWhiteSpace(campos[a].Text)
                && campos[a].Text == campos[b].Text
                && campos[b].Text == campos[c].Text)
            {
                await DisplayAlert("Vitória", $"Jogador {campos[a].Text} venceu!", "OK");
                ReiniciarTabuleiro();
                return;
            }
        }
    }

    private void ReiniciarTabuleiro()
    {
        foreach (var c in campos)
        {
            c.Text = string.Empty;
            c.IsEnabled = true;
        }

        jogada = "X";
    }
}
