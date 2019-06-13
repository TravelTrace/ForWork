using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Abstract
{
    interface IDivisionRepository
    {
        IEnumerable<Division> Divisions { get; }

        void AddDivision(Division division);
    }
}
