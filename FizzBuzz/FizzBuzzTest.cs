using AwesomeAssertions;
using Xunit.Abstractions;

namespace FizzBuzz;

public class FizzBuzzTest(ITestOutputHelper output)
{
    [Fact]
    
    public void Debe_Imprimir_CienNumeros()
    {
        //Act
        var lineas = ObtenerLineasDeImpresion();
        
        //Assert
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
        var resultado = FizzBuzz.EsMultiploDeTres(numero);
    
        //Assert
        resultado.Should().BeTrue();
    }
    
    [Fact]
    public void Debe_Imprimir_Fizz_CuandoSea_MultiploDeTres()
    {
        //Act
        var lineas = ObtenerLineasDeImpresion();
        
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
        var resultado = FizzBuzz.EsMultiploDeCinco(numero);
    
        //Assert
        resultado.Should().BeTrue();
    }
    
    [Fact]
    public void Debe_Imprimir_Buzz_CuandoSea_MultiploDeCinco()
    {
        //Act
        var lineas = ObtenerLineasDeImpresion();
        
        lineas[4].Should().Be("Buzz");
        lineas[9].Should().Be("Buzz");
        lineas[19].Should().Be("Buzz");
        lineas[24].Should().Be("Buzz");
    }
    
    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    [InlineData(60)]
    public void Validar_Numero_Multiplo_De_Tres_Y_Cinco(int numero)
    {
        //Act
        var resultado = FizzBuzz.EsMultiploDeAmbos(numero);
    
        //Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void Debe_Imprimir_FizzBuzz_CuandoSea_MultiploDeTres_Y_Cinco()
    {
        //Act
        var lineas = ObtenerLineasDeImpresion();
    
        lineas[14].Should().Be("FizzBuzz");  
        lineas[29].Should().Be("FizzBuzz"); 
        lineas[44].Should().Be("FizzBuzz");  
        lineas[59].Should().Be("FizzBuzz");
    }
    
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(4, "4")]
    [InlineData(7, "7")]
    public void Debe_Imprimir_Numeros_Normales_SinReemplazar(int numero, string esperado)
    {
        //Act
        var resultado = FizzBuzz.ObtenerValor(numero);
    
        //Assert
        resultado.Should().Be(esperado);
    }
    
    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(7, "7")]
    public void ObtenerValor_Debe_Retornar_Valor_Correcto(int numero, string esperado)
    {
        //Act
        var resultado = FizzBuzz.ObtenerValor(numero);
        
        //Assert
        resultado.Should().Be(esperado);
    }
    
    
    private string[] ObtenerLineasDeImpresion()
    {
        var captura = new StringWriter();
        Console.SetOut(captura);
        
        FizzBuzz.Imprimir();
        
        var salida = captura.ToString();
        output.WriteLine(salida);
        
        return salida.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
    }
}