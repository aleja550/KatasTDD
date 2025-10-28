namespace CancionNavidad;

public class Estrofa
{
    public List<string> Lineas { get; }
    
    private static readonly string[] Valores = 
    {
        "first", "second", "third", "fourth", "fifth", "sixth",
        "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
    };

    
    public Estrofa(int numeroEstrofa)
    {
        Lineas = new List<string>();
        
        Lineas.Add($"On the {Valores[numeroEstrofa - 1]} day of Christmas");
        
        Lineas.Add("My true love sent to me:");
        
        Lineas.Add("A partridge in a pear tree.");
    }
}