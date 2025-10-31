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
    public IActionResult CreateProduct(Productos producto)
    {
        _productoRepositoy.CreateProduct(producto);
        return Ok();
    }

    [HttpPut("ActualizarProducto")]
    public IActionResult UpdateProduct(int id, Productos producto)
    {
        _productoRepositoy.UpdateProduct(id, producto);
        return Ok();
    }

    [HttpGet("productos")]
    public IActionResult GetAll()
    {
        var productos = _productoRepositoy.GetAllProductos();
        return Ok(productos);
    }

}