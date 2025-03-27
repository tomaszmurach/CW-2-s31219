namespace CW2_apbd;

public class Kontenerowiec
{
    public string Nazwa { get; set; }
    public double MaxPredkosc { get; set; }
    public int MaxIloscKontenerow { get; set; }
    public double MaxWagaWszystkichKontenerowWTonach { get; set; }
    
    private List<Kontener> kontenery = new();

    
    public Kontenerowiec(string nazwa, double maxPredkosc, int maxIloscKontenerow,
        double maxWagaWszystkichKontenerowWTonach)
    {
        Nazwa = nazwa;
        MaxPredkosc = maxPredkosc;
        MaxIloscKontenerow = maxIloscKontenerow;
        MaxWagaWszystkichKontenerowWTonach = maxWagaWszystkichKontenerowWTonach;
    }

    
    
    public void ZaladujKontenerNaStatek(Kontener kontener)
    {
        if (kontenery.Count >= MaxIloscKontenerow)
        {
            throw new Exception(
                $"UWAGA[Kontenerowiec] - Przekroczono maksymalna ilość kontenerow na kontenerowcu: {Nazwa}!");
        }

        double aktualnaWagaLadunku = kontenery.Sum(k => k.MasaLadunku + k.WagaWlasna) / 1000.0;
        double wagaDodawanegoKontenera = (kontener.MasaLadunku + kontener.WagaWlasna) / 1000.0;

        if (aktualnaWagaLadunku + wagaDodawanegoKontenera > MaxWagaWszystkichKontenerowWTonach)
        {
            throw new Exception(
                $"UWAGA[Kontenerowiec] - Waga ladunku przekracza maksymalna ladownosc statku: {Nazwa}!");
        }

        kontenery.Add(kontener);
    }

    
    public void ZaladujListeKontenerow(IEnumerable<Kontener> kontenery)
    {
        foreach (var kontener in kontenery)
        {
            ZaladujKontenerNaStatek(kontener);
        }
    }

    public void UsunKontener(string numerSeryjny)
    {
        kontenery.RemoveAll(k => k.NumerSeryjny == numerSeryjny);
    }

    
    public void ZastapKontener(string numerSeryjny, Kontener kontener)
    {
        UsunKontener(numerSeryjny);
        ZaladujKontenerNaStatek(kontener);
    }

    
    public static void PrzeniesKontener(Kontener kontener, Kontenerowiec k1, Kontenerowiec k2)
    {
        k1.UsunKontener(kontener.NumerSeryjny);
        k2.ZaladujKontenerNaStatek(kontener);
    }


    public void WypiszInformacje()
    {
        double aktualnaWagaLadunku = kontenery.Sum(k => k.MasaLadunku + k.WagaWlasna) / 1000.0;
        
        Console.WriteLine($"Kontenerowiec: {Nazwa}");
        Console.WriteLine($"Maksymalna predkosc w wezlach: {MaxPredkosc}");
        Console.WriteLine($"Maksymalna dopuszczona ilosc kontenerow: {MaxIloscKontenerow}");
        Console.WriteLine($"Aktualna ilosc transportowanych kontenerow: {kontenery.Count}");
        Console.WriteLine($"Maksymalna waga transportowanych kontenerow w tonach: {MaxWagaWszystkichKontenerowWTonach}");
        Console.WriteLine($"Aktualna waga transportowanego ladunku w tonach: {aktualnaWagaLadunku}");
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Lista przewozonych na pokladzie kontenerow:");
        foreach (var k in kontenery)
            k.WypiszInformacje();
        Console.WriteLine();
    }
}