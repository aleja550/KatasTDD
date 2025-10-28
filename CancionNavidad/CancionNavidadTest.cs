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
    
    [Fact]
    public void SegundaLinea_DeEstrofa1_Debe_Ser_MyTrueLoveSentToMe()
    {
        //Arrange
        var cancion = new Cancion();
        const string textoEsperado = "My true love sent to me:";
    
        //Act
        var segundaLinea = cancion.Estrofas[0].Lineas[1];
    
        //Assert
        segundaLinea.Should().Be(textoEsperado);
    }
    
    [Fact]
    public void TerceraLinea_DeEstrofa1_Debe_Ser_APartridgeInAPearTree()
    {
        //Arrange
        var cancion = new Cancion();
        const string textoEsperado = "A partridge in a pear tree.";
    
        //Act
        var terceraLinea = cancion.Estrofas[0].Lineas[2];
    
        //Assert
        terceraLinea.Should().Be(textoEsperado);
    }
    
    [Fact]
    public void PrimeraEstrofa_Debe_Tener_Contenido_Completo()
    {
        //Arrange
        var cancion = new Cancion();
        var contenidoEsperado = new List<string>
        {
            "On the first day of Christmas",
            "My true love sent to me:",
            "A partridge in a pear tree."
        };
    
        //Act
        var contenidoEstrofa = cancion.Estrofas[0].Lineas;
    
        //Assert
        contenidoEstrofa.Should().BeEquivalentTo(contenidoEsperado);
    }
    
    [Fact]
    public void SegundaEstrofa_Debe_Tener_4_Lineas()
    {
        //Arrange
        var cancion = new Cancion();
    
        //Act
        var cantidadLineas = cancion.Estrofas[1].Lineas.Count;
    
        //Assert
        cantidadLineas.Should().Be(4);
    }
    
    [Fact]
    public void SegundaEstrofa_Debe_Tener_Contenido_Completo()
    {
        //Arrange
        var cancion = new Cancion();
        var contenidoEsperado = new List<string>
        {
            "On the second day of Christmas",
            "My true love sent to me:",
            "Two turtle doves and",
            "A partridge in a pear tree."
        };
    
        //Act
        var contenidoEstrofa = cancion.Estrofas[1].Lineas;
    
        //Assert
        contenidoEstrofa.Should().BeEquivalentTo(contenidoEsperado);
    }
    
    [Theory]
    [InlineData(0, "first")]
    [InlineData(1, "second")]
    [InlineData(2, "third")]
    [InlineData(5, "sixth")]
    [InlineData(11, "twelfth")]
    public void TodasLasEstrofas_Deben_Empezar_Con_OnTheDayOfChristmas(int indiceEstrofa, string valor)
    {
        //Arrange
        var cancion = new Cancion();
        var primeraLineaEsperada = $"On the {valor} day of Christmas";
    
        //Act
        var primeraLinea = cancion.Estrofas[indiceEstrofa].Lineas[0];
    
        //Assert
        primeraLinea.Should().Be(primeraLineaEsperada);
    }
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(11)]
    public void TodasLasEstrofas_Deben_Tener_MyTrueLoveSentToMe_ComoSegundaLinea(int indiceEstrofa)
    {
        //Arrange
        var cancion = new Cancion();
        var segundaLineaEsperada = "My true love sent to me:";
    
        //Act
        var segundaLinea = cancion.Estrofas[indiceEstrofa].Lineas[1];
    
        //Assert
        segundaLinea.Should().Be(segundaLineaEsperada);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(11)]
    public void TodasLasEstrofas_Deben_Terminar_Con_APartridgeInAPearTree(int indiceEstrofa)
    {
        //Arrange
        var cancion = new Cancion();
        var ultimaLineaEsperada = "A partridge in a pear tree.";
    
        //Act
        var estrofa = cancion.Estrofas[indiceEstrofa];
        var ultimaLinea = estrofa.Lineas[estrofa.Lineas.Count - 1];
    
        //Assert
        ultimaLinea.Should().Be(ultimaLineaEsperada);
    }
}