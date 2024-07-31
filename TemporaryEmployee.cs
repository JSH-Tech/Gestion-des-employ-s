using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoJosueAbotsidiaUA3Projet
{
    // Classe TemporaryEmployee
    public class TemporaryEmployee:EmployeeType, IPayment
    {
        // Propriétés
        // Nombre d'heures travaillées par l'employé temporaire
        private int hourNumber;
       
        public int HourNumber { 
            get => hourNumber;
        }

        // Constructeur
        public TemporaryEmployee(int id, string firstName, string lastName, string email,int hourNumber) : base(id, firstName, lastName, email)
        {
            this.setHourNumber(hourNumber);
        }


        // Méthode SetHourNumber
        public void setHourNumber(int hours)
        {
            this.hourNumber = hours;
        }

        // Méthode CalculatePayment
        public override decimal CalculatePayment()
        {
            return HourNumber * 100;
        }

        // Méthode ToString
        public override string ToString()
        {
            return $"Temporary Employee: {FirstName} {LastName}, Email: {Email}, Hours Worked: {HourNumber}, Payment: {CalculatePayment()}"; // Définition de la méthode ToString pour afficher les informations de l'employé temporaire
        }


    }
}
