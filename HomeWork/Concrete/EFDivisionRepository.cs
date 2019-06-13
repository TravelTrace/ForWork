using HomeWork.Abstract;
using HomeWork.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{
    public class EFDivisionRepository : IDivisionRepository {
        private HomeWorkContext context = new HomeWorkContext();
        IEnumerable<Division> IDivisionRepository.Divisions {
            get { return context.Division; }  
        }

        void IDivisionRepository.AddDivision(Division division) {
            context.Division.Add(division);
            context.SaveChanges();
        }
    }
}
