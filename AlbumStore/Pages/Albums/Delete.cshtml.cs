
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlbumStore
{
    public class DeleteModel : PageModel
    {
        private readonly AlbumStore.Data.AlbumStoreDbContext _context;

        public DeleteModel(AlbumStore.Data.AlbumStoreDbContext context)
        {
            _context = context;
        }       

        [BindProperty]
        public DeleteAlbumViewModel Album { get; set; }

        public class DeleteAlbumViewModel
        {
            public int Id { get; set; }

            [Required, StringLength(160)]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Artist")]            

            public string Artist { get; set; }

            [Required, StringLength(255)]
            public string ReferenceNumber { get; set; }
        }


        public IActionResult OnGet(int? albumId)
        {
            if (albumId == null)
            {
                return NotFound();
            }

            var album = _context.Albums.Include(x => x.Artist).SingleOrDefault(x => x.AlbumId == albumId);

            if (album == null)
            {
                return NotFound();
            }

            Album = new DeleteAlbumViewModel()
            {
                Id = album.AlbumId,
                Title = album.Title,
                Artist = album.Artist.Name,
                ReferenceNumber = album.ReferenceNumber
            };

            return Page();
        }

        public IActionResult OnPost(int? albumId)
        {
            if (albumId == null)
            {
                return NotFound();
            }

            var album = _context.Albums.Find(albumId);

            if (album == null)
            {
                return RedirectToPage("./NotFound");
            }

            _context.Albums.Remove(album);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
