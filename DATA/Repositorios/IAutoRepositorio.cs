using MODEL;

namespace DATA.Repositorios
{
    public interface IAutoRepositorio
    {
        List<Auto> ObtenerTodos();
        Auto ObtenerAuto(int id);
        Boolean InsertarAuto(Auto auto);
        Boolean EditarAuto(Auto auto);
        Boolean EliminarAuto(Auto auto);
    }
}
