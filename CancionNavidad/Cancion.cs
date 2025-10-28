namespace CancionNavidad;

public class Cancion
{
    public List<Estrofa> Estrofas { get; }

    public Cancion()
    {
        Estrofas = new List<Estrofa>();
        for (int i = 1; i <= 12; i++)
        {
            Estrofas.Add(new Estrofa(i));
        }
    }
}