using Microsoft.AspNetCore.Mvc;

namespace tl2_tp7_2025_nicoodiaz;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{
    private PresupuestosRepository _presupuestoRepository;
    public PresupuestosController()
    {
        _presupuestoRepository = new PresupuestosRepository();
    }
    [HttpPost("CrearPresupuesto")]
    public IActionResult CrearPresupuesto(Presupuesto presupuesto)
    {
        return _presupuestoRepository.CrearPresupuesto(presupuesto) ? NoContent() : NotFound();
    }
    [HttpPost("Agregar")]
    public IActionResult AgregarProductoYPresupuesto(int idprod, int idpresu, int cantidad)
    {
        _presupuestoRepository.AgregarProducto(idprod, idpresu, cantidad);
        return Ok();
    }
    [HttpGet("ObtenerDetalles")]
    public IActionResult ObtenerDetallesId(int id)
    {
        var resultado = _presupuestoRepository.ObtenerDetallesPorId(id);
        return resultado != null ? Ok(resultado) : NotFound("No se encontro");
    }

    [HttpGet("ListarPresupuestos")]
    public IActionResult ObtenerPresupuestos()
    {
        var resultado = _presupuestoRepository.ObtenerTodosPresupuestos();
        return resultado != null ? Ok(resultado) : NotFound("No se encotraron resultados");
    }

    [HttpDelete("EliminarPresupuesto")]
    public IActionResult EliminarPresupuesto(int id)
    {
        _presupuestoRepository.EliminarPresupuesto(id);
        return Ok();
    }
}