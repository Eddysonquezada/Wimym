namespace Wimym.Web.Data
{
    using System.Linq;
    using Wimym.Web.Data.Entities;

    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();// be sure than create the database

            //search if exist data
            if (!context.Currencies.Any())
            {
                //field a vector with data of the chosed type
                var currencies = new Currency[]
                {
                new Currency {Code="DOP",Name="Dominican Pesos"},
                 new Currency {Code="USD",Name="Dollar"},
                };

                //add it on the table
                foreach (var item in currencies)
                {
                    context.Currencies.Add(item);
                }
            }

            if (!context.Origins.Any())
            {
                //field a vector with data of the chosed type
                var currencies = new Origin[]
                {
                new Origin {Code="1",Name="Credito",Description="Ingreso/Ahorro/Activo",Simbol="+"},
                new Origin {Code="-1",Name="Debito",Description="Gasto/Prestamo/Pasivo",Simbol="-"}
                };

                //add it on the table
                foreach (var item in currencies)
                {
                    context.Origins.Add(item);
                }
            }

            if (!context.AccountTypes.Any())
            {
                //field a vector with data of the chosed type
                var oCred = context.Origins.Find(1);
                var oDeb = context.Origins.Find(2);
                var currencies = new AccountType[]
                {
                new AccountType {Code="Pre",Name="Prestamo",Description="",Origin=oDeb},
                new AccountType {Code="TC",Name="Tarjeta de Credito",Description="",Origin=oDeb},
                new AccountType {Code="Aho",Name="Ahorro",Description="",Origin=oCred},
                new AccountType {Code="Cert",Name="Certifficado",Description="",Origin=oCred},
                new AccountType {Code="Act",Name="Activo",Description="",Origin=oDeb},
                new AccountType {Code="Gas",Name="Gasto",Description="",Origin=oDeb},
                new AccountType {Code="Cos",Name="Costo",Description="",Origin=oDeb},
                new AccountType {Code="Pas",Name="Pasivo",Description="",Origin=oCred},
                new AccountType {Code="Pat",Name="Patrimonio",Description="",Origin=oCred},
                new AccountType {Code="Ing",Name="Ingreso",Description="",Origin=oCred},
                };

                //add it on the table
                foreach (var item in currencies)
                {
                    context.AccountTypes.Add(item);
                }
            }

            //save changes to database, :D
            context.SaveChanges();

        }
    }
}
