using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wimym.Common;
using Wimym.Front.Service;
using Wimym.Model.Shared;
using Wimym.Model.Shared._Control;

namespace Wimym.Front.Controllers
{
    [Authorize]
    public class OriginController : Controller
    {
        private readonly ApiService _apiService;
        private readonly ICurrentUserFactory _currentUser;

        public OriginController(ICurrentUserFactory currentUser)
        {
            _apiService = new ApiService();
            _currentUser = currentUser;
        }

        public async Task<IActionResult> Index()
        {
            var user = new CurrentUser();
            if (_currentUser != null)
            {
                user = _currentUser.Get;
            }

            var token = await _apiService.GetToken(user.Email, user.Password);

            var response = await _apiService.Get<OriginList>("/api", "/origins/GetAll", 
                token.TokenType, token.AccessToken, user.UserId);

            //var response = await _apiService.Get<OriginList>("/api", "/origins/GetAll");

            if (!response.IsSuccess)
            {//error
                return View();
            }

           var list = (List<OriginList>)response.Result;

              // ObservableCollection<UserGroupItemViewModel> UserGroups
            //foreach (var item in list)
            //{
            //    OriginList.Add(new UserGroupItemViewModel
            //    {
            //        GroupId = userGroup.GroupId,
            //        GroupUsers = userGroup.GroupUsers,
            //        Logo = userGroup.Logo,
            //        Owner = userGroup.Owner,
            //        OwnerId = userGroup.OwnerId,
            //        Name = userGroup.Name,

            //    });
            //}

            return View(list);
        }
    }
}