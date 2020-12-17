using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mio1412.Data;
using mio1412.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace mio1412.Controllers
{
    public class ReportsController : Controller
    {
        private readonly dbContext _context;
        

        public ReportsController(dbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string txtDate)
        {
            var aid = HttpContext.Session.GetInt32("aid");
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            if (aid == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            if (txtDate != null)
            {
                ViewBag.crDate = txtDate;
                return View(await _context.Report.OrderByDescending(m => m.DateCreated)
                    .Where(m => m.DateCreated.ToString().Contains(txtDate) && m.AccountId.Equals(aid)).ToListAsync());
            }

            
            return View(await _context.Report.OrderByDescending(m => m.DateCreated)
                .Where(m => m.DateCreated.ToString().Contains(currentDate) && m.AccountId.Equals(aid)).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                report.DateCreated = DateTime.Now;
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        [HttpPost]
        public int CreateAjax(string txtAid, string txtName, string txtPro, string txtIss)
        {
            if (txtAid != null)
            {
                int aId = int.Parse(txtAid);
                Report report = new Report { AccountId = aId, Task_Name = txtName, Issues = txtIss, Progress = txtPro };
                report.DateCreated = DateTime.Now;
                _context.Add(report);
                _context.SaveChanges();

                Report obj = _context.Report.SingleOrDefault(m => m.AccountId.Equals(report.AccountId) &&
                    m.DateCreated.Equals(report.DateCreated));

                
                return obj.Id;
            }
            return 0;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Report report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Report.FindAsync(id);
            _context.Report.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.Id == id);
        }
    }
}
