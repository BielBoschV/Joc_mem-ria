using Joc_memòria;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crea una llista de números
        List<int> numbers = new List<int>();
        // Crea un objecte Random per generar números aleatoris
        Random random = new Random();

        // Afegeix 10 parells de números aleatoris a la llista
        for (int i = 1; i <= 10; i++)
        {
            int number = random.Next(0, 100);
            numbers.Add(number);
            numbers.Add(number);
        }

        // Barreja la llista de números
        Shuffle(numbers);

        // Inicialitza les variables de comptador i puntuació
        int count = 0;
        int score = 0;

        // Bucle principal del joc
        while (count < 20 && score >= -10)
        {
            // Neteja la pantalla i mostra la puntuació
            Console.Clear();
            Console.WriteLine("Puntuació: {0}", score);

            // Crea un objecte Correcte per mostrar els números correctes
            Correcte correcte = new Correcte();
            correcte.Fet = " $ ";

            // Mostra la llista de números en forma de taula
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine();
                }

                if (numbers[i] == -1)
                {
                    Console.Write("   ");
                }
                else if (numbers[i] == -2)
                {
                    Console.Write(correcte.Fet);
                }
                else
                {
                    Console.Write("{0,2} ", numbers[i]);
                }
            }

            Console.WriteLine();

            // Demana al usuari que introdueixi el primer número
            int first;
            do
            {
                Console.Write("Introdueix el primer número: ");
                first = int.Parse(Console.ReadLine());
            } while (first < 0 || first >= numbers.Count || numbers[first] == -1 || numbers[first] == -2);

            // Demana al usuari que introdueixi el segon número
            int second;
            do
            {
                Console.Write("Introdueix el segon número: ");
                second = int.Parse(Console.ReadLine());
            } while (second < 0 || second >= numbers.Count || second == first || numbers[second] == -1 || numbers[second] == -2);

            // Comprova si els dos números són iguals
            if (numbers[first] == numbers[second])
            {
                // Si són iguals, marca'ls com a correctes i augmenta la puntuació i el comptador
                numbers[first] = -2;
                numbers[second] = -2;
                score += 5;
                count += 2;
            }
            else
            {
                // Si no són iguals, disminueix la puntuació
                score -= 3;
            }
        }

        // Neteja la pantalla i mostra el missatge final i la puntuació final
        Console.Clear();
        if (score < -10)
        {
            Console.WriteLine("Ets molt dolent, prova-ho a la pròxima.");
        }
        else
        {
            Console.WriteLine("Fi del joc!");
        }
        Console.WriteLine("Puntuació: {0}", score);
    }

    // Funció per barrejar una llista de manera aleatòria
    static void Shuffle<T>(IList<T> list)
    {
        Random random = new Random();

        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}