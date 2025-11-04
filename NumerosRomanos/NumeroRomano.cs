namespace NumerosRomanos;

public static class NumeroRomano
{
    public static string Convertir(int numero)
    {
        return numero switch
        {
            1 => "I",
            2 => "V",
            _ => "X"
        };
    }
}
