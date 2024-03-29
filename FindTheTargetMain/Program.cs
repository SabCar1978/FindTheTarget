﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool sluitProgramma = false;
            bool found = false;
            bool targetFound = false;
            int col = 0;
            int row = 0;
            int randomRow = 0;
            int randomCol = 0;
            char[,] game = new char[10, 10];

            Console.Title = "FIND THE TARGET!";
            Console.WriteLine(new String('=', 16));
            Console.WriteLine("Find the target!");
            Console.WriteLine(new String('=', 16));
            Console.WriteLine();

            // 10x10 tabel van streepjes definiëren
            for (int i = 0; i < game.GetLength(0); i++)
            {
                for (int j = 0; j < game.GetLength(1); j++)
                {
                    game[i, j] = '-';
                }
            }
            // randomgenerator voo willekeurig getal voor rij en kolom
            Random random = new Random();
            randomRow = random.Next(0, 10);
            randomCol = random.Next(0, 10);

            while (!sluitProgramma)
            {
                if (targetFound)
                {
                    // Nieuwe willekeurige getallen genereren als de target werd gevonden en de speler nogmaaals wil spelen
                    randomRow = random.Next(0, 10);
                    randomCol = random.Next(0, 10);
                }
                // Setten op de console van 10x10 tabel van streepjes.
                // Als de target niet gevonden werd dan wordt bij elke doorgang van de while-loop
                // een streepje vervangen door een X.
                //Controle of programma werkt: oplossing coördinaten waar target zich bevindt --> activeer/desactiveer regel hieronder
                Console.WriteLine("((Controle of programma met randomgetallen werkt: Rij= " + randomRow + "  Kolom= " + randomCol + "))");
                Console.WriteLine();
                for (int i = 0; i < game.GetLength(0); i++)
                {
                    for (int j = 0; j < game.GetLength(1); j++)
                    {
                        Console.Write(game[i, j] + "\t");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                //Aan de speler een getal tussen 0 en 9 vragen voor de coördinaat van de rij
                Console.WriteLine("Input a digit <0-9> for the row:");
                //Opvangen foutieve input
                while (!int.TryParse(Console.ReadLine(), out row))
                {
                    Console.WriteLine("Error in input!\nInput a digit <0-9> for the row:");
                }
                while (row >= 10)
                {
                    //Aan de speler een getal tussen 0 en 9 vragen voor de coördinaat van de rij
                    Console.WriteLine("Error! Input must be a digit from 0 to 9 for the row:");
                    //Opvangen foutieve input
                    while (!int.TryParse(Console.ReadLine(), out row))
                    {
                        Console.WriteLine("Error in input!\nInput a digit <0-9> for the row:");
                    }
                }
                //Aan de speler een getal tussen 0 en 9 vragen voor de coördinaat van de kolom
                Console.WriteLine("Input a digit <0-9> for the column:");
                //Opvangen foutieve input
                while (!int.TryParse(Console.ReadLine(), out col))
                {
                    Console.WriteLine("Error in input!\nInput a digit <0-9> for the column:");
                }
                while (col >= 10)
                {

                    //Aan de speler een getal tussen 0 en 9 vragen voor de coördinaat van de kolom
                    Console.WriteLine("Error! Input must be a digit from 0 to 9 for the column:");
                    //Opvangen foutieve input
                    while (!int.TryParse(Console.ReadLine(), out col))
                    {
                        Console.WriteLine("Error in input!\nInput a digit <0-9> for the column:");
                    }
                }
                Console.WriteLine();
                // Ingevoerde cöordinaten vergelijken met coördinaten van de te zoeken target              
                if (row == randomRow && col == randomCol)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("TARGET FOUND! Druk <enter> om opnieuw te spelen OF druk <E> om af te sluiten");
                    ConsoleKeyInfo exit = Console.ReadKey();
                    if (exit.Key == ConsoleKey.E)
                    {
                        sluitProgramma = true;
                        Environment.Exit(0);
                    }
                    else
                    {
                        targetFound = true;
                        Console.WriteLine(new String('=', 16));
                        Console.WriteLine("Find the target!");
                        Console.WriteLine(new String('=', 16));
                        Console.WriteLine();
                        for (int i = 0; i < game.GetLength(0); i++)
                        {
                            for (int j = 0; j < game.GetLength(1); j++)
                            {
                                game[i, j] = '-';
                            }
                        }
                    }
                }
                else
                {   //Als target niet gevonden, op de ingevoerde coördinaten en X plaatsen
                    targetFound = false;
                    game[row, col] = 'X';
                }
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}
