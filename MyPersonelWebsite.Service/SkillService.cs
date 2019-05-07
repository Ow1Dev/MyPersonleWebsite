using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPersonelWebsite.Data;
using MyPersonelWebsite.Data.Models;

namespace MyPersonelWebsite.Service
{
     public class SkillService : ISkill
    {
        ApplicationDbContext _context;
        
        public SkillService(ApplicationDbContext context) =>
            _context = context;

        public Task Create(Skill skill)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditName(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task EditScore(int id, int score)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Skill> GetAll()
        {
            return _context.Skills.OrderBy(s => s.score);
        }
    }
}
