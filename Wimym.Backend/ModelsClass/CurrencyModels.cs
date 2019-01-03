using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Wimym.Backend.Data;
using Wimym.Backend.Models;

namespace Wimym.Backend.ModelsClass
{
    public class CurrencyModels
    {
        private readonly ApplicationDbContext _context;

        public CurrencyModels(ApplicationDbContext context)
        {
            this._context = context;
            // FilterData(1, "A");
        }

        public List<Currency> GetCurrencies(int id)
        {
            return _context.Currencies.Where(c => c.CurrencyId == id).ToList();
        }

        public async Task<List<IdentityError>> SaveCurrency(string code, string name, string state)
        {
            var errorList = new List<IdentityError>();
            var currency = new Currency
            {
                Code = code,
                Name = name,
                State = Convert.ToBoolean(state)
            };
            _context.Add(currency);
            await _context.SaveChangesAsync();

            errorList.Add(new IdentityError
            {
                Code = "200:Ok",
                Description = "Save"
            });
            return errorList;
        }

        private bool states;
        public List<IdentityError> EditCurrency(int idCurrency, string code,
            string name, bool state, string type)
        {
            var errorList = new List<IdentityError>();
             string stsCode = "", des = "";
            switch (type)
            {
                case "state":
                    //if (state)
                    //{
                    //    states = false;
                    //}
                    //else
                    //{
                    //    states = true;
                    //}
                     states = !state;
                    var currency = new Currency 
                    {
                        CurrencyId = idCurrency,
                        Code = code,
                        Name = name,
                        State = states
                    };
                    try
                    {
                        _context.Update(currency);
                        _context.SaveChanges();
                        stsCode = "200:Ok";
                        des = "Save";
                    }
                    catch (Exception ex)
                    {
                        stsCode = "500:Error";
                        des = ex.Message;
                    }
                    break;
            }
            errorList.Add(new IdentityError { Code = stsCode, Description = des });
            return errorList;
        }
        public List<object[]> FilterData(int pageNum, string valor)
        {
            int count = 0, cant, regsNum = 0, start = 0, regsForPage = 5;
            int pageCant, page;
            string dataFilter = "", paginator = "", State = null;
            List<object[]> data = new List<object[]>(); IEnumerable<Currency> query;
            var currencies = _context.Currencies.OrderBy(c => c.Code).ToList();
            regsNum = currencies.Count; start = (pageNum - 1) * regsForPage;
            pageCant = (regsNum / regsForPage);
            if (valor == "null")
            {
                query = currencies.Skip(start).Take(regsForPage);
            }
            else
            {
                query = currencies.Where(c => c.Code.StartsWith(valor)
                || c.Name.StartsWith(valor)).Skip(start).Take(regsForPage);
            }
            cant = query.Count();
            foreach (var item in query)
            {
                if (item.State == true)
                {
                    //State = "<a class='btn btn-success'>Active</a>";
                    State = "<a data-toggle='modal' data-target='#ModalState' onclick='editState(" + 
                        item.CurrencyId + ',' + 0 + ")' class='btn btn-success'>Active</a>";
                }
                else
                {
                    //State = "<a class='btn btn-danger'>Inactive</a>";
                    State = "<a data-toggle='modal' data-target='#ModalState' onclick='editState(" + 
                        item.CurrencyId + ',' + 0 + ")' class='btn btn-danger'>Inactive</a>";
                }
                dataFilter += "<tr>" +
                    "<td>" + item.Code + "</td>" +
                    "<td>" + item.Name + "</td>" +
                    "<td>" + State + " </td>" +
                    "<td>" +
                    "<a data-toggle='modal' data-target='#modalAdd'" +
                              "onclick='editState(" +
                              item.CurrencyId + ',' + 1 + ")' class='btn btn-success'>Edit</a>|" +
                    //"<a data-toggle='modal' data-target='#myModal3' class='btn btn-danger' >Delete</a>" +
                    "</td>" +
                    "</tr>";
            }
            object[] dataObj = { dataFilter, paginator };
            data.Add(dataObj);
            return data;
        }
    }
}

