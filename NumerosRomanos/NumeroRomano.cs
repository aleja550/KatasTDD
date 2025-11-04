namespace NumerosRomanos;

public static class NumeroRomano
{
    public static string Convertir(int numero)
    {
        if (numero == 1)
            return "I";

        if (numero == 2)
            return "V";

        return "X";
    }
}
