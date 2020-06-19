
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlbumStore
{
    public class EditModel : PageModel
    {
        private readonly AlbumStore.Entities.AlbumStoreDbContext _context;

        public EditModel(AlbumStore.Entities.AlbumStoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditAlbumViewModel Album { get; set; }

        public class EditAlbumViewModel
        {
            public int Id { get; set; }

            [Required, StringLength(160)]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Artist")]
            public int ArtistId { get; set; }

            [Required, StringLength(255)]
            public string ReferenceNumber { get; set; }
        }

        public IEnumerable<SelectListItem> ArtistList { get; set; }

        public IActionResult OnGet(int? albumId)
        {
            if (albumId == null)
            {
                return NotFound();
            }

            var album = _context.Albums.Find(albumId);

            if (album == null)
            {
                return NotFound();
            }

            Album = new EditAlbumViewModel()
            {
                Id = album.AlbumId,
                Title = album.Title,
                ArtistId = album.ArtistId,
                ReferenceNumber = album.ReferenceNumber
            };

            ArtistList = _context.Artists
                                 .OrderBy(x => x.Name)
                                 .Select(x => new SelectListItem
                                 {
                                     Text = x.Name,
                                     Value = x.ArtistId.ToString()
                                 });

            return Page();
        }

        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ArtistList = _context.Artists
                                 .OrderBy(x => x.Name)
                                 .Select(x => new SelectListItem
                                 {
                                     Text = x.Name,
                                     Value = x.ArtistId.ToString()
                                 });

                return Page();
            }

            var album = _context.Albums.Find(Album.Id);

            album.Title = Album.Title;
            album.ArtistId = Album.ArtistId;
            album.ReferenceNumber = Album.ReferenceNumber;

            _context.Attach(album).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
