
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Ex01_01
{
    class Program
    {

        private static double findMax(double i_numberA, double i_numberB, double i_numberC)
        {
            double max = i_numberA;

            if(i_numberB > max)
            {
                max = i_numberB;
            }

            if(i_numberC > max)
            {
                max = i_numberC;
            }

            return max;
        }



        public static void Main()
        {
            string input;
            double[] decimalNumbersDoubles = new double[3];
            string[] binaryNumbersStrings = new string[3];
            double[] decimalNumbersDoublesDescending = new double[3];
            int averageNumOfZeros, averageNumOfOnes, numOfMultiplicationsOfFour, numOfDescendingNumbers, numOfPalindromeNumbers;


            readInput(ref decimalNumbersDoubles, ref binaryNumbersStrings);
            sortInDescendingOrder(decimalNumbersDoubles, ref decimalNumbersDoublesDescending);
            averageNumOfZeros = calculateAverageNumberOfZeros(binaryNumbersStrings);
            averageNumOfOnes = calculateAverageNumberOfOnes(binaryNumbersStrings);
            numOfMultiplicationsOfFour = calculateCountOfMultiplicationsOfFour(decimalNumbersDoubles);
            numOfDescendingNumbers = calculateCountOfDescendingNumbers(decimalNumbersDoubles);
            numOfPalindromeNumbers = calculateCountOfPalindromeNumbers(decimalNumbersDoubles);

            Console.WriteLine(string.Format(
@"The decimal numbers are: {0}, {1}, {2}
The average of number of zeros: {3}
The average of number of ones: {4}
The number of numbers that are divided by four is: {5}
The number of decimal numbers that their digits are descending: {6}
The number of decimal palindrome numbers : {7} ",
decimalNumbersDoublesDescending[0], decimalNumbersDoublesDescending[1], decimalNumbersDoublesDescending[2], averageNumOfZeros, averageNumOfOnes,
numOfMultiplicationsOfFour, numOfDescendingNumbers, numOfPalindromeNumbers));


            Console.ReadLine();
        }

        private static int calculateCountOfPalindromeNumbers(double[] i_DecimalNumbersDoubles)
        {       
            int numberOfPalindroms = 0;

            for(int i = 0; i < i_DecimalNumbersDoubles.Length; i++)
            {
                if(checkIfPalindrom(i_DecimalNumbersDoubles[i]))
                {
                    numberOfPalindroms++;
                }
            }

            return numberOfPalindroms;
        }

        private static bool checkIfPalindrom(double number)
        {
            double originNumber = number;
            double reversNumber= 0;
            double lastDigit;

            while(originNumber > 0)
            {
                lastDigit = originNumber % 10;
                reversNumber = (reversNumber * 10) + lastDigit;
                originNumber = originNumber / 10;
            }

            if(reversNumber == number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int calculateCountOfDescendingNumbers(double[] i_DecimalNumbersDoubles)
        {
            int countOfDescendingNumbers = 0;
            for(int i = 0; i < 3; i++)
            {
                if(isDescendingNumber(i_DecimalNumbersDoubles[i]) == true)
                {
                    countOfDescendingNumbers++;
                }
            }

            return countOfDescendingNumbers;
        }

        private static bool isDescendingNumber(double i_DecimalNumbersDouble)
        {
            bool v_isDescending = true;
            string numberString = i_DecimalNumbersDouble.ToString();
            for (int i = 0; i < numberString.Length - 1; i++)
            {
                if (numberString[i] < numberString[i + 1])
                {
                    v_isDescending = false;
                    break;
                }
            }
            return v_isDescending;
        }


        private static int calculateAverageNumberOfOnes(string[] i_BinaryNumbersStrings)
        {
            int LengthOfBinaryNumbersArray = i_BinaryNumbersStrings.Length;
            int numberOfOnes = 0;

            for (int i = 0; i < LengthOfBinaryNumbersArray; i++)
            {
                for (int j = 0; j < i_BinaryNumbersStrings[i].Length; j++)
                {
                    if (i_BinaryNumbersStrings[i][j] == '1')
                    {
                        numberOfOnes++;
                    }
                }
            }

            return (numberOfOnes / LengthOfBinaryNumbersArray);
        }

        private static int calculateAverageNumberOfZeros(string[] i_BinaryNumbersStrings)
        {
            int LengthOfBinaryNumbersArray = i_BinaryNumbersStrings.Length;
            int numberOfZeros = 0;

            for(int i = 0; i < LengthOfBinaryNumbersArray; i++)
            {
                for(int j = 0; j < i_BinaryNumbersStrings[i].Length; j++)
                {
                    if(i_BinaryNumbersStrings[i][j] == '0')
                    {
                        numberOfZeros++;
                    }   
                }
            }

            return (numberOfZeros / LengthOfBinaryNumbersArray);
        }

        private static void sortInDescendingOrder(double[] i_DecimalNumbersDoubles, ref double[] o_DecimalNumbersDoublesDescending)
        {
            o_DecimalNumbersDoublesDescending[0] = i_DecimalNumbersDoubles[0];
            o_DecimalNumbersDoublesDescending[1] = i_DecimalNumbersDoubles[1];
            o_DecimalNumbersDoublesDescending[2] = i_DecimalNumbersDoubles[2];
            Array.Sort(o_DecimalNumbersDoublesDescending);
            Array.Reverse(o_DecimalNumbersDoublesDescending);
        }

        private static int calculateCountOfMultiplicationsOfFour(double[] i_DecimalNumbersDoubles)
        {
            int counterOfNumbersDivideByFour = 0;

            for(int i = 0; i < i_DecimalNumbersDoubles.Length; i++)
            {
                if(i_DecimalNumbersDoubles[i] % 4 ==0)
                {
                    counterOfNumbersDivideByFour++;
                }
            }

            return counterOfNumbersDivideByFour;
        }

        private static void readInput(ref double[] i_DecimalNumbersDoubles, ref string[] i_BinaryNumbersStrings)
        {
            int numOfValidInputs = 0;
            string stringInput;

            Console.WriteLine("Please Enter 3 binary numbers, each one 8 bits in length:");

            while (numOfValidInputs < 3)
            {
                stringInput = Console.ReadLine();
                if (inputStringValidityCheck(stringInput) == true)
                {
                    i_BinaryNumbersStrings[numOfValidInputs] = stringInput;
                    i_DecimalNumbersDoubles[numOfValidInputs] = parseToDecimal(stringInput);
                    numOfValidInputs++;
                    Console.WriteLine("Number " + numOfValidInputs + " received successfully.");
                }
                else
                {
                    Console.WriteLine("Input is invalid, please retry:");
                }
            }
        }

        public static bool inputStringValidityCheck(string i_stringInput)
        {
            int validLength = 8;

            if (i_stringInput.Length != validLength)
            {
                return false;
            }


            for (int i = 0; i < i_stringInput.Length; i++)
            {
                if (i_stringInput[i] != '0' && i_stringInput[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private static double parseToDecimal(string i_StringInput)
        {
            double decimalNumber = 0;

            for (int i = 0; i < i_StringInput.Length; i++)
            {
                if (i_StringInput[i] == '1')
                {
                    decimalNumber += Math.Pow(2, i);
                }
            }

            return decimalNumber;
        }
    }




}
