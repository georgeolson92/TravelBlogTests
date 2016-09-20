using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Models
{
   public interface IPeopleRepository
    {
        IQueryable<People> Peoples { get; }
        People Save(People people);
        People Edit(People people);
        void Remove(People people);
    }
}
