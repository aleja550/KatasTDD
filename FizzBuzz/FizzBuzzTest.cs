using AwesomeAssertions;
using Xunit.Abstractions;

namespace FizzBuzz;

public class FizzBuzzTest
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
        lineas.Length.Should().Be(100);
    }

    private void ImprimirNumeros()
    {
        throw new NotImplementedException();
    }

    // [Theory]
    // [InlineData(1)]
    // [InlineData(3)]
    // [InlineData(6)]
    // [InlineData(10)]
    // public void Validar_Numero_Multiplo_De_Tres(int numero)
    // {
    //     
    // }
}