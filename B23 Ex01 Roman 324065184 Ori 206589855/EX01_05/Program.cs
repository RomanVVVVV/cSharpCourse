using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EX01_05
{
    class Program
    {
        public static void Main()
        {
            int inputNumber;
            int numberOfDigitsAreGraterThanUnityDigit;
            int minimunDigitInTheNumber;
            int numberOfDigitsAreDividedByThree;
            float averageOfDigits;


            inputNumber = readInputFromConsole();
            numberOfDigitsAreGraterThanUnityDigit = countNumberOfDigitsAreGraterThanUnityDigits(inputNumber);
            minimunDigitInTheNumber = findTheMinimumDigitInTheNumber(inputNumber);
            numberOfDigitsAreDividedByThree = countNumberOfDigitsAreDividedByThree(inputNumber);
            averageOfDigits = calculateAverageOfDigitsInNumber(inputNumber);


            displayOutput(inputNumber, numberOfDigitsAreGraterThanUnityDigit, minimunDigitInTheNumber, numberOfDigitsAreDividedByThree, averageOfDigits);


            Console.ReadLine();
        }

        private static int readInputFromConsole()
        {
            string consoleInput;
            int inputNumber;

            Console.WriteLine("Please Enter an integer of length 6:");
            consoleInput = Console.ReadLine();

            while (inputValidtyCheck(consoleInput) == false)
            {
                Console.WriteLine("Input is invalid, please retry:");
                consoleInput = Console.ReadLine();
            }

            int.TryParse(consoleInput, out inputNumber);

            return inputNumber;
        }

        private static bool inputValidtyCheck(string i_consoleInput)
        {
            if(i_consoleInput.Length != 6)
            {
                return false;
            }

            for(int i = 0; i < i_consoleInput.Length; i++)
            {
                if(i_consoleInput[i] < '0' || i_consoleInput[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static int countNumberOfDigitsAreGraterThanUnityDigits(int i_inputNumbre)
        {
            int unityDigit = i_inputNumbre % 10;
            int counterOfDigitsAreGraterThanUnityDigits = 0;
            int lastDigit;

            i_inputNumbre = i_inputNumbre / 10;
            


            while(i_inputNumbre > 0)
            {
                lastDigit = i_inputNumbre % 10;

                if(lastDigit > unityDigit)
                {
                    counterOfDigitsAreGraterThanUnityDigits++;
                }

                i_inputNumbre = i_inputNumbre / 10;
            }

            return counterOfDigitsAreGraterThanUnityDigits;
        }

        private static int findTheMinimumDigitInTheNumber(int i_inputNumber)
        {
            int lastDigit;
            int minimumDigitInTheNumber = i_inputNumber % 10;
            i_inputNumber = i_inputNumber / 10;

            while(i_inputNumber > 0)
            {
                lastDigit = i_inputNumber % 10;

                if(lastDigit < minimumDigitInTheNumber)
                {
                    minimumDigitInTheNumber = lastDigit;
                }

                i_inputNumber = i_inputNumber / 10;
            }

            return minimumDigitInTheNumber;
        }

        private static int countNumberOfDigitsAreDividedByThree(int i_inputNumber)
        {
            int lastDigit;
            int counterDigitsAreDividesByThree = 0;



            while(i_inputNumber > 0)
            {
                lastDigit = i_inputNumber % 10;

                if(lastDigit % 3 == 0)
                {
                    counterDigitsAreDividesByThree++;
                }

                i_inputNumber = i_inputNumber / 10;
            }

            return counterDigitsAreDividesByThree;
        }

        private static float calculateAverageOfDigitsInNumber(int i_inputNumber)
        {

            if(i_inputNumber == 0)
            {
                return 0;
            }

            int sumOfDigits = 0;
            int numberOfDigits = 0;
            float average = 0;

            while(i_inputNumber > 0)
            {
                sumOfDigits = sumOfDigits + i_inputNumber % 10;
                numberOfDigits++;
                i_inputNumber = i_inputNumber / 10;
            }

            average = Convert.ToSingle(sumOfDigits) / Convert.ToSingle(numberOfDigits);

            return average;
        }

        private static void displayOutput(int i_inputNumber, int i_numberOfDigitsAreGraterThanUnityDigit, int i_minimunDigitInTheNumber, int i_numberOfDigitsAreDividedByThree, float i_averageOfDigits)
        {
            Console.WriteLine(
                string.Format(
                    @"The decimal numbers are: {0}
The number of digits are grater than unity digit is: {1}
The smallest digit in the number: {2}
The number of digits are divided by 3: {3}
The average of the digits: {4}",
                    i_inputNumber,
                    i_numberOfDigitsAreGraterThanUnityDigit,
                    i_minimunDigitInTheNumber,
                    i_numberOfDigitsAreDividedByThree,
                    i_averageOfDigits));
        }
    }
}
