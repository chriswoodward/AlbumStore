
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlbumStore
{
    public class DetailsModel : PageModel
    {
        private readonly AlbumStore.Entities.AlbumStoreDbContext _context;

        public DetailsModel(AlbumStore.Entities.AlbumStoreDbContext context)
        {
            _context = context;
        }

        public AlbumStore.Entities.Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Albums
                .Include(a => a.Artist).FirstOrDefaultAsync(m => m.AlbumId == id);

            if (Album == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
