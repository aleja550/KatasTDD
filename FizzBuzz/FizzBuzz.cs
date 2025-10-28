namespace FizzBuzz;

public static class FizzBuzz
{
    public static void Imprimir()
    {
        for (var i = 1; i <= 100; i++)
        {
            Console.WriteLine(ObtenerValor(i));
        }
    }
    
    public static string ObtenerValor(int numero)
    {
        if (EsMultiploDeAmbos(numero)) return "FizzBuzz";
    
        if (EsMultiploDeTres(numero)) return "Fizz";
    
    
        return EsMultiploDeCinco(numero) ? "Buzz" : numero.ToString();
    }
    
    public static bool EsMultiploDeTres(int numero) => numero % 3 == 0;
    public static bool EsMultiploDeCinco(int numero) => numero % 5 == 0;
    public static bool EsMultiploDeAmbos(int numero) => EsMultiploDeTres(numero) && EsMultiploDeCinco(numero);
}