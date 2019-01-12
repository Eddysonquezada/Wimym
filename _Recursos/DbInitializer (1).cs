using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Models;

namespace Sistema.Data
{
    public class DbInitializer
    {
        public static void Initialize (SistemaContext context)
        {
            context.Database.EnsureCreated();

            //Buscar si existen registros en la tabla categoría
            if (context.Categoria.Any())
            {
                return;
            }
            var categorias = new Categoria[]
            {
                new Categoria{Nombre="Programación",Descripcion="Cursos de programación",Estado=true},
                new Categoria{Nombre="Diseño gráfico",Descripcion="Cursos de diseño gráfico",Estado=true}
            };

            foreach (Categoria c in categorias)
            {
                context.Categoria.Add(c);
            }
            context.SaveChanges();

        }
    }
}
