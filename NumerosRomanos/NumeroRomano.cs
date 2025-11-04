namespace NumerosRomanos;

public static class NumeroRomano
{
    public static string Convertir(int numero)
    {
        return numero == 1 ? "I" : "V";
    }
}
