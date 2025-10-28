using AwesomeAssertions;

namespace CancionNavidad;

public class CancionNavidadTest
{
    [Fact]
    public void Cancion_Debe_Tener_12_Estrofas()
    {
        //Arrange
        var cancion = new Cancion();
        
        //Act
        var cantidadEstrofas = cancion.Estrofas.Count;
        
        //Assert
        cantidadEstrofas.Should().Be(12);
    }
    
    [Fact]
    public void PrimeraEstrofa_Debe_Tener_3_Lineas()
    {
        //Arrange
        var cancion = new Cancion();
    
        //Act
        var cantidadLineas = cancion.Estrofas[0].Lineas.Count;
    
        //Assert
        cantidadLineas.Should().Be(3);
    }
    
    [Fact]
    public void PrimeraLinea_DeEstrofa1_Debe_Ser_OnTheFirstDayOfChristmas()
    {
        //Arrange
        var cancion = new Cancion();
        const string textoEsperado = "On the first day of Christmas";
    
        //Act
        var primeraLinea = cancion.Estrofas[0].Lineas[0];
    
        //Assert
        primeraLinea.Should().Be(textoEsperado);
    }
}