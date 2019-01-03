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
            string name, bool state, int type)
        {
            var errorList = new List<IdentityError>();
             string stsCode = "", des = "";
            switch (type)
            {
                case 0: // "state":
                    //if (state)
                    //{
                    //    states = false;
                    //}
                    //else
                    //{
                    //    states = true;
                    //}
                     states = !state;
                    break;
                case 1:
                    states = state;
                    break;
            }

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
            errorList.Add(new IdentityError { Code = stsCode, Description = des });
            return errorList;
        }

        public List<object[]> FilterData(int pageNum, string filterValue,string order)
        {
            int count = 0, cant, regsNum = 0, start = 0, regsForPage = 5;
            int pageCant, page;
            string dataFilter = "", paginator = "", State = null;
            List<object[]> data = new List<object[]>();
            IEnumerable<Currency> query;
            List<Currency> currencies = null;
            switch (order)
            {
                case "code":
                    currencies = _context.Currencies.OrderBy(c => c.Code).ToList();
                    break;
                case "name":
                    currencies = _context.Currencies.OrderBy(c => c.Name).ToList();
                    break;
                case "state":
                    currencies = _context.Currencies.OrderBy(c => c.State).ToList();
                    break;
            }
            // var currencies = _context.Currencies.OrderBy(c => c.Code).ToList();
            if (currencies != null)
            {
                regsNum = currencies.Count;
            }
            if ((regsNum % regsForPage) > 0)
            {
                regsNum += 1;
            }
            start = (pageNum - 1) * regsForPage;
            pageCant = (regsNum / regsForPage);
            if (filterValue == "null")
            {
                query = currencies.Skip(start).Take(regsForPage);
            }
            else
            {
                query = currencies.Where(c => c.Code.StartsWith(filterValue)
                || c.Name.StartsWith(filterValue)).Skip(start).Take(regsForPage);
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
            if (filterValue == "null")
            {
                if (pageNum > 1)
                {
                    page = pageNum - 1;
                    paginator += "<a class='btn btn-default' onclick='filterData(" + 1 + ',' + '"' +
                                 order + '"' + ")'> << </a>" +
                                 "<a class='btn btn-default' onclick='filterData(" + page + ',' + '"' +
                                 order + '"' + ")'> < </a>";

                }
                if (1 < pageCant)
                {
                    paginator += "<strong class='btn btn-success'>" + pageNum + ".from." + 
                        pageCant + "</strong"; 
                }
                if (pageNum < pageCant)
                {
                    page = pageNum + 1;
                    paginator += "<a class='btn btn-default' onclick='filterData(" + page + ',' + '"' +
                                 order + '"' + ")'> > </a>" +
                                 "<a class='btn btn-default' onclick='filterData(" + pageCant + ',' + '"' +
                                 order + '"' + ")'> >> </a>";
                }
            }
            object[] dataObj = { dataFilter, paginator };
            data.Add(dataObj);
            return data;
        }
    }
}

