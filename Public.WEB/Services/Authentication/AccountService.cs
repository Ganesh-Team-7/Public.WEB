using Public.WEB.Models.Authentication;

namespace Public.WEB.Services.Authentication
{
    public interface IAccountService
    {
        Task<string?> LoginAsync(LoginRequest model);
        Task<bool> RegisterAsync(RegisterRequest model);
    }

    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AccountService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string?> LoginAsync(LoginRequest model)
        {
            var client = _clientFactory.CreateClient("PublicApiClient");
            var response = await client.PostAsJsonAsync("api/auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result?.AccessToken;
            }

            return null;
        }

        public async Task<bool> RegisterAsync(RegisterRequest model)
        {
            var client = _clientFactory.CreateClient("PublicApiClient");
            var response = await client.PostAsJsonAsync("api/auth/register", model);
            return response.IsSuccessStatusCode;
        }
    }

}
