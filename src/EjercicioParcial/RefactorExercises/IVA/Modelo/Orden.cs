namespace EjercicioParcial.IVA.Modelo
{
    public record Orden(Producto producto, int cantidad)
    {
        public decimal PrecioNeto => producto.precio * cantidad;
    }
}
