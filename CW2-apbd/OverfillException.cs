namespace CW2_apbd;

public class OverfillException : Exception
{
    public OverfillException(Kontener kontener)
        : base($"UWAGA - Masa ładunku przekracza pojemnosc kontenera o numerze seryjnym: {kontener.NumerSeryjny}")
    {
    }
}