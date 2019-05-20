using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPersonelWebsite.Data;
using MyPersonelWebsite.Data.Models;

namespace MyPersonelWebsite.Service
{
    public class ContaktService : IContakt
    {
        private readonly ApplicationDbContext _context;

        public ContaktService(ApplicationDbContext context) => _context = context;

        public async Task Delete(int Id)
        {
            if (getById(Id) != null)
            {
                _context.Contacts.Remove(getById(Id));
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts;
        }

        public Contact getById(int Id)
        {
            return Id == 0 ? null : _context.Contacts.Where(c => c.Id == Id).FirstOrDefault();
        }

        public Contact Read(int Id)
        {
            var c = getById(Id);
            if (c != null)
            {
                c.HasRead = true;
                _context.Contacts.Update(c);
                _context.SaveChanges();
            }
            return c;
        }

        public async Task Send(string Email, string Content)
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Content))
            {
                _context.Contacts.Add(new Contact { Email = Email, Content = Content });
                await _context.SaveChangesAsync();
            }
        }
    }
}
