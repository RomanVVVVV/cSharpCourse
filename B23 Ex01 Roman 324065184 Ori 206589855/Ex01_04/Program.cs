using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            string input;
            bool onlyDigits = false;
            bool isDividedByThree= false;
            int numberOfUpperCaseLetters = 0;
            bool isStringPalindrome = false;

            input= readInput(ref onlyDigits);

            if(onlyDigits)
            {
                isDividedByThree= checkIfNumberDividedByThree(input);
            }
            else
            {
                numberOfUpperCaseLetters = countNumberOfUpperCaseLetters(input);
            }

            isStringPalindrome = checkIfInputIsPalindrome(input);


            output(input, onlyDigits, isDividedByThree, numberOfUpperCaseLetters, isStringPalindrome);
 

            Console.ReadLine();
        }

        private static void output(string input, bool onlyDigits, bool isDividedByThree, int numberOfUpperCaseLetters, bool isStringPalindrome)
        {
            if(onlyDigits)
            {
                if(isDividedByThree)
                {
                    Console.WriteLine(string.Format(isStringPalindrome ? @"The string '{0}' is palindrome 
The number {0} is divided by 3" 
                                                                            : @"The string '{0}' is not palindrome 
The number {0} is divided by 3", input));
                }
                else
                {
                    Console.WriteLine(string.Format(isStringPalindrome ? @"The string '{0}' is palindrome 
The number {0} is not divided by 3"
                                                        : @"The string '{0}' is not palindrome 
The number {0} is not divided by 3", input));
                }
            }
            else
            {
                Console.WriteLine(string.Format(isStringPalindrome ? @"The string '{0}' is palindrome 
The number of upper case letters is {1}"
                                                    : @"The string '{0}' is not palindrome 
The number of upper case letters is {1}", input, numberOfUpperCaseLetters));
            }
        }

        private static bool checkIfNumberDividedByThree(string i_input)
        {
            int number = 0;

            for(int i = 0; i < i_input.Length; i++)
            {
                number = (number * 10) + (i_input[i] - '0');
            }

            if(number % 3 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int countNumberOfUpperCaseLetters(string i_input)
        {
            int numberOfUpperCaseLetters = 0;

            for(int i = 0; i < i_input.Length; i++)
            {
                if(i_input[i] >= 'A' && i_input[i] <= 'Z')
                {
                    numberOfUpperCaseLetters++;
                }
            }

            return numberOfUpperCaseLetters;
        }

        private static bool checkIfInputIsPalindrome(string i_input)//recursive
        {
            if(i_input.Length <= 1)
            {
                return true;
            }
            else
            {
                if(i_input[0] != i_input[i_input.Length -1])
                {
                    return false;
                }
                else
                {
                    return checkIfInputIsPalindrome(i_input.Substring(1, i_input.Length - 2));
                }
            }

        }

        private static string readInput(ref bool i_onlyDigits)
        {
            string input;
            Console.WriteLine("Please Enter a string of length 6:");
            input = Console.ReadLine();

            while(inputValidtyCheck(input, ref i_onlyDigits) == false)
            {
                Console.WriteLine("Input is invalid, please retry:");
                input = Console.ReadLine();
            }

            return input;

        }


        private static bool inputValidtyCheck(string i_input, ref bool i_onlyDigits)
        {
            if(i_input.Length !=6)
            {
                return false;
            }

            if(onlyCharactersOrDigits(i_input, ref i_onlyDigits) == false)
            {
                return false;
            }

            return true;
        }

        private static bool onlyCharactersOrDigits(string i_input, ref bool i_onlyDigits)
        {
            int characters_counter = 0;
            int digits_counter = 0;

            for(int i = 0; i < i_input.Length; i++)
            {
                if(i_input[i] >= '0' && i_input[i] <= '9')
                {
                    digits_counter++;
                }
                else if((i_input[i] >= 'a' && i_input[i] <= 'z') || (i_input[i] >= 'A' && i_input[i] <= 'Z'))
                {
                    characters_counter++;
                }
            }

            if(digits_counter == 6 && characters_counter == 0)
            {
                i_onlyDigits = true;
                return true;
            }
            else if(characters_counter == 6 && digits_counter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
