using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoJosueAbotsidiaUA3Projet
{
    // Classe PermanentEmployee
    public class PermanentEmployee:Employee,IPayment
    {
        // Propriétés
        decimal salary;
        decimal fixedBonus;
        // Nombre d'heures travaillées par l'employé permanent
        int hourNumber; 

        // Constructeur
        public PermanentEmployee(int id, string firstName, string lastName, string email, decimal salary, decimal fixedBonus, int hourNumber)
         : base(id, firstName, lastName, email)
        {
            this.salary = salary;
            this.fixedBonus = fixedBonus;
            this.hourNumber = hourNumber;
        }

        public decimal Salary { 
            get => salary; 
            set => salary = value; 
        }
        public decimal FixedBonus { 
            get => fixedBonus;
        }
        public int HourNumber { 
            get => hourNumber; 
            set => hourNumber = value; 
        }

        // Méthode SetFixedBonus
        public void setFixedBonus(decimal bonus) {
            this.fixedBonus = bonus;
        }

        // Méthode CalculatePayment: Salary + FixedBonus + (HourNumber-40)*100;
        public decimal CalculatePayment()
        {
            return Salary + FixedBonus + (HourNumber - 40) * 100;
        }

        // Méthode
        public override string ToString()
        {
            // Définition de la méthode ToString pour afficher les informations de l'employé permanent
            return $"Permanent Employee: {FirstName} {LastName}, Email: {Email}, Salary: {Salary}, Fixed Bonus: {FixedBonus},Hours Worked: {HourNumber}"; 
        }
    }

}
