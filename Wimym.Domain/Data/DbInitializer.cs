namespace Wimym.Domain.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wimym.Domain.DataEntities.Configuration;

    public class DbInitializer
    {

        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();// be sure than create the database

            //search if exist data
            if (context.Currencies.Any())
            {
                return;
            }

            var currencies = new Currency[]
            {
            new Currency {Code="USD",Name="Dollar"},
            new Currency {Code="DOP",Name="Dominican Pesos"}
            };

            foreach (var item in currencies)
            {
                context.Currencies.Add(item);
            }

            context.SaveChanges();
        }
    }
}
