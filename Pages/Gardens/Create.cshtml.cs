using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GardenVariety.Data;
using GardenVariety.Models;
using System.ComponentModel;

namespace GardenVariety.Pages.Gardens
{
    public class CreateModel : PageModel
    {
        private readonly GardenVariety.Data.GardenVarietyContext _context;

        public CreateModel(GardenVariety.Data.GardenVarietyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            GardenTypeNames = Enum.GetNames<ProduceType>().ToList(); 
            return Page();
        }

        [BindProperty]
        public Garden Garden { get; set; } = default!;

        public List<string> GardenTypeNames { get; set; } = new();

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Gardens.Add(Garden);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
