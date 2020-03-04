using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Bilhandlaren
{
    public class Metoder
    {
        public enum drivMedel { Bensin, Diesel, Etanol }

        // Deklarering av strängar
        string[] carBrands = new string[0];
        string[] carModels = new string[0];
        int[] carYears = new int[0];
        double[] carPrice = new double[0];
        drivMedel[] fuel = new drivMedel[0];

        // Metod för att lägga in bilar
        public void AddCar(int antal)
        {
            int index = 0;
 
            // En resizemetod jag hittade på nätet för att kunna ändra storlek på arrayerna
            Array.Resize(ref carBrands, antal);
            Array.Resize(ref carModels, antal);

            Array.Resize(ref carYears, antal);
            Array.Resize(ref carPrice, antal);
            Array.Resize(ref fuel, antal);


            for (int i = 0; i < antal; i++)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write($"Ange märke på bil nr {index + 1}: ");
                    carBrands[index] = Console.ReadLine();
                    Console.Write("Ange bilmodell: ");
                    carModels[index] = Console.ReadLine();

                    bool yearChoice = true;
                    while (yearChoice)
                    {
                        Console.Write("Ange årsmodell: ");
                        if (!int.TryParse(Console.ReadLine(), out int yearInput))
                        {
                            Console.WriteLine("Felaktig inmatning");
                        }
                        else
                        {
                            carYears[index] = yearInput;
                            yearChoice = false;
                        }
                    }
                    bool fuelChoice = true;
                    while (fuelChoice)
                    {
                        Console.Write("Ange drivmedel: Bensin 1, Diesel 2 eller Etanol 3 ");
                        string val = Console.ReadLine();
                        switch (val)
                        {
                            case "1":
                                fuel[index] = drivMedel.Bensin;
                                fuelChoice = false;
                                break;
                            case "2":
                                fuel[index] = drivMedel.Diesel;
                                fuelChoice = false;
                                break;
                            case "3":
                                fuel[index] = drivMedel.Etanol;
                                fuelChoice = false;
                                break;
                            default:
                                Console.WriteLine("Fel val. Endast siffrorna 1-3.");
                                break;
                        }
                    }
                    bool priceInput = true;
                    while (priceInput)
                    {
                        Console.WriteLine("Ange pris: ");
                        if (!double.TryParse(Console.ReadLine(), out double price))
                        {
                            Console.WriteLine("Endast siffror");
                        }
                        else
                        {
                            carPrice[index] = price;
                            priceInput = false;
                        }
                    }
                    Console.Clear();
                    index++;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
        }

        
        // Metod för att visa vilka bilar som finns
        public void ShowCars()
        {
            Console.WriteLine();
            Console.WriteLine("--LAGERSTATUS--");
            Console.WriteLine();
            for (int i = 0; i < carBrands.Length; i++)
            {
                Console.Write("Märke: " + carBrands[i] + " ");
                Console.WriteLine(carModels[i]);
                Console.WriteLine("År: " + carYears[i]);
                Console.WriteLine("Bränsle: " + fuel[i]);
                Console.WriteLine("Pris: " + carPrice[i]);
                Console.WriteLine();
              
            }
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                Console.ReadKey();
            Console.Clear();

        }
        
        public void SortByPrice()
        {
            
            
            var tempBrands = SortArrays<double, string>(carPrice, carBrands);
            var tempModels = SortArrays(carPrice, carModels);
            var tempFuel = SortArrays(carPrice, fuel);
            var tempPrice = SortArrays(carPrice, carPrice);
            var tempYears = SortArrays(carPrice, carYears);

            Console.WriteLine();
            Console.WriteLine("--SORTERING PÅ PRIS--");
            Console.WriteLine();
            for (int i = 0; i < tempPrice.Length; i++)
            {
                Console.WriteLine("Märke " + tempBrands[i] + " " + tempModels[i]);
                Console.WriteLine("Årtal: " + tempYears[i]);
                Console.WriteLine("Pris " + tempPrice[i]);
                Console.WriteLine("Bränsle: " + tempFuel[i]);

                Console.WriteLine();
                
            }
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
            Console.Clear();



        }
        // Metod för att sortera innehållet i arrayerna.
        //public int[] SortArrays(int[] sorted, int[] unSorted)
        //{
        //    var temparray = new int[sorted.Length];
        //    Array.Copy(sorted, 0, temparray, 0, sorted.Length);

        //    var temparray2 = new int[unSorted.Length];
        //    Array.Copy(unSorted, 0, temparray2, 0, unSorted.Length);

        //    Array.Sort(temparray, temparray2);
        //    return temparray2;
        //}
        //// Överlagrad metod för att sortera arrayer
        //public drivMedel[] SortArrays(int[] sorted, drivMedel[] unSorted)
        //{
        //    var temparray = new int[sorted.Length];
        //    Array.Copy(sorted, 0, temparray, 0, sorted.Length);

        //    var temparray2 = new drivMedel[unSorted.Length];
        //    Array.Copy(unSorted, 0, temparray2, 0, unSorted.Length);

        //    Array.Sort(temparray, temparray2);
        //    return temparray2;
       // }

        // En generisk metod som kan ta in olika typer av arrayer och sortera dem
        public T2[] SortArrays<T, T2>(T[] sorted, T2[] unSorted)
        {
            var temparray = new T[sorted.Length];
            Array.Copy(sorted, 0, temparray, 0, sorted.Length);

            var temparray2 = new T2[unSorted.Length];
            Array.Copy(unSorted, 0, temparray2, 0, unSorted.Length);

            Array.Sort(temparray, temparray2);
            return temparray2;
        }

        // Metod för att se hur många bilar som finns av respektive drivmedel 
        public void FuelAmount()
        {
            int bensin = 0;
            int diesel = 0;
            int etanol = 0;

            for (int i = 0; i < fuel.Length; i++)
            {
                if (fuel[i] == drivMedel.Bensin)
                {
                    bensin += 1;
                }
                else if(fuel[i] == drivMedel.Diesel)
                {
                    diesel += 1;
                }
                else if(fuel[i] == drivMedel.Etanol)
                {
                    etanol += 1;
                }
   
            }
            Console.WriteLine();
            Console.WriteLine("--ANTAL BILAR AV VARJE DRIVMEDEL--");
            Console.WriteLine();
            Console.WriteLine("Det finns följande i lager: ");
            Console.WriteLine(bensin + " st bensinbilar.");
            Console.WriteLine(diesel + " st dieselbilar.");
            Console.WriteLine(etanol + " st etanolbilar.");
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
            Console.Clear();

        }
        public void AveragePrice()
        {
            double priceAverage = 0;
            double totalValue = 0;
            for (int i = 0; i < carPrice.Length; i++)
            {
                priceAverage += carPrice[i];
                totalValue += carPrice[i];
            }
            priceAverage /=  carPrice.Length;

            Console.WriteLine();
            Console.WriteLine("--PRISINFO--");
            Console.WriteLine();
            Console.WriteLine($"Totalpriset är {totalValue } kr och snittpriset är {Math.Round(priceAverage, 2)} kr");
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
            Console.Clear();
        }
        public void SortByYear()
        {


            var tempBrands = SortArrays(carYears, carBrands);
            var tempModels = SortArrays(carYears, carModels);
            var tempFuel = SortArrays(carYears, fuel);
            var tempPrice = SortArrays(carYears, carPrice);
            var tempYears = SortArrays(carYears, carYears);

            Console.WriteLine();
            Console.WriteLine("--SORTERING PÅ ÅR--");
            Console.WriteLine();
            for (int i = 0; i < tempPrice.Length; i++)
            {
                Console.WriteLine("Märke " + tempBrands[i] + " " + tempModels[i]);
                Console.WriteLine("Årtal: " + tempYears[i]);
                Console.WriteLine("Pris " + tempPrice[i]);
                Console.WriteLine("Bränsle: " + tempFuel[i]);

                Console.WriteLine();

            }
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
            Console.Clear();



        }

    }
}

