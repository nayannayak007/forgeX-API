using ForgeXAPI.Data;
using ForgeXAPI.Dtos;
using ForgeXAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ForgeXAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(LoginRequestDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && u.Approved == true);
            if (user == null) return null;

            bool valid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            return valid ? user : null;
        }

        public async Task<User> RegisterAsync(RegisterRequestDto dto)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existing != null)
                throw new Exception("User already exists.");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FullName = dto.FullName ?? dto.Email.Split('@')[0],
                Role = dto.Role,
                Approved = false
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            foreach (var schoolId in dto.SchoolIds)
            {
                _context.UserSchools.Add(new UserSchool
                {
                    UserId = user.Id,
                    SchoolId = schoolId
                });
            }

            await _context.SaveChangesAsync();
            return user;
           
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> ApproveUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                return null;

            user.Approved = true;
            await _context.SaveChangesAsync();
            return user;
        }

          

        public async Task<User?> UnapproveUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            user.Approved = false;
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<UserWithSchoolsDto>> GetAllUsersAsync()
        {
           var users = await _context.Users
            .Include(u => u.UserSchools)
            .ThenInclude(us => us.School)
            .ToListAsync();

            var result = users.Select(u => new UserWithSchoolsDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Approved = u.Approved,
                Role = u.Role,
                Schools = u.UserSchools.Select(us => us.School.ClassName).ToList()
            });

            return result.ToList();
        }

    }
}
