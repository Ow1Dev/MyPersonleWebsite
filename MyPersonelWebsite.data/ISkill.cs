using MyPersonelWebsite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Data
{
    public interface ISkill
    {
        IEnumerable<Skill> GetAll();

        Task Create(Skill skill);
        Task EditScore(int id, int score);
        Task EditName(int id, string name);
        Task Delete(int id);
    }
}
