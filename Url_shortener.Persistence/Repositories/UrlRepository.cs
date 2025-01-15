using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Interfaces;
using Url_shortener.Logic.Models;
using Url_shortener.Logic.Models.Url;
using Url_shortener.Persistence.Data;

namespace Url_shortener.Persistence.Repositories
{
    public class UrlRepository : IUrlRepository
    {

        private readonly ApplicationDbContext _context;

        public UrlRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<UrlManagment> AddUrlAsync(UrlManagment url)
        {
            _context.Urls.Add(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<UrlManagment?> GetUrlByIdAsync(Guid id)
        {
            return await _context.Urls
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<IEnumerable<UrlManagment>> GetUrlsByUserIdAsync(int id)
        {
            return await _context.Urls
                .Where(u => u.Id == id)
                .ToListAsync();
        }

        public async Task<bool> UrlExistsAsync(string code)
        {
            return await _context.Urls.AnyAsync(u => u.Code == code);
        }
    }
}
