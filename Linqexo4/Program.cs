using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexo4
{

    class Program
    {
        static void Main(string[] args)
        {
            #region Noms
            List<string> Noms = new List<string>();
            Noms.Add("Nico");
            Noms.Add("Anto");
            Noms.Add("Luc");
            Noms.Add("Frank");
            Noms.Add("Alexis");
            Noms.Add("Maxime");
            #endregion
            #region Poste
            List<string> Poste = new List<string>();
            Poste.Add("Directeur");
            Poste.Add("Bras droit");
            Poste.Add("Commercial");
            Poste.Add("DRH");
            Poste.Add("Actionnaire");
            #endregion
            List<Employe> ListeEmploye = new List<Employe>();
            List<Fiche_De_Paye> ListeFicheDePaye = new List<Fiche_De_Paye>();

            for (int i = 0; i < 20; i++)
            {
                ListeEmploye.Add(new Employe(RandomMaison.Instance.Next(0, 100), Noms[RandomMaison.Instance.Next(0, Noms.Count)], Poste[RandomMaison.Instance.Next(0, Poste.Count)], RandomMaison.Instance.Next(1, 11)));
            }
            foreach (Employe item in ListeEmploye)
            {
                for (int i = 1; i < (item.anciennete)*12; i++)
                {
                    ListeFicheDePaye.Add( new Fiche_De_Paye(RandomMaison.Instance.Next(0, 10000), item.Nom, RandomMaison.Instance.Next(0, 152), RandomMaison.Instance.Next(0, 5), RandomMaison.Instance.Next(0, 10000)));
                }
            }

            foreach (Fiche_De_Paye item in ListeFicheDePaye)
            {
                Console.WriteLine("fiche de paye : "+item.IdFDP+" : "+item.NomSalarie+" gagne : "+item.Salaire+" euros");
            }

            IEnumerable<Fiche_De_Paye> QuerrySalaireMoyen =
                from Moyen in ListeFicheDePaye
                select Moyen;
            int total = 0;
            foreach (Fiche_De_Paye item in QuerrySalaireMoyen)
            {
                total += item.Salaire;
            }
            int moyenne = total / QuerrySalaireMoyen.Count<Fiche_De_Paye>();
            Console.WriteLine("salaire moyen des employés : "+moyenne+ " euros");

            Console.WriteLine("quel employé voulez vous avoir les fiche de paye ?");
            string employe = Console.ReadLine();
            IEnumerable<Fiche_De_Paye> querryFdpEmploye =
                from fdp in ListeFicheDePaye
                where fdp.NomSalarie == employe
                select fdp;

            foreach (Fiche_De_Paye item in querryFdpEmploye)
            {
                Console.WriteLine(item.IdFDP+" : gain du mois ==> "+item.Salaire+ " euros");
            }


            var querryAnciennete =
                from emp in ListeEmploye
                orderby emp.anciennete ascending
                select new { employe = emp, act = emp.anciennete };

            double totalAnciennete = 0;
            foreach (var item in querryAnciennete)
            {
                totalAnciennete += item.act;
                Console.WriteLine(item.employe.Nom);
            }

            double ancienneteMoyenne = totalAnciennete / querryAnciennete.Count();
            Console.WriteLine("anciennete moyenne : "+ancienneteMoyenne+" années");
            Console.WriteLine("quel poste voulez vous avoir le salaire moyen");
            string posteoccupe = Console.ReadLine();

            IEnumerable<Fiche_De_Paye> querryemp =
                from emp in ListeEmploye
                from fdp in ListeFicheDePaye
                where emp.poste == posteoccupe && fdp.NomSalarie == emp.Nom
                select fdp;

            int tot=0;
            foreach (Fiche_De_Paye item in querryemp)
            {
                tot += item.Salaire;
            }

            int salaireMoyenParPoste = tot / querryemp.Count<Fiche_De_Paye>();

            Console.WriteLine("Le salaire moyen des "+posteoccupe+" est de "+salaireMoyenParPoste+ " euros");
        }
    }
}
