using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Areas.Identity.Models;

namespace WebApp1.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly WebApp1.Areas.Identity.Data.ApplicationDbContext _context;

        public EditModel(WebApp1.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var applicationuser =  await _context.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);
            if (applicationuser == null)
            {
                return NotFound();
            }
            ApplicationUser = applicationuser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(ApplicationUser.Id))
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

        private bool ApplicationUserExists(string id)
        {
          return (_context.ApplicationUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
