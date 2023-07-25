namespace EjercicioParcial.IVA.Modelo
{
    public record Direccion(string Pais);
    public record DireccionUSA(string Estado) : Direccion("usa");
}
