
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlbumStore
{
    public class CreateModel : PageModel
    {
        private readonly AlbumStore.Entities.AlbumStoreDbContext _context;

        public CreateModel(AlbumStore.Entities.AlbumStoreDbContext context)
        {
            _context = context;
        }       

        [BindProperty]
        public CreateAlbumViewModel Album { get; set; }

        public class CreateAlbumViewModel
        {
            [Required, StringLength(160)]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Artist")]
            public int ArtistId { get; set; }

            [Required, StringLength(255)]
            public string ReferenceNumber { get; set; }
        }        

        public IEnumerable<SelectListItem> ArtistList { get; set; }

        public IActionResult OnGet()
        {
            ArtistList = _context.Artists
                                 .OrderBy(x => x.Name)
                                 .Select(x => new SelectListItem
                                 {
                                     Text = x.Name,
                                     Value = x.ArtistId.ToString()
                                 });

            Album = new CreateAlbumViewModel();

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

            var album = new AlbumStore.Entities.Album() { Title = Album.Title, ArtistId = Album.ArtistId, ReferenceNumber = Album.ReferenceNumber };

            _context.Albums.Add(album);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
