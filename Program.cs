using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMatrixConversion
{
    internal class Program
    {

        public static int result;
        public static int result2;


        public static bool IsNumValid(string inputString)
        {
            bool isValid = true;
            isValid = int.TryParse(inputString, out result);

            if (!isValid)
            {
                Console.WriteLine("Please Input Correct Number");
                isValid = false;
            }
            else
            {

                if (result > 0 && result < 4)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please Enter Correct Range");
                    isValid = false;
                }
            }
            return isValid;
        }


        public static bool IsNum2Valid(string inputString)
        {
            bool isValid = true;

            isValid = int.TryParse(inputString, out result2);

            if (!isValid)
            {
                Console.WriteLine("Please Input Correct Number");
                isValid = false;
            }
            else
            {

                if (result2 > 0 && result2 < 4)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please Enter Correct Range");
                    isValid = false;
                }
            }
            return isValid;
        }
        static void Main()
        {

            //       usd   cad   eur
            // 1USD   1    1.28  0.95
            // 1CAD  0.78   1    0.74
            // 1EUR  1.05  1.34   1


            double[,] CurrMatrix = new double[3, 3]
            {
                { 1, 1.28, 0.95 },
                { 0.78, 1, 0.74 },
                { 1.05, 1.34, 1 }

                // 0,0 => usd,usd
                // 0,1 => usd,cad
                // 0,2 => usd,eur

                // 1,0 => cad,usd
                // 1,1 => cad,cad
                // 1,2 => cad,eur

                // 2,0 => eur, usd
                // 2,1 => eur, cad
                // 2,2 => eur, eur

            };

            Console.WriteLine("From Which Currency You Want To Convert?\n1.USD\n2.CAD\n3.EUR");
            string defaultCurr = Console.ReadLine();
            while (!IsNumValid(defaultCurr))
            {
                defaultCurr = Console.ReadLine();
            }

            Console.WriteLine("To Which Currency You Want To Convert?\n1.USD\n2.CAD\n3.EUR");
            string ChangeCurr = Console.ReadLine();
            while (!IsNum2Valid(ChangeCurr))
            {
                ChangeCurr = Console.ReadLine();
            }


            Console.WriteLine("Please Enter Your Ammount");
            string userAmmount = Console.ReadLine();
            double ammount;
            while (!double.TryParse(userAmmount, out ammount))
            {
                Console.WriteLine("Please Enter Correct Ammount");
                userAmmount = Console.ReadLine();
            }

            double ConversionAmmount = CurrMatrix[result - 1, result2 - 1];

            Console.WriteLine(ammount * ConversionAmmount);


            Console.ReadKey();
        }
    }
}
