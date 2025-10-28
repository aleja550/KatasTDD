using AwesomeAssertions;
using Xunit.Abstractions;

namespace FizzBuzz;

public class FizzBuzzTest(ITestOutputHelper output)
{
    [Fact]
    
    public void Debe_Imprimir_CienNumeros()
    {
        //Arrange
        var captura = new StringWriter();
        Console.SetOut(captura);
 
        //Act
        ImprimirNumeros();
        
        //Assert 
        var salida = captura.ToString();
        var lineas = salida.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        
        output.WriteLine(salida);
        
        lineas.Length.Should().Be(100);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(12)]
    public void Validar_Numero_Multiplo_De_Tres(int numero)
    {
        //Act
        var resultado = EsMultiploDeTres(numero);
    
        //Assert
        resultado.Should().BeTrue();
    }
    
    [Fact]
    public void Debe_Imprimir_Fizz_CuandoSea_MultiploDeTres()
    {
        //Arrange
        var captura = new StringWriter();
        Console.SetOut(captura);
 
        //Act
        ImprimirNumeros();
        
        //Assert 
        var salida = captura.ToString();
        var lineas = salida.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        
        output.WriteLine(salida);
        
        lineas[2].Should().Be("Fizz");
        lineas[5].Should().Be("Fizz");
        lineas[8].Should().Be("Fizz");
        lineas[11].Should().Be("Fizz");
    }
    
    [Theory]
    [InlineData(5)]
    [InlineData(15)]
    [InlineData(25)]
    [InlineData(35)]
    public void Validar_Numero_Multiplo_De_Cinco(int numero)
    {
        //Act
        var resultado = EsMultiploDeCinco(numero);
    
        //Assert
        resultado.Should().BeTrue();
    }
    
    [Fact]
    public void Debe_Imprimir_Buzz_CuandoSea_MultiploDeCinco()
    {
        //Arrange
        var captura = new StringWriter();
        Console.SetOut(captura);
 
        //Act
        ImprimirNumeros();
        
        //Assert 
        var salida = captura.ToString();
        var lineas = salida.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        
        output.WriteLine(salida);
        
        lineas[4].Should().Be("Buzz");
        lineas[9].Should().Be("Buzz");
        lineas[19].Should().Be("Buzz");
        lineas[24].Should().Be("Buzz");
    }
    
    private static void ImprimirNumeros()
    {
        for (var i = 1; i <= 100; i++)
        {
            Console.WriteLine(EsMultiploDeTres(i) 
                ? "Fizz" 
                : EsMultiploDeCinco(i)
                ? "Buzz" : i.ToString());
        }
    }
    
    private static bool EsMultiploDeTres(int numero) => numero % 3 == 0;

    private static bool EsMultiploDeCinco(int numero) => numero % 5 == 0;
}