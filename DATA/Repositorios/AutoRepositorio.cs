using Dapper;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repositorios
{
    public class AutoRepositorio : IAutoRepositorio
    {

        private readonly SqlConfiguration sqlConfiguration;

        public AutoRepositorio(SqlConfiguration sqlConfiguration)
        {
            this.sqlConfiguration = sqlConfiguration;
        }

        protected SqlConnection connection()
        {
            return new SqlConnection(sqlConfiguration.CadenaConexion);
        }

        public bool EditarAuto(Auto auto)
        {
            using var con = connection();
            var sql = @"update auto 
                set Make = @Make,
                Model = @Model,
                Color = @Color,
                Anio=@Puertas,
                Puertas= @puertas where id = @Id";

            return con.Execute(sql,
                new { auto.Id,auto.Make, auto.Model, auto.Color, auto.Anio, auto.Puertas }) > 0 ? true : false;
        }

        public bool EliminarAuto(Auto auto)
        {
            using var con = connection();
            var sql = "DELETE AUTO WHERE ID = @id";
            return con.Execute(sql,
                new {auto.Id}) > 0 ? true : false;

        }

        public bool InsertarAuto(Auto auto)
        {
            using var con = connection();
            var sql = "insert into auto(Make,Model,Color,Anio,Puertas) values (@Make,@Model,@Color,@Anio,@Puertas)";
            return con.Execute(sql,
                new { auto.Make, auto.Model, auto.Color, auto.Anio, auto.Puertas }) > 0 ? true : false;
        }

        public Auto ObtenerAuto(int id)
        {
            using var con = connection();
            var result = con.QueryFirstOrDefault<Auto>("select * from auto where Id = @id",
                new {Id = id});
            return result;
        }

        public List<Auto> ObtenerTodos()
        {
            using var con = connection();
            return con.Query<Auto>("select * from auto").ToList();
          
        }
    }
}
