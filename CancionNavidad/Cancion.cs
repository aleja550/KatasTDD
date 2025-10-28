namespace CancionNavidad;

public class Cancion
{
    public List<Estrofa> Estrofas { get; }
    
    public Cancion()
    {
        Estrofas = [];
        for (var i = 0; i < 12; i++)
        {
            Estrofas.Add(new Estrofa());
        }
    }
}