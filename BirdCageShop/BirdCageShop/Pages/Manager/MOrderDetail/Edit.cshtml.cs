using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdCageShop.Pages.Manager.MOrderDetail
{
    public class EditModel : PageModel
    {
        private readonly BusinessObjects.Models.CageShopUni_alaContext _context;

        public EditModel(BusinessObjects.Models.CageShopUni_alaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = await _context.OrderDetails
                .Include(o => o.Accessory)
                .Include(o => o.Cage)
                .Include(o => o.Order).FirstOrDefaultAsync(m => m.DetailId == id);

            if (OrderDetail == null)
            {
                return NotFound();
            }
           ViewData["AccessoryId"] = new SelectList(_context.Accessories, "AccessoryId", "AccessoryId");
           ViewData["CageId"] = new SelectList(_context.Products, "CageId", "CageId");
           ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
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

            _context.Attach(OrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.DetailId))
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

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.DetailId == id);
        }
    }
}
