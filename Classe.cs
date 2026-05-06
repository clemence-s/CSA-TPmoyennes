using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        //Propriétés d'une classe: nom de la classe, liste d'élèves qui sont des objets Eleve et liste des matières
        //Note: pas besoin de créer une classe Matiere, les matières sont manipulées grâce à leur position dans la collection
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; } = new List<Eleve>();
        public List<string> matieres { get; private set; } = new List<string>();

        //Constructeur: on doit indiquer un nom de classe.
        public Classe(string c){
            nomClasse = c;
        }

        //Méthode pour ajouter un élève à la classe qui prend en entrée le prénom et le nom de l'élève
        public void ajouterEleve(string prenom, string nom)
        {
            //Je créé un nouvel objet Eleve, je lui attribue les valeurs prénom et nom en entrée et je l'ajoute à la liste
            Eleve eleve = new Eleve(prenom, nom);
            eleves.Add(eleve);
        }

        //Méthode pour ajouter une matière à la classe
        public void ajouterMatiere(string nomMatiere)
        {
            matieres.Add(nomMatiere);
        }

        //Méthode pour calculer la moyenne de la classe dans une matière donnée
        public float moyenneMatiere(int imatiere)
        {
            //On initialise une variable de somme et un compteur
            var somme = 0f;
            var n = 0;

            //On calcule la moyenne de la classe dans une matière en faisant la moyenne des moyennes des élèves dans la matière donnée
            foreach(Eleve eleve in eleves)
            {
                var moyEleveMatiere = eleve.moyenneMatiere(imatiere);
                //Si l'élève a bien une moyenne dans la matière, on la prend en compte.
                if (moyEleveMatiere != -1)
                {
                    somme += moyEleveMatiere;
                    n++;
                }
            }

            //Bien qu'improbable, on considère le cas où aucun élève de la classe n'a eu de note dans la matière donnée.
            //Comme pour la classe Eleve, on utilise un if-else à la place d'un try-catch pour la division par 0.
            if (n == 0)
            {
                return -1; //On retourne -1 pour coller au type de la méthode.
            }
            else
            {
                var moyClasseMatiere = somme / n;
                return MathF.Round(moyClasseMatiere, 2);
            }

        }

        //Méthode pour calculer la moyenne générale de la classe.
        public float moyenneGeneral()
        {
            //Initialisation de la somme et du compteur
            var somme = 0f;
            var n = 0;

            //On calcule la moyenne générale de la classe en faisant la moyenne des moyennes de la classe dans chaque matière.
            var i = 0;
            while (i < matieres.Count)
            {
                var moyClasseMatiere = moyenneMatiere(i);
                if (moyClasseMatiere != -1)
                {
                    somme += moyClasseMatiere;
                    n++;
                }
                i++;
            }

            //Comme précédemment, on considère le cas où la classe est vide: il n'y a aucun élève (donc aucune moyenne par matière) ou aucune matière.
            if (n == 0)
            {
                return -1; //On retourne -1 pour coller au type de la méthode.
            }
            else
            {
                var moyClasseG = somme / n;
                return MathF.Round(moyClasseG, 2);

            }
        }

    }
}
