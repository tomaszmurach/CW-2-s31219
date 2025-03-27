namespace CW2_apbd;

public class Produkt
{
    public string Nazwa { get; set; }
    public string TypProduktu { get; set; }
    public double MinimalnaTeperatura { get; set; }

    public Produkt(string nazwa, string typProduktu, double minimalnaTeperatura)
    {
        Nazwa = nazwa;
        TypProduktu = typProduktu;
        MinimalnaTeperatura = minimalnaTeperatura;
    }
}