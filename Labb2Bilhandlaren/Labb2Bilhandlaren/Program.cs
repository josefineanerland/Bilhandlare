using Labb2Bilhandlaren;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Bilhandlaren
{
    class Program
    {




        static void Main(string[] args)
        {
            bool running = true;
            Metoder metoder = new Metoder();
            int antal = 0;
            Console.WriteLine();
            Console.WriteLine("Du är bilhandlare och ska registrera vad du har i lager.");
            while (running)
            {
                Console.WriteLine("Hur många bilar vill du lägga till? ");
                try
                {
                    antal = int.Parse(Console.ReadLine());
                    Console.Clear();
                    metoder.AddCar(antal);
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Endast siffror!");
                    Console.ResetColor();
                }
            }
            while (running)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Välj något av följande: ");
                    Console.WriteLine();
                    Console.WriteLine("[1] Kolla vad som finns i lager");
                    Console.WriteLine("[2] Sortera på pris");
                    Console.WriteLine("[3] Sortera på år");
                    Console.WriteLine("[4] Se hur många bilar som finns inne av varje drivmedel");
                    Console.WriteLine("[5] Se vad totalvärde och snittpris är på alla bilar i lager");
                    Console.WriteLine("[6] Avsluta");
                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Console.Clear();
                            metoder.ShowCars();

                            break;

                        case "2":
                            Console.Clear();
                            metoder.SortByPrice();
                            break;
                        case "3":
                            Console.Clear();
                            metoder.SortByYear();
                            break;
                        case "4":
                            Console.Clear();
                            metoder.FuelAmount();
                            break;
                        case "5":
                            Console.Clear();

                            metoder.AveragePrice();
                            break;
                        case "6":
                            running = false;
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Felaktig inmatning. Försök igen.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                }
            }
        }
    }

