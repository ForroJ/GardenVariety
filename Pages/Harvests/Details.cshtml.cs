using System;
using System.Collections.Generic;
using System.Linq;
using GardenVariety.Data;
using GardenVariety.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GardenVariety.Pages.Harvests
    {
    public class DetailsModel : PageModel
    {
        private readonly GardenVariety.Data.GardenVarietyContext _context;

        public DetailsModel(GardenVariety.Data.GardenVarietyContext context)
        {
            _context = context;
        }

        public HarvestViewModel Harvester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvester = await _context.Harvests
    .Include(h => h.Garden)
    .FirstOrDefaultAsync(m => m.Id == id);

            if (harvester is not null)
            {
                Harvester = new HarvestViewModel
                {
                    Date = harvester.Date,
                    Garden = new GardenViewModel
                    {
                        Name = harvester.Garden.Name,
                        Items = new List<string> { " Item 1", "Example Item 2" } 
                    }
                };

                return Page();
            }

            return NotFound();
        }
    }

    public class HarvestViewModel
    {
        public DateTime Date { get; set; }
        public GardenViewModel Garden { get; set; } = default!;
    }

    public class GardenViewModel
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new List<string>();
    }
}