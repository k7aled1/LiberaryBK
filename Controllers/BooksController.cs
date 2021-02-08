using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiberaryBK.Data;
using LiberaryBK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace LiberaryBK.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public BooksController(ApplicationDbContext context,IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Books
        public async Task<IActionResult> Index(int? typeId)
        {
            if(typeId == null)
            {
                var applicationDbContext = _context.Books.Include(b => b.TypeF1Navigation).Include(b => b.Userr);
                return View(await applicationDbContext.ToListAsync());
            }
            var BooksByType = _context.Books.Where(typ => typ.TypeF1 == typeId).Include(b => b.TypeF1Navigation).Include(b => b.Userr);
            return View(await BooksByType.ToListAsync());

           
        }
        public async Task<IActionResult> Search(string searchValue)
        {
            if (searchValue != null)
            {
                var BooksByName = _context.Books.Where(bName => bName.BookName.Contains(searchValue)).Include(b => b.TypeF1Navigation).Include(b => b.Userr);
                if(BooksByName != null)
                {
                    return View("Index", await BooksByName.ToListAsync());
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.TypeF1Navigation)
                .Include(b => b.Userr)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["TypeF1"] = new SelectList(_context.Types, "TypeId", "TypeName");
            ViewData["Writer"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,Price,TypeF1,Description,Writer")] Books books, IFormFile bookCover, IFormFile bookPdf)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (bookPdf != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "pdf");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + bookPdf.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    bookPdf.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                string uniquePicName = null;
                if (bookCover != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniquePicName = Guid.NewGuid().ToString() + "_" + bookCover.FileName;
                    string filePath = Path.Combine(uploadFolder, uniquePicName);
                    bookCover.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                books.BookCover = uniquePicName;
                books.BookPdf = uniqueFileName;
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeF1"] = new SelectList(_context.Types, "TypeId", "TypeName", books.TypeF1);
            ViewData["Writer"] = new SelectList(_context.Users, "Id", "Name", books.Writer);
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["TypeF1"] = new SelectList(_context.Types, "TypeId", "TypeName", books.TypeF1);
            ViewData["Writer"] = new SelectList(_context.Users, "Id", "Name", books.Writer);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,Price,TypeF1,BookPdf,Description,BookCover,Writer")] Books books)
        {
            if (id != books.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.BookId))
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
            ViewData["TypeF1"] = new SelectList(_context.Types, "TypeId", "TypeName", books.TypeF1);
            ViewData["Writer"] = new SelectList(_context.Users, "Id", "Name", books.Writer);
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.TypeF1Navigation)
                .Include(b => b.Userr)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Books.FindAsync(id);
            _context.Books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
