using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            int lengthOfSquare = 9;
            int lineNumber = 1;

            printTiltedSquare(lineNumber, lengthOfSquare);
            Console.ReadLine();
        }

        public static void printTiltedSquare(int i_LineNumber, int i_LengthOfSquare)
        {
            int lineLength=0;
            bool v_thisIsTheEnd = false;

            if(i_LineNumber > i_LengthOfSquare)
            {
                v_thisIsTheEnd = true;
            }

            if(v_thisIsTheEnd == false)
            {
                if(i_LineNumber <= (i_LengthOfSquare / 2) + 1)
                {
                    lineLength = i_LineNumber * 2 - 1;
                }
                else
                {
                    lineLength = (i_LengthOfSquare - i_LineNumber) * 2 + 1;
                }
            }

            for (int i = 0; i < (i_LengthOfSquare-lineLength)/2 ; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < lineLength; i++)
            {
                Console.Write("*");
            }

            if(v_thisIsTheEnd == false)
            {
                Console.Write("\n");
                printTiltedSquare(i_LineNumber+1,i_LengthOfSquare);
            }

                
        }




        
    }
}
