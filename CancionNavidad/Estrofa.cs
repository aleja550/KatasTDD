namespace CancionNavidad;

public class Estrofa
{
    public List<string> Lineas { get; }
    
    private static readonly string[] Valores =
    [
        "first", "second", "third", "fourth", "fifth", "sixth",
        "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
    ];
    
    private static readonly string[] Regalos =
    [
        "A partridge in a pear tree.",
        "Two turtle doves",
        "Three french hens",
        "Four calling birds",
        "Five golden rings",
        "Six geese a-laying",
        "Seven swans a-swimming",
        "Eight maids a-milking",
        "Nine ladies dancing",
        "Ten lords a-leaping",
        "Eleven pipers piping",
        "Twelve drummers drumming"
    ];

    
    public Estrofa(int numeroEstrofa)
    {
        Lineas =
        [
            $"On the {Valores[numeroEstrofa - 1]} day of Christmas",
            "My true love sent to me:"
        ];

        for (var i = numeroEstrofa - 1; i >= 0; i--)
        {
            if (i == 1 && numeroEstrofa > 1)
            {
                Lineas.Add(Regalos[i] + " and");
            }
            else
            {
                Lineas.Add(Regalos[i]);
            }
        }
    }

    public string ObtenerTextoCompleto()
    {
        return string.Join("\n", Lineas);
    }
}