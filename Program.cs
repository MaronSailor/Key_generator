// Creates chosed in code number of KEYS and sorts them.  

// User can get any KEY and find where it is 

// Key Example – A12345B 


using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;



public class Key_Generator
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        int Array_Size = 50;
        string[] Code_Array = new string[Array_Size];
        string[] Code_Array_2 = new string[Array_Size];
        string Code = "";
        int Width = 5;

        Create_Array(Array_Size, Code, random, Code_Array, Width); // creates and outputs array 
        Copy_Array(Code_Array, Code_Array_2, Array_Size); // copies and sorts array (Code_Array is copied to Code_Array_2 and then is sorted) 
        Check_Array(Code_Array, Code_Array_2, Array_Size, Width); // outputs sorted array (Code_Array) with previous key's IDs 
        User_Output(Code_Array, Code_Array_2, Array_Size, Width);
    }

    static void Create_Array(int Array_Size, string Code, Random random, string[] Generated_Array, int Width)
    {
        int Lines = 0;
        for (int i = 0; i < Array_Size; i++)
        {
            Code = (char)random.Next(65, 91) + random.Next(0, 100000).ToString("00000") + (char)random.Next(65, 91);
            Generated_Array[i] = Code;

            //Console.WriteLine($"Generated_Int =>\t{Generated_Int}\nGenerated_Char =>\t{Generated_Char}");  
            Console.Write($"{Generated_Array[i]}[{(i + 1).ToString("000")}] ");
            if ((i + 1) % Width == 0)
            {
                Console.WriteLine($" -- {Lines + 1}");
                Lines++;
            }
        }
    }
    static void Copy_Array(string[] First_Array, string[] Second_Array, int Array_Size)
    {
        Array.Copy(First_Array, Second_Array, Array_Size);
        Array.Sort(First_Array);
        Console.WriteLine("");
    }
    static void Check_Array(string[] First_Array, string[] Second_Array, int Array_Size, int Width)
    {
        int Lines = 0;
        for (int i = 0; i < Array_Size; i++)
        {
            Console.Write($"{First_Array[i]}[");
            for (int j = 0; j < Array_Size; j++)
            {
                if (First_Array[i] == Second_Array[j])
                    Console.Write($"{(j + 1).ToString("000")}] ");
            }
            if ((i + 1) % Width == 0)
            {
                Console.WriteLine($" -- {Lines + 1}");
                Lines++;
            }
        }
    }

    static bool User_Integer_Bool_Checker(string Input, int Array_Size)
    {
        int Int_Input;
        try
        {
            Int_Input = Convert.ToInt16(Input);
            if (Int_Input < 1 | Int_Input > Array_Size)
            {
                Console.WriteLine("Integer was too high or too low");
                return false;
            }
            return true;
        }
        catch
        {
            Console.WriteLine("Input was not an integer");
            return false;
        }
    }
    static bool User_String_Bool_Checker(string Input)
    {
        if (Input.Length != 7)
        {
            Console.WriteLine("It was not a string of 7 elements.");
            return false;
        }
        for (int i = 1; i < 6; i++)
        {
            if (!Char.IsLetter(Input, 0) || !Char.IsLetter(Input, 6) || !Char.IsNumber(Input, i))
            {
                Console.WriteLine("Input was not right. String has 7 elements.");
                return false;
            }
        }
        return true;
    }
    static void User_Output(string[] First_Array, string[] Second_Array, int Array_Size, int Width)
    {
        Console.WriteLine("Print an ID or KEY => ");
        string Input = Console.ReadLine();
        int Integer_Input;
        if (User_Integer_Bool_Checker(Input, Array_Size))
        {
            Integer_Input = Convert.ToInt32(Input);
            Integer_Input--;
            for (int i = 0; i < Array_Size; i++)
                if (First_Array[i] == Second_Array[Integer_Input])
                {
                    int Line = Convert.ToInt16(Math.Floor((Convert.ToDouble(i) + Width) / Convert.ToDouble(Width)));
                    Console.WriteLine($"Key\t\tSID\tCID\tLINE\tROW\n{Second_Array[Integer_Input]}\t\t[{(Integer_Input + 1).ToString("000")}]\t[{(i + 1).ToString("000")}]\t[{Line}]\t[{i + 1 - ((Line - 1) * Width)}]");
                }
        }
        else if (User_String_Bool_Checker(Input))
        {
            for (int i = 0; i < Array_Size; i++)
            {
                if (First_Array[i] == Input)
                {
                    int j;
                    for (j = 0; j < Array_Size; j++)
                    {
                        if (Second_Array[j] == Input)
                            break;
                    }
                    int Line = Convert.ToInt16(Math.Floor((Convert.ToDouble(i) + Width) / Convert.ToDouble(Width)));
                    Console.WriteLine($"Key\t\tSID\tCID\tLINE\tROW\n{First_Array[i]}\t\t[{(j + 1).ToString("000")}]\t[{(i + 1).ToString("000")}]\t[{Line}]\t[{i + 1 - ((Line - 1) * Width)}]");
                    break;
                }
                if (i == Array_Size - 1)
                    Console.WriteLine("Key was not found");
            }
        }
        Console.WriteLine("SID -> Starting_ID(Which ID did the KEY place)\nCID -> Current_ID(Which ID places the KEY now)\nLINE -> Line, where the KEY is\nROW -> Row, where the KEY is");
    }
}