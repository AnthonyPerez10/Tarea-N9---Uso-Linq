using System.Text.Json;
//Videos del 17 al 26 uso de Linq
public class ConsultasLinq
{
    private List<Productos> ProductosCollection = new List<Productos>();

    public ConsultasLinq()
    {
        using (StreamReader reader = new StreamReader("Productos.json"))
        {
            string json = reader.ReadToEnd();
            this.ProductosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Productos>>(json,
                new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    // Todos los productos
    public IEnumerable<Productos> TodaLosProductos()
    {
        return ProductosCollection;
    }

    //Utlizando Count 
    public int catidadProductosconPrecioMayoresA200()
    {
        return ProductosCollection.Where(p => p.PrecioStock > 300.00 && p.PrecioStock < 500.00).Count();
    }

    //Utilizando LongCount
    public long LongcatidadProductosconPrecioMayoresA200()
    {
        return ProductosCollection.Where(p => p.PrecioStock > 300.00 && p.PrecioStock < 500.00).LongCount();
    }

    //Utlizando Operadores Min 
    public float OperadorMin()
    {
        return ProductosCollection.Min(p => p.PrecioStock);
    }

    //Utilizando Operador Max
    public float OperadorMax()
    {
        return ProductosCollection.Max(p => p.PrecioStock);
    }

    //Utlizando el Operador MinBy
    public Productos OperadorMinByEnProductos()
    {
        return ProductosCollection.Where(p => p.PrecioStock > 10.00).MinBy(p => p.PrecioStock);
    }

    //Utlizando el operador MaxBy
    public Productos OperadorMaxByProductos()
    {
        return ProductosCollection.MaxBy(p => p.PrecioStock);
    }

    //Utilizando operador Sum 
    public float SumadeProductos300y500()
    {
        return ProductosCollection.Where(p => p.PrecioStock > 300.00 && p.PrecioStock < 600.00).Sum(p => p.PrecioStock);
    }
    //Utilizando Aggregate
    public string ProductosUsandoAgregate()
    {
        return ProductosCollection
            .Where(p => p.Id > 0 && p.Id < 5)
            .Aggregate("Productos: ", (acumulador, siguiente) =>
                acumulador + siguiente.Nombre + ", ");
    }

    //Utilizando operador Average
    public double PromedioDeNombres()
    {
        return ProductosCollection.Average(p => p.Nombre.Length);
    }

    //Utilizando el GruupBy 
    public IEnumerable<IGrouping<string, Productos>> AgruparProductosPorPrecio()
    {
        // Filtrar primero los productos en el rango deseado
        var productosEnRango = ProductosCollection
            .Where(p => p.PrecioStock >= 100 && p.PrecioStock <= 199);

        // Agrupar por rango 
        var grupos = productosEnRango
            .GroupBy(p => "100 - 199");

        return grupos;
    }

    //Utlizadno la clausula Lookup
    public ILookup<char, Productos> DiccionarioDeProductos()
    {
        return ProductosCollection.ToLookup(p => p.Nombre[0], p => p);
    }

    //Utlizando clausula Join 
    public IEnumerable<Productos> ProductosJoin() //Por Revisar
    {
        var ProMayor300 = ProductosCollection.Where(p => p.PrecioStock > 300);
        var ProMenor100 = ProductosCollection.Where(P => P.PrecioStock < 100);

        return ProMayor300.Join(ProMenor100, p => p.Id, k => k.Id, (p, k) => p);
    }
}