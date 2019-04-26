using System;
using System.Collections.Generic;
using System.Text;

namespace Linqexo4
{
    class Employe
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        private string _Poste;

        public string poste
        {
            get { return _Poste; }
            set { _Poste = value; }
        }


        private double _Anciennete;

        public double anciennete
        {
            get { return _Anciennete; }
            set { _Anciennete = value; }
        }

        public Employe(int id, string nom, string poste, double anciennete)
        {
            Id = id;
            Nom = nom;
            this.poste = poste;
            this.anciennete = anciennete;
        }
    }
}
