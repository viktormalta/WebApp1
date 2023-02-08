using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.Data;
using WebApp1.Areas.Identity.Models;

namespace WebApp1.Areas.Identity.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly WebApp1.Areas.Identity.Data.ApplicationDbContext _context;

        public CreateModel(WebApp1.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Computation Computation { get; set; }
        
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Computation == null || Computation == null)
            {
                return Page();
            }

            _context.Computation.Add(Computation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Admin");
        }
    }
}
