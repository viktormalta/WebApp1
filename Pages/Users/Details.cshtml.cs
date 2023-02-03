using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp1.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ApplicationUser ApplicationUser { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var applicationuser = await _context.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);
            if (applicationuser == null)
            {
                return NotFound();
            }
            else 
            {
                ApplicationUser = applicationuser;
            }
            return Page();
        }
    }
}
