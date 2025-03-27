namespace CW2_apbd;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    private bool CzyLadunekNiebezpieczny { get; set; }


    public KontenerNaPlyny(double wysokosc, double glebokosc, double wagaWlasna, double maxLadownosc,
        bool czyLadunekNiebezpieczny) : base(wysokosc, glebokosc, wagaWlasna, maxLadownosc)
    {
        CzyLadunekNiebezpieczny = czyLadunekNiebezpieczny;
        NumerSeryjny = GenerujNumerSeryjny('L');
    }

    public override void ZaladujKontener(double masa)
    {
        double limit = MaxLadownosc;
        if (CzyLadunekNiebezpieczny)
        {
            limit *= 0.5;
        }
        else
        {
            limit *= 0.9;
        }

        if (masa + MasaLadunku > limit)
        {
            PoinformujOProbieWykonaniaNiebezpiecznejOperacji(NumerSeryjny);
        }

        base.ZaladujKontener(masa);
    }

    public override void WypiszInformacje()
    {
        base.WypiszInformacje();
        if (CzyLadunekNiebezpieczny)
        {
            Console.WriteLine("Ladunek niebezpieczny: TAK");
        }
        else
        {
            Console.WriteLine("Ladunek niebezpieczny: NIE");
        }

        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();
    }

    public void PoinformujOProbieWykonaniaNiebezpiecznejOperacji(string numerSeryjny)
    {
        Console.WriteLine(
            "UWAGA[PLYNY] - Doszlo do przekroczenia bezpiecznego limitu dla tego typu ladunku. Numer seryjny konteneru, którego sytuacja dotyczy: " +
            numerSeryjny);
    }
}