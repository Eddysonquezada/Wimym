namespace Wimym.Front.Service
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class ApiService
    {
        //ICurrentUserFactory _currentUser;

        public async Task<TokenResponse> GetToken(string username, string password)
        {
            try
            {
                var urlBase = SpaParameters.ApiUrl.Substring(0, SpaParameters.ApiUrl.Length - 1);// Configuration["Api:Url"];

                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("Token",
                    new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                    username, password),
                        Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(resultJson);
                return result;
            }
            catch
            {
                return null;
            }
        }


        public async Task<Response> Get<T>(string servicePrefix, string controller, string tokenType, string accessToken, string id)
        {
            try
            {
                var urlBase = SpaParameters.ApiUrl.Substring(0, SpaParameters.ApiUrl.Length - 1);// Configuration["Api:Url"];
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}{2}", urlBase, servicePrefix, controller);//, id);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

    }
}
