using MyPersonelWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Data
{
    public interface IContakt
    {
        IEnumerable<Contact> GetAll();
        Contact getById(int Id);
        Contact Read(int Id);

        Task Send(string Email, string Content);
        Task Delete(int Id);
    }
}
