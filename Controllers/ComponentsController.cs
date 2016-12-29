using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE.Data;
using ASPNETCORE.Models.CategoryComponents;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCORE.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComponentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Components
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.Components.Where(x => x.ComponentTypeId == id).ToListAsync());
        }

        // GET: Components/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Components.SingleOrDefaultAsync(m => m.ComponentId == id);
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // GET: Components/Create
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentTypes = new SelectList(await _context.ComponentTypes.ToListAsync(), "ComponentTypeId", "ComponentName");
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ComponentId,AdminComment,ComponentNumber,ComponentTypeId,CurrentLoanInformationId,SerialNo,Status,UserComment")] Component component, int selectedComponentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(component);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(component);
        }

        // GET: Components/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Components.SingleOrDefaultAsync(m => m.ComponentId == id);
            if (component == null)
            {
                return NotFound();
            }
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(long id, [Bind("ComponentId,AdminComment,ComponentNumber,ComponentTypeId,CurrentLoanInformationId,SerialNo,Status,UserComment")] Component component)
        {
            if (id != component.ComponentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(component);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentExists(component.ComponentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(component);
        }

        // GET: Components/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Components.SingleOrDefaultAsync(m => m.ComponentId == id);
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var component = await _context.Components.SingleOrDefaultAsync(m => m.ComponentId == id);
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ComponentExists(long id)
        {
            return _context.Components.Any(e => e.ComponentId == id);
        }
    }
}
