namespace CancionNavidad;

public class Estrofa
{
    public List<string> Lineas { get; }
    
    private static readonly string[] Valores =
    [
        "first", "second", "third", "fourth", "fifth", "sixth",
        "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
    ];

    
    public Estrofa(int numeroEstrofa)
    {
        Lineas =
        [
            $"On the {Valores[numeroEstrofa - 1]} day of Christmas",

            "My true love sent to me:",

            "A partridge in a pear tree."
        ];
    }
}