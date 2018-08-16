using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppCashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            int input, i, itemCount = 1, j = 0, counter = 0;
            char y;
            int[] arrInput = new int[4];

            do
            {

                Console.WriteLine("Enter the price of the " + itemCount + " item: ");
                input = Int32.Parse(Console.ReadLine());
                arrInput[j++] = input;
                Console.WriteLine("Do you wish to add more items (y/n): ");
                y = Console.ReadKey(true).KeyChar;
                itemCount++;
            } while (y == 'y');
            counter = itemCount - 1;

            double totalCost = 0;

            if (counter >= 3)
            {
                totalCost = discountCouponBuy3Get1Free(arrInput, counter);
            }
            else
            {
                totalCost = discountCouponPerOffTotal(arrInput, counter);

            }

            displayList(arrInput, counter);
            Console.Write("\n Your items total : " + totalCost);
            Console.ReadLine();

        }



        private static double discountCouponPerOffTotal(int[] arrayScanItem, int counter)
        {
            int PerOffTotal = 10;
            double calcTotal = 0;

            for (int i = 0; i < counter; i++)
            {

                calcTotal += arrayScanItem[i];

            }

            calcTotal = calcTotal - (calcTotal * PerOffTotal / 100);
            return calcTotal ;
        }

        private static double discountCouponBuy3Get1Free(int[] arrayScanItem, int counter)
        {
            
            double calcTotal = 0;
            int minVal = arrayScanItem.Min();
            for (int i = 0; i < counter; i++)
            {

                calcTotal += arrayScanItem[i];

            }

            calcTotal= calcTotal - minVal ;
            return calcTotal;
        }



        private static void displayList(int[] arrayScanItem, int counter)
        {
            Console.Write("\nYour items are : ");
            for (int i = 0; i < counter; i++)
            {
                Console.Write("\n");
                Console.Write("{0}  ", arrayScanItem[i]);
                Console.Write("\n");
            }
        }
    }


}
