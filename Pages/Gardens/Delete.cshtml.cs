using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenVariety.Data;
using GardenVariety.Models;

namespace GardenVariety.Pages.Gardens
{
    public class DeleteModel : PageModel
    {
        private readonly GardenVariety.Data.GardenVarietyContext _context;

        public DeleteModel(GardenVariety.Data.GardenVarietyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Garden Garden { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Gardens.FirstOrDefaultAsync(m => m.GardenId == id);

            if (garden is not null)
            {
                Garden = garden;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Gardens.FindAsync(id);
            if (garden != null)
            {
                Garden = garden;
                _context.Gardens.Remove(Garden);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
