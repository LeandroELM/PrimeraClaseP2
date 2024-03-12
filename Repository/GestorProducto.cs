using Repository;
public class GestorProducto
{
    private IProductoRepository _repository;

    public GestorProducto(IProductoRepository repository)
    {
        _repository = repository;
    }
    public List<Producto> ObtenerTodosLosProductos()
    {
        return _repository.ObtenerTodos();
    }

    public void AgregarProducto(Producto producto)
    {
        List<Producto> productos = _repository.ObtenerTodos();
        productos.Add(producto);
        _repository.GuardarTodos(productos);
    } 
}