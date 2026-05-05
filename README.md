Projet TP Moyennes pour le module Programmation C# de la formation .NET.

Bien que le cas soit impossible dans l'exemple du programme vu que l'on attribut à chaque élève cinq notes par matière,
on considèrera qu'il est possible d'avoir des divisions par zéro:
- Si l'élève n'a aucune note dans une matière donnée,
- Si l'élève n'a aucune note,
- Si aucun élève n'a de note dans une matière donnée,
- Si une classe est vide (aucun élève n'a de notes ou aucune matière n'est enseignée).
Dans ces cas ci-dessus, on retournera une "note erreur" de -1. Ces cas seront exclus des statistiques de moyennes.

Exemple:
Si un élève appartient à une classe de huit élèves assistant à trois matières, et que cet élève n'a pas de note dans l'une d'elle,
sa moyenne générale sera calculée sur deux matières. Pour cette matière, la moyenne de la classe sera effectuée sur sept élèves.
