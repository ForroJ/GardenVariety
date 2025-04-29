using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenVariety.Data;
using GardenVariety.Models;

namespace GardenVariety.Pages.Gardens
{
    public class EditModel : PageModel
    {
        private readonly GardenVariety.Data.GardenVarietyContext _context;

        public EditModel(GardenVariety.Data.GardenVarietyContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Garden Garden { get; set; } = default!;
        public List<string> GardenTypeNames { get; set; } = new();
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            GardenTypeNames = Enum.GetNames<ProduceType>().ToList();
            if (id == null)
            {
                return NotFound();
            }

            var garden =  await _context.Gardens.FirstOrDefaultAsync(m => m.GardenId == id);
            if (garden == null)
            {
                return NotFound();
            }
            Garden = garden;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Garden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenExists(Garden.GardenId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GardenExists(int id)
        {
            return _context.Gardens.Any(e => e.GardenId == id);
        }
    }
}
