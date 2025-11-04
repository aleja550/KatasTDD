namespace NumerosRomanos;

public static class NumeroRomano
{
    public static string Convertir(int numero)
    {
        return numero switch
        {
            1 => "I",
            2 => "II",
            5 => "V",
            10 => "X",
            50 => "L",
            100 => "C",
            500 => "D",
            1000 => "M",
            _ => throw new ArgumentOutOfRangeException(nameof(numero), numero, null)
        };
    }
}
