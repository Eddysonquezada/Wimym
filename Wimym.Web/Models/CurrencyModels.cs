namespace Wimym.Web.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wimym.Web.Data;
    using Wimym.Web.Data.Entities;

    public class CurrencyModels
    {
        private DataContext context;
        private Boolean states;

        public CurrencyModels(DataContext context)
        {
            this.context = context;
            //FilterData(1, "Android");
        }

        public List<IdentityError> SaveCurrency(string code, string name, string state)
        {
            var errorList = new List<IdentityError>();
            var currency = new Currency
            {
                Code = code,
                Name = name,
                State = Convert.ToBoolean(state)
            };
            context.Add(currency);
            context.SaveChanges();
            errorList.Add(new IdentityError
            {
                Code = "200:Ok",
                Description = "Saved"
            });
            return errorList;
        }

        public List<object[]> FilterData(int pageNum, string filterValue, string order)
        {
            int count = 0, cant, regsNum = 0, start = 0, regByPage = 2;
            int pagesCant, page;
            string dataFilter = "", pagedor = "", state = null;
            List<object[]> data = new List<object[]>();
            IEnumerable<Currency> query;
            List<Currency> currencies = null;
            switch (order)
            {
                case "code":
                    currencies = context.Currencies.OrderBy(c => c.Code).ToList();
                    break;
                case "name":
                    currencies = context.Currencies.OrderBy(c => c.Name).ToList();
                    break;
                case "state":
                    currencies = context.Currencies.OrderBy(c => c.State).ToList();
                    break;
            }
            if (currencies != null)
            {
                regsNum = currencies.Count;
            }

            if ((regsNum % regByPage) > 0)
            {
                regsNum += 1;
            }
            start = (pageNum - 1) * regByPage;
            pagesCant = (regsNum / regByPage);

            if (filterValue == "null")
            {
                query = currencies.Skip(start).Take(regByPage);
            }
            else
            {
                query = currencies.Where(c => c.Code.StartsWith(filterValue) || c.Name.StartsWith(filterValue)).Skip(start).Take(regByPage);
            }
            cant = query.Count();
            foreach (var item in query)
            {
                if (item.State == true)
                {
                    state = "<a data-toggle='modal' data-target='#ModalState' onclick='editState(" + item.Id + ',' + 0 + ")' class='btn btn-success'>Active</a>";
                }
                else
                {
                    state = "<a data-toggle='modal' data-target='#ModalState' onclick='editState(" + item.Id + ',' + 0 + ")' class='btn btn-danger'>Inactive</a>";
                }
                dataFilter += "<tr>" +
                              "<td>" + item.Code + "</td>" +
                              "<td>" + item.Name + "</td>" +
                              "<td>" + state + " </td>" +
                              "<td>" +
                              "<a data-toggle='modal' data-target='#ModalAddEdit'  onclick='editState(" + item.Id + ',' + 1 + ")'class='btn btn-success'>Edit</a>" +
                              "</td>" +
                              "</tr>";
            }
            if (filterValue == "null")
            {
                if (pageNum > 1)
                {
                    page = pageNum - 1;
                    pagedor += "<a class='btn btn-default' onclick='filterData(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                                 "<a class='btn btn-default' onclick='filterData(" + page + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < pagesCant)
                {
                    pagedor += "<strong class='btn btn-success'>" + pageNum + ".from." + pagesCant + "</strong>";
                }
                if (pageNum < pagesCant)
                {
                    page = pageNum + 1;
                    pagedor += "<a class='btn btn-default' onclick='filterData(" + page + ',' + '"' + order + '"' + ")'>  > </a>" +
                                 "<a class='btn btn-default' onclick='filterData(" + pagesCant + ',' + '"' + order + '"' + ")'> >> </a>";
                }
            }
            object[] dataObj = { dataFilter, pagedor };
            data.Add(dataObj);
            return data;
        }

        public List<Currency> GetCurrencies(int id)
        {
            return context.Currencies.Where(c => c.Id == id).ToList();
        }

        public List<IdentityError> EditCurrency(int idCurrency, string code, string name, Boolean state, int type)
        {
            var errorList = new List<IdentityError>();
            string strCode = "", des = "";
            switch (type)
            {
                case 0:
                    if (state)
                    {
                        states = false;
                    }
                    else
                    {
                        states = true;
                    }

                    break;
                case 1:
                    states = state;
                    break;


            }
            var currency = new Currency()
            {
                Id = idCurrency,
                Code = code,
                Name = name,
                State = states
            };
            try
            {
                context.Update(currency);
                context.SaveChanges();
                strCode = "200:Ok";
                des = "Saved";
            }
            catch (Exception ex)
            {

                strCode = "400:error";
                des = ex.Message;
            }

            errorList.Add(new IdentityError
            {
                Code = strCode,
                Description = des
            });

            return errorList;
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Wimym.Backend.Data;
//using Wimym.Backend.Models;

//namespace Wimym.Backend.ModelsClass
//{
//    public class CurrencyModels
//    {
//        private readonly DataContext _context;

//        public CurrencyModels(DataContext context)
//        {
//            this._context = context;
//            // FilterData(1, "A");
//        }

//        public List<Currency> GetCurrencies(int id)
//        {
//            return _context.Currencies.Where(c => c.Id == id).ToList();
//        }

//        public async Task<List<IdentityError>> SaveCurrency(string code, string name, string state)
//        {
//            var errorList = new List<IdentityError>();
//            var currency = new Currency
//            {
//                Code = code,
//                Name = name,
//                State = Convert.ToBoolean(state)
//            };
//            _context.Add(currency);
//            await _context.SaveChangesAsync();

//            errorList.Add(new IdentityError
//            {
//                Code = "200:Ok",
//                Description = "Save"
//            });
//            return errorList;
//        }

//        private bool states;
//        public List<IdentityError> EditCurrency(int idCurrency, string code,
//            string name, bool state, int type)
//        {
//            var errorList = new List<IdentityError>();
//             string stsCode = "", des = "";
//            switch (type)
//            {
//                case 0: // "state":
//                    //if (state)
//                    //{
//                    //    states = false;
//                    //}
//                    //else
//                    //{
//                    //    states = true;
//                    //}
//                     states = !state;
//                    break;
//                case 1:
//                    states = state;
//                    break;
//            }

//            var currency = new Currency
//            {
//                Id = idCurrency,
//                Code = code,
//                Name = name,
//                State = states
//            };
//            try
//            {
//                _context.Update(currency);
//                _context.SaveChanges();
//                stsCode = "200:Ok";
//                des = "Save";
//            }
//            catch (Exception ex)
//            {
//                stsCode = "500:Error";
//                des = ex.Message;
//            }
//            errorList.Add(new IdentityError { Code = stsCode, Description = des });
//            return errorList;
//        }

//        public List<object[]> FilterData(int pageNum, string filterValue,string order)
//        {
//            int count = 0, cant, regsNum = 0, start = 0, regsForPage = 5;
//            int pageCant, page;
//            string dataFilter = "", pagetor = "", State = null;
//            List<object[]> data = new List<object[]>();
//            IEnumerable<Currency> query;
//            List<Currency> currencies = null;
//            switch (order)
//            {
//                case "code":
//                    currencies = _context.Currencies.OrderBy(c => c.Code).ToList();
//                    break;
//                case "name":
//                    currencies = _context.Currencies.OrderBy(c => c.Name).ToList();
//                    break;
//                case "state":
//                    currencies = _context.Currencies.OrderBy(c => c.State).ToList();
//                    break;
//            }
//            // var currencies = _context.Currencies.OrderBy(c => c.Code).ToList();
//            if (currencies != null)
//            {
//                regsNum = currencies.Count;
//            }
//            if ((regsNum % regsForPage) > 0)
//            {
//                regsNum += 1;
//            }
//            start = (pageNum - 1) * regsForPage;
//            pageCant = (regsNum / regsForPage);
//            if (filterValue == "null")
//            {
//                query = currencies.Skip(start).Take(regsForPage);
//            }
//            else
//            {
//                query = currencies.Where(c => c.Code.StartsWith(filterValue)
//                || c.Name.StartsWith(filterValue)).Skip(start).Take(regsForPage);
//            }
//            cant = query.Count();
//            foreach (var item in query)
//            {
//                if (item.State == true)
//                {
//                    //State = "<a class='btn btn-success'>Active</a>";
//                    State = "<a data-toggle='modal' data-target='#ModalState' onclick='editState(" + 
//                        item.Id + ',' + 0 + ")' class='btn btn-success'>Active</a>";
//                }
//                else
//                {
//                    //State = "<a class='btn btn-danger'>Inactive</a>";
//                    State = "<a data-toggle='modal' data-target='#ModalState' onclick='editState(" + 
//                        item.Id + ',' + 0 + ")' class='btn btn-danger'>Inactive</a>";
//                }
//                dataFilter += "<tr>" +
//                    "<td>" + item.Code + "</td>" +
//                    "<td>" + item.Name + "</td>" +
//                    "<td>" + State + " </td>" +
//                    "<td>" +
//                    "<a data-toggle='modal' data-target='#modalAdd'" +
//                              "onclick='editState(" +
//                              item.Id + ',' + 1 + ")' class='btn btn-success'>Edit</a>|" +
//                    //"<a data-toggle='modal' data-target='#myModal3' class='btn btn-danger' >Delete</a>" +
//                    "</td>" +
//                    "</tr>";
//            }
//            if (filterValue == "null")
//            {
//                if (pageNum > 1)
//                {
//                    page = pageNum - 1;
//                    pagetor += "<a class='btn btn-default' onclick='filterData(" + 1 + ',' + '"' +
//                                 order + '"' + ")'> << </a>" +
//                                 "<a class='btn btn-default' onclick='filterData(" + page + ',' + '"' +
//                                 order + '"' + ")'> < </a>";

//                }
//                if (1 < pageCant)
//                {
//                    pagetor += "<strong class='btn btn-success'>" + pageNum + ".from." + 
//                        pageCant + "</strong"; 
//                }
//                if (pageNum < pageCant)
//                {
//                    page = pageNum + 1;
//                    pagetor += "<a class='btn btn-default' onclick='filterData(" + page + ',' + '"' +
//                                 order + '"' + ")'> > </a>" +
//                                 "<a class='btn btn-default' onclick='filterData(" + pageCant + ',' + '"' +
//                                 order + '"' + ")'> >> </a>";
//                }
//            }
//            object[] dataObj = { dataFilter, pagetor };
//            data.Add(dataObj);
//            return data;
//        }
//    }
//}
