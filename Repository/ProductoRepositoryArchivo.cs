using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductoRepositoryArchivo : IProductoRepository
    {
        private string _nombreArchivo;

        public ProductoRepositoryArchivo(string nombreArchivo)
        {
            _nombreArchivo = nombreArchivo;
        }
        public void GuardarTodos(List<Producto> productos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_nombreArchivo))
                {
                    foreach (Producto producto in productos)
                    {
                        sw.WriteLine($"{producto.name},{producto.precio}");
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error al momento de escribir el archivo: {e.Message}");
            }
        }
        public List<Producto> ObtenerTodos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                using (StreamReader sr = new StreamReader(_nombreArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        Producto producto = new Producto
                        {
                            name = datos[0],
                            precio = Convert.ToInt32(datos[1]),
                        };
                        productos.Add(producto);
                    };
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error al momento de leer el archivo: {e.Message}");
            }
            return productos;
        }
    }
}
