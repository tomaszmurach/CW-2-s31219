namespace CW2_apbd;

public class KontenerChlodniczy : Kontener
{
    public string TypProduktu { get; set; }
    public double Temperatura { get; set; }


    public KontenerChlodniczy(double wysokosc, double glebokosc, double wagaWlasna, double maxLadownosc,
        string typProduktu, double temperatura) : base(wysokosc, glebokosc, wagaWlasna, maxLadownosc)
    {
        TypProduktu = typProduktu;
        Temperatura = temperatura;
        NumerSeryjny = GenerujNumerSeryjny('C');
    }


    public void ZaladujKontener(Produkt produkt, double masa)
    {
        if (TypProduktu != produkt.TypProduktu)
        {
            throw new Exception(
                $"UWAGA[CHLODANIA] - Typ produktu ({produkt.TypProduktu}) nie zgadza sie z typem kontenera ({TypProduktu})");
        }

        if (Temperatura > produkt.MinimalnaTeperatura)
        {
            throw new Exception(
                $"UWAGA[CHLODANIA] - Temperatura w kontenerze wynosi: {Temperatura} stopni. Wymagana temperatura dla produktu: {produkt.Nazwa} wynosi: {produkt.MinimalnaTeperatura}");
        }

        base.ZaladujKontener(masa);
    }


    public override void WypiszInformacje()
    {
        base.WypiszInformacje();
        Console.WriteLine($"Typ transportowanych produktów: {TypProduktu}");
        Console.WriteLine($"Temperatura utrzymywana w kontenerze: {Temperatura}");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();
    }
}