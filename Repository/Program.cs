using Repository;
//Ruta del archivo para almacenar productos
string ArchivoProductos = "productos.txt";

//Crear una instancia del repositorio de productos
IProductoRepository productoRepository = 
    new ProductoRepositoryArchivo(ArchivoProductos);

//Crear una instancia del gestor de producto utilizando el producto
GestorProducto gestorProductos = 
    new GestorProducto(productoRepository);

gestorProductos.AgregarProducto(
    new Producto { name = "Coca Cola 2 Litros", precio = 45m } );
   gestorProductos.AgregarProducto(
    new Producto { name = "Leche de Toro 1 Litros", precio = 50m } );

Console.WriteLine("Todos los productos");
foreach ( var item in gestorProductos.ObtenerTodosLosProductos()) 
{
    Console.WriteLine($"Nombre: {item.name}, percio: {item.precio}");
}
