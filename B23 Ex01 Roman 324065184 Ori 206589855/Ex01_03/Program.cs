using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            int squareLength = 0;

            squareLength = getInput();
            Ex01_02.Program.printTiltedSquare(1,squareLength);
            Console.ReadLine();
        }

        private static int getInput()
        {
            bool v_isValidInput = false;
            int inputNumber = 0;
            string inputString;

            while(v_isValidInput == false)
            {
                Console.WriteLine("Please enter VALID Meuyan height:");
                inputString = Console.ReadLine();
                v_isValidInput = int.TryParse(inputString, out inputNumber);
                if(v_isValidInput && inputNumber<0)
                {
                    v_isValidInput = false;
                }
            }

            if(inputNumber % 2 == 0)
            {
                inputNumber++;
            }

            return inputNumber;
        }
    }
}
