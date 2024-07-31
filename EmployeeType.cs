using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoJosueAbotsidiaUA3Projet
{

    // Classe abstraite EmployeeType
    public abstract class EmployeeType:Employee, IPayment
    {

        protected EmployeeType(int id, string firstName, string lastName, string email) : base(id, firstName, lastName, email)
        {
            
        }
        
        // Méthode CalculatePayment
        public abstract decimal CalculatePayment();

    }
}
