namespace Wimym.Backend.Data
{
    using System.Linq;
    using Wimym.Backend.Models;

    public class DbInitializer
    {
        public static void Initialize (LocalDataContext context)
        {
            context.Database.EnsureCreated();// be sure than create the database

            //search if exist data
            if (context.Currencies.Any())
            {
                return;
            }
            
            //field a vector with data of the chosed type
            var currencies = new Currency[]
            {
            new Currency {Code="USD",Name="Dollar"},
            new Currency {Code="DOP",Name="Dominican Pesos"}
            };

            //add it on the table
            foreach (var item in currencies)
            {
                context.Currencies.Add(item);
            }
            //save changes to database, :D
            context.SaveChanges();

        }
    }
}
