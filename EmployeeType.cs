using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoJosueAbotsidiaUA3Projet
{

    // Classe abstraite EmployeeType
    public abstract class EmployeeType
    {
        private string typeEmploye;

        public EmployeeType(string typeEmploye)
        {
            this.typeEmploye = typeEmploye;
        }

        public string TypeEmploye { 
            get => typeEmploye; 
            set => typeEmploye = value; 
        }

        // Méthode CalculatePayment
        public abstract decimal CalculatePayment();

    }
}
