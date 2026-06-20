using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryDbContext context) : base(context) { }

        public async Task<List<Category>> GetAllWithBookCountAsync()
            => await _context.Categories.Include(c => c.Books).OrderBy(c => c.CategoryName).ToListAsync();

        public async Task<bool> NameExistsAsync(string name)
            => await _context.Categories.AnyAsync(c => c.CategoryName == name);
    }
}
