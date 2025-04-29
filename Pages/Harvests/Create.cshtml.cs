using GardenVariety.Data;
using GardenVariety.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GardenVariety.Pages.Harvests
{
    public class CreateModel : PageModel
    {
        private readonly GardenVarietyContext _context;

        public CreateModel(GardenVarietyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HarvesterInputModel Harvester { get; set; } = new HarvesterInputModel();

        public SelectList Garden { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var gardens = await _context.Gardens.ToListAsync();
            Garden = new SelectList(gardens, "GardenId", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var gardens = await _context.Gardens.ToListAsync();
                Garden = new SelectList(gardens, "GardenId", "Name");

                return Page();
            }

            var harvesterEntity = new Harvester
            {
                Date = Harvester.Date,
                GardenId = Harvester.GardenId
            };


            _context.Harvests.Add(harvesterEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    public class HarvesterInputModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Harvest Date")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Garden")]
        [Required]
        public int GardenId { get; set; }
    }

}
