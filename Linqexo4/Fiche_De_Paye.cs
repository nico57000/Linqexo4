using System;
using System.Collections.Generic;
using System.Text;

namespace Linqexo4
{
    class Fiche_De_Paye
    {
        private int _IdFDP;

        public int IdFDP
        {
            get { return _IdFDP; }
            set { _IdFDP = value; }
        }

        private string _NomSalarie;

        public string NomSalarie
        {
            get { return _NomSalarie; }
            set { _NomSalarie = value; }
        }

        private int _NbHeures;

        public int NbHeures
        {
            get { return _NbHeures; }
            set { _NbHeures = value; }
        }

        private int _NbHeuresSup;

        public int NbHeuresSup
        {
            get { return _NbHeuresSup; }
            set { _NbHeuresSup = value; }
        }

        private int _Salaire;

        public int Salaire
        {
            get { return _Salaire; }
            set { _Salaire = value; }
        }

        public Fiche_De_Paye(int idFDP, string nomSalarie, int nbHeures, int nbHeuresSup, int salaire)
        {
            IdFDP = idFDP;
            NomSalarie = nomSalarie;
            NbHeures = nbHeures;
            NbHeuresSup = nbHeuresSup;
            Salaire = salaire;
        }

    }
}
