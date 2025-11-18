using System.Text;
using AwesomeAssertions;

namespace WordWrap;

public class WordWrapTests
{
    [Fact]
    public void a()
    {
        var result = Wrap("", 1);

        result.Should().Be("");
    }

    [Fact]
    public void b()
    {
        var result = Wrap("this", 10);

        result.Should().Be("this");
    }   
    
    [Fact]
    public void c()
    {
        var result = Wrap("word", 2);

        result.Should().Be("wo\nrd");
    } 
    
    [Fact]
    public void d()
    {
        var result = Wrap("abcdefghij", 3);

        result.Should().Be("abc\ndef\nghi\nj");
    }
    
    [Fact]
    public void e()
    {
        var result = Wrap("word word", 3);

        result.Should().Be("wor\nd\nwor\nd");
    }
    
    [Fact]
    public void f()
    {
        var result = Wrap("word word", 6);

        result.Should().Be("word\nword");
    }    
    
    [Fact]
    public void f2()
    {
        var result = Wrap("word word", 5);

        result.Should().Be("word\nword");
    }
    
    [Fact]
    public void g()
    {
        var result = Wrap("word word word", 6);

        result.Should().Be("word\nword\nword");
    }
    
    [Fact]
    public void h()
    {
        var result = Wrap("word word word", 11);

        result.Should().Be("word word\nword");
    }
    
    // (null → constant) 
    // private static string Wrap(string texto, int numeroColumnas)
    // {
    //     return string.Empty;
    // }
    
    
    // (constant → scalar) 
    // private static string Wrap(string texto, int numeroColumnas)
    // {
    //     if (string.IsNullOrEmpty(texto))
    //         return "";
    //     
    //     return texto;
    // }
    
    
    // + statement → statements + scalar → array 
    // private static string Wrap(string texto, int numeroColumnas)
    // {
    //     if (string.IsNullOrEmpty(texto))
    //         return "";
    //     
    //     if (texto.Length <= numeroColumnas)
    //         return texto;
    //     
    //     var primeraParte = texto.Substring(0, numeroColumnas);
    //     var segundaParte = texto.Substring(numeroColumnas);
    //     
    //     return primeraParte + "\n" + segundaParte;
    // }
    
    //statement → recursion
    // private static string Wrap(string texto, int numeroColumnas)
    // {
    //     if (string.IsNullOrEmpty(texto))
    //         return "";
    //     
    //     if (texto.Length <= numeroColumnas)
    //         return texto;
    //     
    //     var primeraParte = texto.Substring(0, numeroColumnas);
    //     var resto = texto.Substring(numeroColumnas);
    //     
    //     return primeraParte + "\n" + Wrap(resto, numeroColumnas);
    // }
    
    //expression → function
    private static string Wrap(string texto, int numeroColumnas)
    {
        if (string.IsNullOrEmpty(texto))
            return "";
        
        if (texto.Length <= numeroColumnas)
            return texto;
        
        var puntoDeDivision = numeroColumnas;
        
        for (var i = numeroColumnas - 1; i >= 0; i--)
        {
            if (texto[i] == ' ')
            {
                puntoDeDivision = i;
                break;
            }
        }
        
        var primeraParte = texto.Substring(0, puntoDeDivision);
        var resto = texto.Substring(puntoDeDivision);
        
        resto = resto.TrimStart(' ');
        
        return primeraParte + "\n" + Wrap(resto, numeroColumnas);
    }
}