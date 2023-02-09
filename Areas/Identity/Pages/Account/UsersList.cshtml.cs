using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Identity.Models;

namespace WebApp1.Areas.Identity.Pages.Account
{
    public class UsersListModel : PageModel
    {
        private readonly WebApp1.Areas.Identity.Data.ApplicationDbContext _context;

        public UsersListModel(WebApp1.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ApplicationUser != null)
            {
                ApplicationUser = await _context.ApplicationUser.ToListAsync();
            }
        }
    }
}
