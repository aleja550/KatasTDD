namespace CancionNavidad;

public class Cancion
{
    public List<Estrofa> Estrofas { get; }

    public Cancion()
    {
        Estrofas = [];
        for (var i = 1; i <= 12; i++)
        {
            Estrofas.Add(new Estrofa(i));
        }
    }

    public string ObtenerCancionCompleta()
    {
        var estrofasTexto = Estrofas.Select(e => e.ObtenerTextoCompleto());
        return string.Join("\n\n", estrofasTexto);
    }
}