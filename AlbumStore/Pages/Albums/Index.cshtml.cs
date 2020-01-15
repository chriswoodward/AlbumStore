using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlbumStore.Core;
using AlbumStore.Data;

namespace AlbumStore
{
    public class IndexModel : PageModel
    {
        private readonly AlbumStore.Data.AlbumStoreDbContext _context;

        public IndexModel(AlbumStore.Data.AlbumStoreDbContext context)
        {
            _context = context;
        }

        public IList<Album> Albums { get;set; }

        public async Task OnGetAsync()
        {
            Albums = await _context.Albums
                .Include(a => a.Artist).ToListAsync();
        }
    }
}
