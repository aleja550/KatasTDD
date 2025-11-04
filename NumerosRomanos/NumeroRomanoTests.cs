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
    
    [Fact]
    public void Convertir10_Debe_RetornarX()
    {
        // Arrange
        var numero = 10;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("X");
    }
    
    [Fact]
    public void Convertir50_Debe_RetornarL()
    {
        // Arrange
        var numero = 50;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("L");
    }
    
    [Fact]
    public void Convertir100_Debe_RetornarC()
    {
        // Arrange
        var numero = 100;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("C");
    }
    
    [Fact]
    public void Convertir500_Debe_RetornarD()
    {
        // Arrange
        var numero = 500;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("D");
    }
    
    [Fact]
    public void Convertir1000_Debe_RetornarM()
    {
        // Arrange  
        var numero = 1000;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("M");
    }
    
    [Fact]
    public void Convertir2_Debe_RetornarII()
    {
        // Arrange  
        var numero = 2;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("II");
    }
    
    [Fact]
    public void Convertir3_Debe_RetornarIII()
    {
        // Arrange  
        var numero = 3;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("III");
    }
    
    [Fact]
    public void Convertir6_Debe_RetornarVI()
    {
        // Arrange  
        var numero = 6;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("VI");
    }
    
    [Fact]
    public void Convertir7_Debe_RetornarVII()
    {
        // Arrange  
        var numero = 7;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("VII");
    }
    
    [Fact]
    public void Convertir8_Debe_RetornarVIII()
    {
        // Arrange  
        var numero = 8;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("VIII");
    }
    
    [Fact]
    public void Convertir4_Debe_RetornarIV()
    {
        // Arrange  
        var numero = 4;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("IV");
    }
    
    [Fact]
    public void Convertir9_Debe_RetornarIX()
    {
        // Arrange  
        var numero = 9;

        // Act
        var resultado = NumeroRomano.Convertir(numero);

        // Assert
        resultado.Should().Be("IX");
    }
    
    
    // 🔴  🟢  🔵 
}