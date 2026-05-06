using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        //Je définis les propriétés d'un objet Eleve: il a un prénom, un nom et une liste de notes (une Note indique la matière dans laquelle la note a été obtenue). 
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }

        //Constructeur: on doit indiquer un prénom et un nom. La liste de notes est initialisée à une liste vide.
        public Eleve(string p, string n){
            prenom = p;
            nom = n;
            notes = new List<Note>();
        }

        //Méthode pour ajouter une note à un élève.
        public void ajouterNote(Note note)
        {
            notes.Add(note);
        }

        //Méthode pour calculer la moyenne d'un élève dans une matière donnée
        public float moyenneMatiere(int imatiere)
        {
            //J'initialise une variable pour stocker la somme des notes obtenues (en float) dans la matière et une variable compteur
            var somme = 0f;
            var n = 0;

            //Pour chaque note de l'élève, si la matière correspond à la matière en entrée, on ajoute la note à la somme.
            foreach (Note note in notes)
            {
                if (note.matiere == imatiere)
                {
                    n++; //On ajoute 1 au compteur
                    somme += note.note; 

                }
            }

            //J'ai souhaité utiliser un bloc try-catch pour gérer la division par 0 dans le cas où l'élève n'aurait aucune note dans la matière,
            //mais il semble que la division par 0 est comprise et retourne NaN, et ne rendre donc pas dans le catch. J'ai donc décidé de faire
            //un simple if-else.
            if (n == 0)
            {
                return -1; // On retourne -1 pour coller au type de retour de la méthode.
            }
            else
            {
                //On calcule la moyenne et on la retourne sous forme de décimal à 2 chiffres après la virgule.
                var moyenne = somme/n;
                return MathF.Round(moyenne,2);

            }
        }

        //Méthode pour calculer la moyenne générale d'un élève.
        public float moyenneGeneral()
        {
            //On crée une variable pour stocker la somme des moyennes et une variable compteur
            var somme = 0f;
            var n = 0;

            //On calcule la moyenne générale de l'élève à partir de ses moyennes dans chaque matière: on sait qu'un élève participe au plus à 10 matières.
            for (int i = 0; i<10; i++)
            {
                //Pour la matière i, on calcule la moyenne de l'élève.
                var moyMatiere = moyenneMatiere(i);
                //Si la moyenne est égale a -1, l'élève n'a pas de note dans cette matière. Alors on passe cette matière, c'est-à-dire: on ne s'interesse
                //qu'au cas de figure où la moyenne de l'élève est différente de -1 (=code erreur).
                if (moyMatiere!= -1) 
                {
                    somme += moyMatiere;
                    n++;
                }
            }

            //On retourne la moyenne générale avec deux chiffres après la virgule. On considère le cas de figure où l'élève n'a de note
            ////dans aucune matière.
            if (n == 0)
            {
                return -1; // On retourne -1 pour coller au type de retour de la méthode.
            }
            else
            {
                var moyenneG = somme / n;
                return MathF.Round(moyenneG, 2);
            }
        }
    }
}
