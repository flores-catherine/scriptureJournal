using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        public string SearchBook { get; set; }
        public SelectList Books { get; set; }
        public string Book { get; set; }


        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public string SearchString { get; set; }


        public async Task OnGetAsync(string searchBook, string searchString, string sortOrder)
        {
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "dateAdded";

            var scriptures = from m in _context.Scripture
                             select m;

            if (!String.IsNullOrEmpty(searchBook))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(searchBook));
                SearchBook = searchBook;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(searchString));
                SearchString = searchString;
            }

            switch (sortOrder)
            {
                case "book":
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
                case "dateAdded":
                    scriptures = scriptures.OrderBy(s => s.DateAdded);
                    break;
            }

            Scripture = await scriptures.ToListAsync();
        }
    }
}
