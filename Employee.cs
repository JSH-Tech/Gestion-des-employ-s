using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoJosueAbotsidiaUA3Projet
{
    // Classe abstraite Employee
    public abstract class Employee
    {
        // Propriétés
        int Id;
        string FirstName;
        string LastName;
        string Email;

        public int Id1 { 
            get => Id; 
            set => Id = value; 
        }
        public string FirstName1 { 
            get => FirstName; 
            set => FirstName = value; 
        }


        public string Email1 { 
            get => Email; 
            set => Email = value; 
        }
        public string LastName1 { 
            get => LastName; 
            set => LastName = value; 
        }
    }
}
