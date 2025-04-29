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

namespace GardenVariety.Pages.Harvests
{
    public class EditModel : PageModel
    {
        private readonly GardenVariety.Data.GardenVarietyContext _context;

        public EditModel(GardenVariety.Data.GardenVarietyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Harvester Harvester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvester = await _context.Harvests.FirstOrDefaultAsync(m => m.Id == id);
            if (harvester == null)
            {
                return NotFound();
            }
            Harvester = harvester;
           ViewData["GardenId"] = new SelectList(_context.Gardens, "GardenId", "Name");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // ADD THIS: To help debug
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                return Page();
            }

            _context.Attach(Harvester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HarvesterExists(Harvester.Id))
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


        private bool HarvesterExists(int id)
        {
            return _context.Harvests.Any(e => e.Id == id);
        }
    }
}
