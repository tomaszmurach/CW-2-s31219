using CW2_apbd;

class Program
{
    static void Main()
    {
        //Stworzenie kontenera danego typu
        var kontenerNaPlyny = new KontenerNaPlyny(300, 200, 1000, 10000, true);
        var kontenerNaGaz = new KontenerNaGaz(500, 600, 1000, 10000, 1013.25);
        var kontenerChlodniczy = new KontenerChlodniczy(123, 321, 997, 20000, "spozywcze", 0);
        
        
        //Załadowanie ładunku do danego kontenera
        kontenerNaPlyny.ZaladujKontener(4000);
        kontenerNaGaz.ZaladujKontener(4100);
        Produkt produkt = new Produkt("Banany", "spozywcze", 13.3);
        kontenerChlodniczy.ZaladujKontener(produkt,500);

        
        //Załadowanie kontenera na statek
        Kontenerowiec kontenerowiec = new Kontenerowiec("Titanic", 15, 333, 100000);
        kontenerowiec.ZaladujKontenerNaStatek(kontenerNaPlyny);
        kontenerowiec.ZaladujKontenerNaStatek(kontenerNaGaz);
        kontenerowiec.ZaladujKontenerNaStatek(kontenerChlodniczy);
        
        
        //Załadowanie listy kontenerów na statek
        var lista = new List<Kontener>();
        lista.Add(kontenerNaPlyny);
        lista.Add(kontenerNaGaz);
        Kontenerowiec kontenerowiec1 = new Kontenerowiec("Neptune", 25, 10, 50000);
        kontenerowiec1.ZaladujListeKontenerow(lista);
        
        
        //Usuniecie kontenera ze statku
        kontenerowiec1.UsunKontener("KON-G-2");
        
        
        //Rozładowanie kontenera
        kontenerNaGaz.OproznijLadunek();
        
        
        //Zastąpienie kontenera na statku o danym numerze innym kontenerem
        KontenerNaGaz kontenerNaGaz1 = new KontenerNaGaz(500, 600, 1000, 10000, 10000);
        kontenerowiec.ZastapKontener("KON-L-1",kontenerNaGaz1);
        
        
        //Możliwość przeniesienie kontenera między dwoma statkami
        Kontenerowiec.PrzeniesKontener(kontenerNaGaz1, kontenerowiec, kontenerowiec1);
        
        
        //Wypisanie informacji o danym kontenerze
        kontenerNaPlyny.WypiszInformacje();
        
        
        //Wypisanie informacji o danym statku i jego ładunku
        kontenerowiec1.WypiszInformacje();
        
        
        
        



    }
}
