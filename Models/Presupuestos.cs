namespace tl2_tp7_2025_nicoodiaz;

public class Presupuestos
{
    private const decimal IVA = 0.21m;
    public int idPresupuesto { get; set; }
    public string nombreDestinatario { get; set; }
    public DateTime fechaCreacion { get; set; }
    public List<PresupuestoDetalle> detalle { get; set; }

    public decimal MontoPresupuesto()
    {
        decimal presupuesto = 0;
        foreach (var item in detalle)
        {
            presupuesto += item.cantidad * item.producto.precio;
        }
        return presupuesto;
    }
    public decimal MontoPresupuestoConIva()
    {
        return MontoPresupuesto() * (1m + IVA);
    }
    public int CantidadProductos()
    {
        int totalProductos = 0;
        foreach (var item in detalle)
        {
            totalProductos += item.cantidad;
        }
        return totalProductos;
    }
}