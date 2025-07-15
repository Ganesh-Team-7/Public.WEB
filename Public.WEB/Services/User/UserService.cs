using Public.WEB.Models.User;

namespace Public.WEB.Services.User
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<UserResponse>> GetAllUsersAsync(UserFilter filter)
        {
            var client = _httpClientFactory.CreateClient("PublicApiClient");
            var url = $"api/users";
            var result = await client.GetFromJsonAsync<List<UserResponse>>(url);
            return result ?? new List<UserResponse>();
        }

        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PublicApiClient");
                var response = await client.GetAsync($"api/users/{id}");
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadFromJsonAsync<UserResponse>();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> CreateUserAsync(UserRequest request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PublicApiClient");
                var response = await client.PostAsJsonAsync("api/users", request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> UpdateUserAsync(int id, UserRequest request)
        {
            var client = _httpClientFactory.CreateClient("PublicApiClient");
            var response = await client.PutAsJsonAsync($"api/users/{id}", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("PublicApiClient");
            var response = await client.DeleteAsync($"api/users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
