using AwesomeAssertions;

namespace NumerosRomanos;

public class NumeroRomanoTests
{
    [Fact]
    public void Convertir1_Debe_RetornarI()
    {
        // Arrange
        var numero = 1;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("I");
    }
    
    [Fact]
    public void Convertir5_Debe_RetornarV()
    {
        // Arrange
        var numero = 5;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("V");
    }
}