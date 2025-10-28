namespace CancionNavidad;

public class Estrofa
{
    public List<string> Lineas { get; }

    public Estrofa(int numeroEstrofa)
    {
        Lineas = new List<string>();
        
        if (numeroEstrofa == 1)
        {
            Lineas.Add("On the first day of Christmas");
            Lineas.Add("My true love sent to me:");
            Lineas.Add("A partridge in a pear tree.");
        }
        else if (numeroEstrofa == 2)
        {
            Lineas.Add("On the second day of Christmas");
            Lineas.Add("My true love sent to me:");
            Lineas.Add("Two turtle doves and");
            Lineas.Add("A partridge in a pear tree.");
        }
    }
}