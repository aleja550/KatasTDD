using AwesomeAssertions;
using Xunit.Abstractions;

namespace FizzBuzz;

public class FizzBuzzTest(ITestOutputHelper output)
{
    [Fact]
    public void Debe_Imprimir_Numeros_DelUnoAl100()
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
        
        var numerosEsperados = Enumerable.Range(1, 100).Select(n => n.ToString()).ToArray();

        lineas.Length.Should().Be(100);
        lineas.Should().BeEquivalentTo(numerosEsperados, options => options.WithStrictOrdering());
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
    
    private void ImprimirNumeros()
    {
        for (var i = 1; i <= 100; i++)
        {
            Console.WriteLine(i);
        }
    }
    
    private bool EsMultiploDeTres(int numero) => numero % 3 == 0;
}