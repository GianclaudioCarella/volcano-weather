using Infrasctructure;
using Infrasctructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class YearService
    {
        private ApplicationDbContext _dbContext;

        public YearService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Year Get(string year)
        {
            return _dbContext.Years.Where(y => y.Name.Equals(year)).FirstOrDefault();
        }

        public List<Year> GetYears()
        {
            return _dbContext.Years.ToList();
        }

        public void Create(Year year)
        {
            _dbContext.Add(year);
            _dbContext.SaveChanges();
        }
    }
}
