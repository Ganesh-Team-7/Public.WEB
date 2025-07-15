using Public.WEB.Models.User;

namespace Public.WEB.Services.User
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllUsersAsync(UserFilter filter);
        Task<UserResponse?> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(UserRequest request);
        Task<bool> UpdateUserAsync(int id, UserRequest request);
        Task<bool> DeleteUserAsync(int id);
    }
}
