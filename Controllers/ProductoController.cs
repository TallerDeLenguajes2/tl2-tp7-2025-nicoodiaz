using Microsoft.AspNetCore.Mvc;

namespace tl2_tp7_2025_nicoodiaz;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository _productoRepositoy;
    public ProductoController()
    {
        _productoRepositoy = new ProductoRepository();
    }

    [HttpPost("CrearProducto")]
    public IActionResult CrearProduct(Producto producto)
    {
        _productoRepositoy.CrearProducto(producto);
        return Ok("Producto dado de alta!");
    }

    [HttpPut("ActualizarProducto")]
    public IActionResult UpdateProduct(int id, Producto producto)
    {
        _productoRepositoy.ActualizarProducto(id, producto);
        return Ok();
    }

    [HttpGet("ListarProductos")]
    public IActionResult ObtenerTodos()
    {
        var productos = _productoRepositoy.ObtenerTodosProductos();
        return productos != null ? Ok(productos) : NotFound("No se encontraron productos");
    }
    [HttpGet("MostrarProducto/{id}")]
    public IActionResult ObtenerProducto(int id)
    {
        Producto prodObtenido = _productoRepositoy.ObtenerProductoXId(id);
        return prodObtenido != null ? Ok(prodObtenido) : NotFound($"No se encontro el producto con el id: {id}");
    }
    [HttpDelete("ElimiarProducto/{id}")]
    public IActionResult EliminarProducto(int id)
    {
        var eliminado = _productoRepositoy.EliminarProducto(id);
        return eliminado != null ? Ok(eliminado) : NotFound($"No se encontro el producto con el id: {id}");
    }
}