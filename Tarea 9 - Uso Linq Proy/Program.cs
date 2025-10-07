// See https://aka.ms/new-console-template for more information

//Proyecto de uso de link utlizando los videos de 17 al 26
//ID: 11

ConsultasLinq queries = new ConsultasLinq();

// Imprimir Toos los datos de Json
ImprimirValores(queries.TodaLosProductos());

// Imprimir el resultado de Count
Console.WriteLine($"\nUsando Operador Count. \nCantidad de productos que tienen un precio entre 300.00 y 500.00: {queries.catidadProductosconPrecioMayoresA200()}");

//Imprimir resultados con LongCount
Console.WriteLine($"\nUtilizando LongCount para la catidad de productos con un precio entre 300 y 500 dolares: {queries.LongcatidadProductosconPrecioMayoresA200()} ");

//Imprimir con Min
Console.WriteLine("\nUtlizando Operador Min. \nEl precio minimo de productos: " + queries.OperadorMin());

//Imprimir Max
Console.WriteLine("\nUtlizando Operador Max: \nEl precio maximo de productos: " + queries.OperadorMax());

//Productos con menor oprecio usando MinBy
var precioMenor = queries.OperadorMinByEnProductos(); 
Console.WriteLine($"\nUso de MinBy.\n{precioMenor.Nombre} {precioMenor.Descripcion} {precioMenor.PrecioStock}");

//Producto con mayor precio usando MaxBy
var precioMayor = queries.OperadorMaxByProductos;
Console.WriteLine($"\nUso de MaxBy. \n{precioMenor.Nombre} {precioMenor.Descripcion} {precioMenor.PrecioStock}");

//Suma de productos entre 300 y 500 usando sum
Console.WriteLine($"\nUso de Operador Sum. \nSuma de productos entre 300$ y 500$: {queries.SumadeProductos300y500()}");

//Utilizando Agregate 
Console.WriteLine("\nUtlizando Operador Agregate.\n" + queries.ProductosUsandoAgregate());

//Utlizando Average calculando el promedio de carecters en los nombres de productos.
Console.WriteLine($"\nUso de Average.\nEl calculo de promedio de cacteres de los nombres es de: {queries.PromedioDeNombres()}");

//Impresion de uso de GroupBy
Console.WriteLine("\nUtilizando GroupBy\n");
ImprimirGrupos(queries.AgruparProductosPorPrecio());

//Imprimir diccionario usadno Lookuo
Console.WriteLine("\nUtlizando Lookuo.\n");
ImprimirDiccionario(queries.DiccionarioDeProductos());

//Usando Join
Console.WriteLine("\nUsando Join en productos: \n");//Por revisar
ImprimirValores(queries.ProductosJoin());

//Imprimir todos los valores en un formato completo
void ImprimirValores(IEnumerable<Productos> listProductos)
{
    Console.WriteLine("{0,-25} {1,10} {2,15}", "Nombre", "Precio", "CategoríaID");
    Console.WriteLine(new string('-', 55));

    foreach (var p in listProductos)
    {
        Console.WriteLine("{0,-25} {1,10:C} {2,15}", p.Nombre, p.PrecioStock, p.CategoriaID);
    }
}

//Imprimir grupos de la consulta GroupBy
void ImprimirGrupos(IEnumerable<IGrouping<string, Productos>> grupos)
{
    foreach (var grupo in grupos)
    {
        Console.WriteLine($"\nProductos en el rango de precios: {grupo.Key}");

        foreach (var p in grupo)
        {
            Console.WriteLine("{0,-40} {1,10:C} {2,5}", p.Nombre, p.PrecioStock, p.CategoriaID);
        }
    }
}

//Imprimir con una nueva rutina el Lookup
void ImprimirDiccionario(ILookup<char, Productos> lookup)
{
    foreach (var grupo in lookup.OrderBy(g => g.Key)) // Ordenar por letra
    {
        Console.WriteLine("{0,-40} {1,10:C} {2,5}\n", "Nombre","Precio","Categoria");
        foreach (var p in grupo)
        {
            // Ajustamos nombre a 40 caracteres y precio a 10
            Console.WriteLine("{0,-40} {1,10:C} {2,5}", p.Nombre, p.PrecioStock, p.CategoriaID);
        }
    }
}


