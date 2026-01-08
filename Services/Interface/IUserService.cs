using ForgeXAPI.Dtos;
using ForgeXAPI.Models;

namespace ForgeXAPI.Services
{
    public interface IUserService
    {
        Task<User?> AuthenticateAsync(LoginRequestDto dto);
        Task<User> RegisterAsync(RegisterRequestDto dto);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> ApproveUserAsync(int userId);
        Task<User?> UnapproveUserAsync(int userId);
        Task<List<UserWithSchoolsDto>> GetAllUsersAsync();
    }
}
