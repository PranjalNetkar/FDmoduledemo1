using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FDmoduledemo1.Data;
using FDmoduledemo1.Models;
using Microsoft.AspNetCore.Http;

namespace FDmoduledemo1.Controllers
{
    public class RDsController : Controller
    {
        private readonly FDmoduledemo1Context _context;

        public RDsController(FDmoduledemo1Context context)
        {
            _context = context;
        }

        // GET: RDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.RD.ToListAsync());
        }

        // GET: RDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rD = await _context.RD
                .FirstOrDefaultAsync(m => m.RdId == id);
            if (rD == null)
            {
                return NotFound();
            }

            return View(rD);
        }

        // GET: RDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RdId,RdInvMon,Time,Period,n,UserID,FdMAmount,FdInMoney")] RD rD)
        {
            if (ModelState.IsValid)
            {
                double t = rD.Time;
                int v = (int)t;
                double r;
                HttpContext.Session.SetInt32("Duration", v);
                double P = rD.RdInvMon;
                if (t <= 3)
                {
                    r = 0.0551;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else if (t <= 6)
                {
                    r = 0.0675;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else if (t <= 12)
                {
                    r = 0.08;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else if (t <= 24)
                {
                    r = 0.1;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else
                {
                    r = 0.2;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }

                rD.FdInMoney = rD.FdMAmount - (P * t);
                int conamount = (int)rD.FdMAmount;
                int inamount = (int)rD.RdInvMon;
                int result = (int)rD.FdInMoney;
                HttpContext.Session.SetInt32("InterestOnRd", result);
                double rateinper = 100 * r;
                string Interest = Convert.ToString(rateinper);
                HttpContext.Session.SetString("RateOFInterest", Interest);

                HttpContext.Session.SetInt32("MaturityAmount", conamount);
                HttpContext.Session.SetInt32("IntvestAmount", inamount);

                _context.Add(rD);
                await _context.SaveChangesAsync();
                return RedirectToAction("RDSuccess");
            }
            return View(rD);
        }
        public IActionResult RDSuccess()
        {
            ViewBag.MaturityAmount = HttpContext.Session.GetInt32("MaturityAmount");
            ViewBag.InterestAmount = HttpContext.Session.GetInt32("InterestOnRd");
            ViewBag.time = HttpContext.Session.GetInt32("Duration");
            ViewBag.RateOfInterest = HttpContext.Session.GetString("RateOFInterest");
            ViewBag.PrincipleAmount = HttpContext.Session.GetInt32("IntvestAmount");
            return View();
        }

        // GET: RDs/RD
        public IActionResult RD()
        {
            return View();
        }

        // POST: RDs/RD
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RD([Bind("RdId,RdInvMon,Time,Period,n,UserID,FdMAmount,FdInMoney")] RD rD)
        {          
            if (ModelState.IsValid)
            {
                double t = rD.Time;
                int v = (int)t;
                double r;
                HttpContext.Session.SetInt32("Duration", v);
                double P = rD.RdInvMon;
                if (t <= 3)
                {
                    r = 0.0551;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else if (t <= 6)
                {
                    r = 0.0675;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else if (t <= 12)
                {
                    r = 0.08;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else if (t <= 24)
                {
                    r = 0.1;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }
                else
                {
                    r = 0.2;
                    double x = 1 + (r / 1);
                    double y = t / 12;
                    double z = Math.Pow(x, y);
                    rD.FdMAmount = P * z * t;
                }


                rD.FdInMoney = rD.FdMAmount - (P * t);
                int conamount = (int)rD.FdMAmount;
                int inamount = (int)rD.RdInvMon;
                int result = (int)rD.FdInMoney;
                HttpContext.Session.SetInt32("InterestOnRd", result);
                double rateinper = 100 * r;
                string Interest = Convert.ToString(rateinper);
                HttpContext.Session.SetString("RateOFInterest", Interest);

                HttpContext.Session.SetInt32("MaturityAmount", conamount);
                HttpContext.Session.SetInt32("IntvestAmount", inamount);

                _context.Add(rD);
                await _context.SaveChangesAsync();
                return RedirectToAction("RDCalculator");
            }
            return View(rD);
        }

        public IActionResult RDCalculator()
        { 
            ViewBag.MaturityAmount = HttpContext.Session.GetInt32("MaturityAmount");
            ViewBag.InterestAmount = HttpContext.Session.GetInt32("InterestOnRd");
            ViewBag.time = HttpContext.Session.GetInt32("Duration");
            ViewBag.RateOfInterest = HttpContext.Session.GetString("RateOFInterest");
            ViewBag.PrincipleAmount = HttpContext.Session.GetInt32("IntvestAmount");
            return View();
        }

        // GET: RDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rD = await _context.RD.FindAsync(id);
            if (rD == null)
            {
                return NotFound();
            }
            return View(rD);
        }

        // POST: RDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RdId,RdInvMon,Time,Period,n,UserID,FdMAmount,FdInMoney")] RD rD)
        {
            if (id != rD.RdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RDExists(rD.RdId))
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
            return View(rD);
        }

        // GET: RDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rD = await _context.RD
                .FirstOrDefaultAsync(m => m.RdId == id);
            if (rD == null)
            {
                return NotFound();
            }

            return View(rD);
        }

        // POST: RDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rD = await _context.RD.FindAsync(id);
            _context.RD.Remove(rD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RDExists(int id)
        {
            return _context.RD.Any(e => e.RdId == id);
        }
    }
}
