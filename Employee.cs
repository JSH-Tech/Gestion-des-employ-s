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
        int id;
        string firstName;
        string lastName;
        string email;

        public int Id { 
            get => this.id; 
            set => this.id = value; 
        }
        public string FirstName { 
            get => this.firstName; 
            set => this.firstName = value; 
        }


        public string Email { 
            get => this.email; 
            set => this.email = value; 
        }
        public string LastName { 
            get => this.lastName; 
            set => this.lastName = value; 
        }

        public Employee(int id, string firstName, string lastName, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
    }
}
