using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoJosueAbotsidiaUA3Projet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1- Création d'employés permanents
            Console.WriteLine("\n***** 1-1- Création d'employés permanents ****");          

            PermanentEmployee premierPermanentEmployee = new PermanentEmployee(1, "Alice", "Johnson", "alice.johnson@example.com", 4000, 100, 45);
			PermanentEmployee deuxiemePermanentEmployee = new PermanentEmployee(2, "Bob", "Brown", "bob.brown@example.com", 3500, 80, 40);

            // 1- Affichage des informations des employés permanents
            Console.WriteLine("\n***** 1-2- Affichage des informations des employés permanents ****");
            Console.WriteLine(premierPermanentEmployee.ToString());
            Console.WriteLine(deuxiemePermanentEmployee.ToString());

            // 2-1 Création d'employés temporaires
            Console.WriteLine("\n***** 2-1- Création d'employés temporaires ****");
			TemporaryEmployee firstTemporaryEmployee = new TemporaryEmployee(3, "Charlie", "Smith", "charlie.smith@example.com", 45);
			TemporaryEmployee secondTemporaryEmployee = new TemporaryEmployee(4, "David", "Jones", "david.jones@example.com", 50);
			TemporaryEmployee thirdTemporaryEmployee = new TemporaryEmployee(5, "Thomas", "Smith", "Thomas.smith@example.com", 45);
            
            // 2-2 Affichage des informations des employés permanents
            Console.WriteLine("\n***** 2-2- Affichage des informations des employés temporaires ****");
            Console.WriteLine(firstTemporaryEmployee.ToString());
            Console.WriteLine(secondTemporaryEmployee.ToString());
            Console.WriteLine(thirdTemporaryEmployee.ToString());

            List<EmployeeType> employees = new List<EmployeeType>();
            employees.Add(firstTemporaryEmployee);
            employees.Add(secondTemporaryEmployee);
            employees.Add(thirdTemporaryEmployee);
            employees.Add(premierPermanentEmployee);
            employees.Add(deuxiemePermanentEmployee);

            // 3- Affichage de la paie totale, triée par type d'employé
            Console.WriteLine("\n***** 3- Affichage de la paie totale, triée par type d'employé ****");
            var listTriee = employees.OrderBy(emp => emp.GetType().Name);

            foreach (var item in listTriee)
            {
                Console.WriteLine($"{item.LastName} {item.FirstName}, Payment: {item.CalculatePayment()}");
            }


            // 4-Affichage des totaux des salaires
            decimal totalPerm=0;
            decimal totalTemp=0;

            foreach (var item in listTriee)
            {
                if (item is TemporaryEmployee)
                {
                    totalTemp = totalTemp + item.CalculatePayment();
                }
                else
                {
                    totalPerm =totalPerm+item.CalculatePayment();
                }
            }

            Console.WriteLine("\n***** 4- Affichage des totaux des salaires ****");
            Console.WriteLine($"Paiement total pour les employés permanents: {totalPerm}");
            Console.WriteLine($"Paiement total pour les employés temporaires:{totalTemp} ");

            // 5-Mise à jour de la prime fixe pour un employé permanent 
            Console.WriteLine("\n***** 5- Mise à jour de la prime fixe pour un employé permanent ****");

            // Chercher un employé permanent uniquement par nom et prénom
            string reponse="o";
            PermanentEmployee foundEmployee = null;

            do
            {
                
                Console.WriteLine("Entrez le prénom de l'employé :");
                string prenomSaisie=Console.ReadLine();

                Console.WriteLine("Entrez le nom de l'employé :");
                string nomSaisie=Console.ReadLine();
                //Verification des valeurs saisies
                if (string.IsNullOrEmpty(prenomSaisie) || string.IsNullOrEmpty(nomSaisie))
                {
                    Console.WriteLine("Le prenom ou le nom ne doit pas etre une valeur null");
                    continue;
                }
                else
                {
                    //Boucle de recherche de l'employe
                    foreach (var item in employees)
                    {
                        if (item is PermanentEmployee)
                        {
                            if (item.LastName.Equals(nomSaisie, StringComparison.OrdinalIgnoreCase) && item.FirstName.Equals(prenomSaisie, StringComparison.OrdinalIgnoreCase))
                            {
                                foundEmployee = item as PermanentEmployee;
                                break;
                            }
                        }
                    }
                    //Employee non trouve
                    if (foundEmployee==null)
                    {
                        Console.WriteLine("Aucun employé permanent trouvé avec ce nom et prénom.");
                        Console.WriteLine("Aucun employé permanent trouvé avec ce nom et prénom. Voulez-vous essayer à nouveau ? (O/N)");
                        reponse = Console.ReadLine().ToLower();
                    }
                }
            }while (foundEmployee==null && reponse.Equals( "o"));

            if (foundEmployee == null)
            {
                return;
            }
            else
            { 
                //Employee trouve
                Console.WriteLine($"\nEmployé permanent trouvé : {foundEmployee.FirstName} {foundEmployee.LastName}");
                Console.WriteLine(foundEmployee.ToString());
            }

            // Saisir le nouveau montant du bonus fixe
            Console.WriteLine("Entrez le nouveau montant du bonus fixe :");
            int newBonus=0;
            bool conversion= int.TryParse(Console.ReadLine(), out newBonus);
            // Ajouter le nouveau bonus à l'employé (FixedBonus + newBonus)
            // Mettre à jour le bonus fixe de l'employé
            if (conversion)
            {
                foundEmployee.setFixedBonus(foundEmployee.FixedBonus + newBonus);

            }
            else
            {
                Console.WriteLine("La valeur de la nouvelle bonus est incorrect");
                return;
            }

            Console.WriteLine($"Le nouveau montant total du bonus pour  est : {foundEmployee.FixedBonus}");
            Console.WriteLine(foundEmployee.ToString());

            // 6- Mise à jour du nombre d'heures travaillées pour un employé temporaire
            Console.WriteLine("\n***** 6-Mise à jour du nombre d'heures travaillées pour un employé temporaire ****");
            string reponse2 = "o";
            TemporaryEmployee foundEmployee2 = null;
            do { 
                // Demander à l'utilisateur de saisir le nombre d'heures travaillées pour un employé temporaire spécifique
                Console.WriteLine("Entrez le prénom de l'employé temporaire :");
                string prenomSaisie2 = Console.ReadLine();

                Console.WriteLine("Entrez le nom de l'employé temporaire :");
                string nomSaisie2 = Console.ReadLine();

                if (string.IsNullOrEmpty(prenomSaisie2) || string.IsNullOrEmpty(nomSaisie2))
                {
                    Console.WriteLine("Le prenom ou le nom ne doit pas etre une valeur null");
                    continue;
                }
                else
                {
                    //Boucle de recherche de l'employe
                    foreach (var item in employees)
                    {
                        if (item is TemporaryEmployee)
                        {
                            if (item.LastName.Equals(nomSaisie2, StringComparison.OrdinalIgnoreCase) && item.FirstName.Equals(prenomSaisie2, StringComparison.OrdinalIgnoreCase))
                            {
                                foundEmployee2 = item as TemporaryEmployee;
                                break;
                            }
                        }
                    }
                    //Employee non trouve
                    if (foundEmployee2 == null)
                    {
                        Console.WriteLine("Aucun employé temporaire trouvé avec ce nom et prénom. Voulez-vous essayer à nouveau ? (O/N)");
                        reponse2 = Console.ReadLine().ToLower();
                    }
                }
            }while (foundEmployee2==null && reponse2.Equals( "o"));
            if (foundEmployee == null)
            {
                return;
            }
            else
            {
                //Employee trouve
                Console.WriteLine($"L'employé temporaire {foundEmployee2.FirstName} {foundEmployee2.LastName} a travaillé {foundEmployee2.HourNumber} heures.");
            }


            // Demander à l'utilisateur de saisir le nombre d'heures travaillées pour cet employé temporaire
            Console.WriteLine("\nEntrez le nombre d'heures travaillées pour cet employé temporaire :");
            int newHourNumber = 0;
            bool conversion2 = int.TryParse(Console.ReadLine(), out newHourNumber);

            Console.WriteLine(foundEmployee2.ToString());

            if (conversion2)
            {

                // Mettre à jour le nombre d'heures travaillées pour l'employé temporaire

                foundEmployee2.setHourNumber(foundEmployee2.HourNumber + newHourNumber);
            }
            else
            {
                Console.WriteLine("La valeur du nombre dheure est incorrect");
                return;
            }

            // Afficher à nouveau les informations mises à jour pour l'employé temporaire
            Console.WriteLine($"Informations mises à jour pour  {foundEmployee2.FirstName} {foundEmployee2.LastName} :");
            Console.WriteLine(foundEmployee2.ToString() );

            // Calcul des heures supplémentaires pour les employés permanents
            Console.WriteLine("\n***** 7-Calcul des heures supplémentaires pour les employés permanents *****");
            int heureSup = 0;
            foreach (var item in employees)
            {
                if (item is PermanentEmployee itemi)
                {
                    heureSup = itemi.HourNumber - 40;

                    Console.WriteLine($"{itemi.FirstName} {itemi.LastName} - Heures supplémentaires: {heureSup}");
                }
            }

            // 8-  la liste de tous les employés avec leurs détails et le salaire, triée par type d'employé

            Console.WriteLine(" afficher la liste de tous les employés avec leurs détails et le salaire, triée par type d'employé");

            TemporaryEmployee te1 = new TemporaryEmployee(6, "Isabella", "Garcia", "isabella.garcia@example.com", 36);
            TemporaryEmployee te2 = new TemporaryEmployee(7, "James", "Rodriguez", "james.rodriguez@example.com", 38);

            PermanentEmployee pe1 = new PermanentEmployee("David", "Taylor", "david.taylor@example.com", 4700, 100);
            PermanentEmployee pe2 = new PermanentEmployee("Emma", "Wilson", "emma.wilson@example.com", 5100, 120);
            PermanentEmployee pe3 = new PermanentEmployee("James", "Johnson", "james.johnson@example.com", 4900, 110);

            employees.Add(te1);
            employees.Add(te2);
            employees.Add(pe1);
            employees.Add(pe2);
            employees.Add(pe3);
            // Trier les employés par type d'employé
            // Afficher la liste des employés avec leurs détails et le salaire
            Console.WriteLine("\n***** 8-Liste des employés avec leurs détails et le salaire trie par type d'employe *******");
            var nouvelTrie=employees.OrderBy(empl=>empl.GetType().Name);
            foreach (var item in nouvelTrie)
            {
                if (item is PermanentEmployee iteme)
                {
                    Console.WriteLine($"Permanent Employee: {iteme.FirstName} {iteme.LastName}, ID: {iteme.Id}, Email: {iteme.Email}, Salary: {iteme.Salary} ");
                }
                else
                {
                    Console.WriteLine($"Temporary Employee : {item.FirstName} {item.LastName}, ID: {item.Id}, Email: {item.Email}, Hourly Payement: {item.CalculatePayment()}");
                }
            }

           
        }


    }
}
