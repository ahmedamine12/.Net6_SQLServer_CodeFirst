using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP1.Data;

namespace TP1.Pages.EtudiantPages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
           // Etudiants = new List<Etudiant>(); // Initializing the list here
        }

        public IList<Etudiant> Etudiants { get; set; }

        public async Task OnGetAsync()
        {
            Etudiants = await _context.Etudiants.ToListAsync();
        }
        
        [BindProperty]
        public Etudiant NewEtudiant { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Etudiants.Add(NewEtudiant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Home");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var etudiant = await _context.Etudiants.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Home");
        }

        [BindProperty]
        public Etudiant EditEtudiant { get; set; }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (EditEtudiant == null || EditEtudiant.Id <= 0)
                return NotFound();

            var etudiantInDb = await _context.Etudiants.FindAsync(EditEtudiant.Id);
            if (etudiantInDb == null)
                return NotFound();

            etudiantInDb.Nom = EditEtudiant.Nom;
            etudiantInDb.Prenom = EditEtudiant.Prenom;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Home");
        }

        
        
        
    }
    

}