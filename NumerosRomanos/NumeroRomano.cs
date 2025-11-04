namespace NumerosRomanos;

public static class NumeroRomano
{
    private static readonly (int numeroDecimal, string numeroRomano)[] MapeoDecimalARomano =
    [
        (1000, "M"),
        (500, "D"),
        (100, "C"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9,"IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    ];
    
    public static string Convertir(int numero)
    {
        var resultado = string.Empty;
        
        foreach (var (numeroDecimal, numeroRomano) in MapeoDecimalARomano)
        {
            while (numero >= numeroDecimal)
            {
                resultado += numeroRomano;
                numero -= numeroDecimal;
            }
        }
    
        return resultado;
    }
}
