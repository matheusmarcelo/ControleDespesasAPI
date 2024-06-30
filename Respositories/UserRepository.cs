using ControleDespesas.Context;
using ControleDespesas.Interfaces;
using ControleDespesas.Interfaces.UserInterfaces;
using ControleDespesas.Models;
using ControleDespesas.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ControleDespesas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> GetUserByEmailAsync(string Email)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == Email);
            if(user != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> GetUserByDocumentNumberAsync(string DocumentNumber)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.DocumentNumber == DocumentNumber);
            if(user != null)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.User.Include(x => x.Finances).AsNoTracking().ToListAsync();
            return users;
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        // Criar Usuario
        public async Task CreateAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync(); // salva os dados no banco
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            if(id != user.UserId)
            {
                throw new Exception("Não foi possivel realizar a operação.");
            }
            _context.Entry(user).State = EntityState.Modified; // manter os dados persistidos
            await _context.SaveChangesAsync(); // salvar no banco

            var updatedUser = await _context.User.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            return updatedUser;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == id);

            if(user is null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}