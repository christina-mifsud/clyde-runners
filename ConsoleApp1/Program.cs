// Christina Mifsud
// 07/03/22
// PDA Software Development Assignment - Clyde Runners


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void input_details(ref string username, ref string login) // gets user details
        {
            Console.WriteLine("Please enter username: ");
            username = Console.ReadLine();
            Console.WriteLine("Please enter password: ");
            login = Console.ReadLine();

        }


        static void print_message(string username, string password, string login, ref int count) // test the details and prints a message
        {
            const int quit_option = 7; // local variable
            int choice = 0;


            if (login == password)
            {
                Console.WriteLine($"Welcome {username}");
                while (choice != quit_option) // call menu
                {
                    Console.WriteLine();
                    display_menu();
                    get_choice(ref choice);
                    act_on_choice(choice);
                }
            }

            else
            {
                count += 1;   // count password attempts
                Console.WriteLine($"Invalid password and username - attempt {count}");
            }
        }

        public static void display_menu()// display the menu
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t MAIN MENU\n");
            Console.WriteLine("\t\t\t 1. Read and Display");
            Console.WriteLine("\t\t\t 2. Sort and Print");
            Console.WriteLine("\t\t\t 3. Find Fastest");
            Console.WriteLine("\t\t\t 4. Find Slowest");
            Console.WriteLine("\t\t\t 5. Search");
            Console.WriteLine("\t\t\t 6. Time Occurrence");
            Console.WriteLine("\t\t\t 7. Exit\n");
        } //end of main menu

        public static void get_choice(ref int choice)
        {
            Console.WriteLine("\t\t\t Enter Choice 1 - 7\n");
            Console.WriteLine("\t\t\t Clyde Runners\n");
            choice = Convert.ToInt32(Console.ReadLine());
        } //end of get choice method


        public static void act_on_choice(int choice) // takes user input from main menu and selects choice
        {
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("You have selected Read and Display\n");

                        // calling Read & Display method (ReadFromFile)
                        string[,] person = new string[16, 2]; // an array with 16 rows and 2 columns - "John", "70";
                        ReadFromFile(person);
                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.WriteLine("\nClyde Runners\n");
                        Console.ReadKey();
                        break;

                    } //end case 1

                case 2:
                    {
                        Console.WriteLine("You have selected Sort and Print\n");

                        int[] nums = { 70, 90, 75, 70, 95, 103, 80, 110, 68, 120, 80, 140, 90, 72, 78, 97 }; // hard coded array
                        // calling Sort Array method (SortArray)
                        SortArray(ref nums);
                        Console.WriteLine("Sorted Array");
                        print_array(ref nums);

                        WriteToFile(nums); // calling method to print to external .txt file

                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.WriteLine("\nClyde Runners\n");
                        Console.ReadKey();
                        break;
                    }//end case 2

                case 3:
                    {
                        Console.WriteLine("You have selected Find Fastest\n");

                        int[] nums = { 70, 90, 75, 70, 95, 103, 80, 110, 68, 120, 80, 140, 90, 72, 78, 97 };
                        // calling Find Fastest method (print_min)
                        print_min(nums);

                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.WriteLine("\nClyde Runners\n");
                        Console.ReadKey();
                        break;
                    }//end case 3

                case 4:
                    {
                        Console.WriteLine("You have selected Find Slowest\n");

                        int[] nums = { 70, 90, 75, 70, 95, 103, 80, 110, 68, 120, 80, 140, 90, 72, 78, 97 };
                        // calling Find Slowest method (print_max)
                        print_max(nums);

                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.WriteLine("\nClyde Runners\n");
                        Console.ReadKey();
                        break;
                    }//end case 4

                case 5:
                    {
                        Console.WriteLine("You have selected Search\n");

                        int[] nums = { 70, 90, 75, 70, 95, 103, 80, 110, 68, 120, 80, 140, 90, 72, 78, 97 };
                        // calling Search Array method (SearchArray)
                        Console.WriteLine("The time was recorded for competitor number: " + SearchArray(nums));


                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.WriteLine("\nClyde Runners\n");
                        Console.ReadKey();
                        break;
                    }//end case 5

                case 6:
                    {
                        Console.WriteLine("You have selected Time Occurrence\n");

                        int[] nums = { 70, 90, 75, 70, 95, 103, 80, 110, 68, 120, 80, 140, 90, 72, 78, 97 };
                        // calling Time Occurrence method (countOcc)
                        Console.WriteLine("The time was recorded " + countOcc(ref nums) + " times");

                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.WriteLine("\nClyde Runners\n");
                        Console.ReadKey();
                        break;
                    }//end case 6

                case 7:
                    {
                        Console.WriteLine("Goodbye.");
                        Environment.Exit(0);
                        break;
                    }//end case 7
            }//end switch (choice) statement
        }//end act on choice method


        ///// 1. READ AND DISPLAY
        static void ReadFromFile(string[,] person)
        {
            StreamReader readDisplay = File.OpenText("C:\\Users\\Christina\\Desktop\\Personal\\GCC\\ConsoleApp1\\race results.txt"); //C:\Users\Christina\Desktop\Personal\GCC\ConsoleApp1
            string textLine;  // variable that takes each line of text from file

            int i = 0;  // loop counter for each row of the 2D array
            while ((textLine = readDisplay.ReadLine()) != null)
            {
                string[] textSplit = textLine.Split(' '); //string function Split. Takes a string and removes the characters
                                                          //from the " " space and reads into an array called textSplit.
                                                          //john will be read into textSplit[0] and 70 into textSplit [1]

                for (int j = 0; j < 2; j++)  //for (initializer; condition; iterator)- loop for each column (2) 
                {
                    person[i, j] = textSplit[j]; //for each row, name will be read and then time
                                                 //this loop will iterate twice - 0,0 and then 0,1
                                                 //i will become 1 - 1,0 and then 1,1
                                                 //i will become 2 - 2,0 and then 2,1
                    Console.Write(person[i, j] + " ");//prints name and time and a space
                }
                i++;  // add 1 onto i so that each row can be dealt with
                Console.WriteLine();  //takes a new line after each name and time are printed
            }//end while
        }

        ///// 2. SORT ARRAY (slowest to fastest)
        static void SortArray(ref int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)    //move boundary of unsorted array (take 1 away each time) - the first array element with the new
            {                                            //sorted number will be ignored (hence -1) 
                int index = i;
                for (int j = i + 1; j < nums.Length; j++)   //find minimum element in unsorted array - looks at the index and goes through
                {                                           //each subsequent index in the array to compare
                    if (nums[j] < nums[index])
                    {
                        index = j; //searching for minimum element  
                    }
                }
                int smallerNumber = nums[index]; //swap minimum element with first element
                nums[index] = nums[i];
                nums[i] = smallerNumber;
            }
        }

        static void print_array(ref int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);

            }
        }

        ///// 3. FIND FASTEST
        static void print_min(int[] nums)
        {
            double min;
            min = nums[0]; // set min to first element in array for comparison
            for (int i = 1; i < nums.Length; i++) //loop for second element in array until end
            {
                if (nums[i] < min)  //if array element < min value, then reset min to that new value
                {
                    min = nums[i];
                    // create & print to external .txt file 
                    using (StreamWriter writer = new StreamWriter("C:\\Users\\Christina\\Desktop\\Personal\\GCC\\ConsoleApp1\\fastest.txt"))
                    {
                        writer.Write("The fastest recorded time was: " + Convert.ToString(min));
                        writer.Write("\n\nClyde Runners\n");
                    }
                }
            }
            Console.WriteLine("The fastest recorded time was: " + min); //display min

        }


        ///// 4. FIND SLOWEST
        static void print_max(int[] nums)
        {
            double max;
            max = nums[0]; // set min to first element in array for comparison
            for (int i = 1; i < nums.Length; i++)//loop for second element in array until end
            {
                if (nums[i] > max)  //if array element > max value, then reset max to that new value
                {
                    max = nums[i];
                    // create & print to external .txt file 
                    using (StreamWriter writer = new StreamWriter("C:\\Users\\Christina\\Desktop\\Personal\\GCC\\ConsoleApp1\\slowest.txt"))
                    {
                        writer.Write("The slowest recorded time was: " + Convert.ToString(max));
                        writer.Write("\n\nClyde Runners\n");
                    }

                }
            }
            Console.WriteLine("The slowest recorded time was: " + max); //display max

        }


        ///// 5. SEARCH
        static int SearchArray(int[] nums)
        {
            int timeSearch;
            Console.WriteLine("Enter number to search for"); // get item being searched for
            timeSearch = Convert.ToInt32(Console.ReadLine()); //convert string to int
            for (int i = 0; i < nums.Length; i++) //For each item in the array
            {
                if (timeSearch == nums[i])//If this item matches the item being searched for
                {
                    // create & print to external .txt file 
                    using (StreamWriter writer = new StreamWriter("C:\\Users\\Christina\\Desktop\\Personal\\GCC\\ConsoleApp1\\search.txt"))
                    {
                        writer.Write("The time " + timeSearch + " was recorded for competitor number: " + Convert.ToString(i + 1)); //added the +1 as user will start counting competitors from 1 not 0
                        writer.Write("\n\nClyde Runners\n");
                    }
                    return i + 1;// Store the position - //added the +1 as user will start counting competitors from 1 not 0
                }//End if
            }//End loop
            return -1;

        }


        ///// 6. TIME OCCURRENCE
        static int countOcc(ref int[] nums)
        {
            int timeOcc;
            int count = 0;
            Console.WriteLine("Enter number to count"); // get item being searched for
            timeOcc = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < nums.Length; i++)// For each item in the array
            {
                if (timeOcc == nums[i])// If this item matches the item being searched for
                {
                    count = count + 1;// add one to the count
                    // create & print to external .txt file 
                    using (StreamWriter writer = new StreamWriter("C:\\Users\\Christina\\Desktop\\Personal\\GCC\\ConsoleApp1\\timeocc.txt"))
                    {
                        writer.Write("The time " + timeOcc + " was recorded " + Convert.ToString(count) + " times");
                        writer.Write("\n\nClyde Runners\n");
                    }
                }// End if
            }// End loop
            return count;
            // Print out the number of times the item was found
        }//end of count function


        ///// 7. EXIT


        ///// WRITE TO FILE
        static string path = "C:\\Users\\Christina\\Desktop\\Personal\\GCC\\ConsoleApp1\\sort.txt"; // variable to set path name

        static void WriteToFile(int[] nums)//sets up StreamReader class so that we can write to a file
        {
            using (StreamWriter author = new StreamWriter(path))  //creates a new file object called author and uses path to write to file
            {
                for (int i = 0; i < nums.Length; i++)  //forloop to write each value in the array to file
                {
                    author.WriteLine(nums[i]);   //uses author object to write the numbers too. author is recognised as a file

                }
            } 

        }



        static void Main(string[] args) // main program
        {
            // calling Password verification method (input_details & print_message)
            string username = "";
            string login = "";
            string password = "clyderunners";
            int count = 0;


            Console.WriteLine("Welcome to Clyde Runners");
            while (login != password && count < 3)
            {
                input_details(ref username, ref login);
                print_message(username, password, login, ref count);
                //loop until password is correct
            }//end while


            if (count == 3)
            {
                Console.WriteLine("Locked Out of System - Please Contact Admin");
            }


        }

    }
}











// APPEND TEXT
//class Test
//{
//    public static void Main()
//    {
//        string path = @"c:\temp\MyTest.txt";
//        // This text is added only once to the file.
//        if (!File.Exists(path))
//        {
//            // Create a file to write to.
//            using (StreamWriter sw = File.CreateText(path))
//            {
//                sw.WriteLine("Hello");
//                sw.WriteLine("And");
//                sw.WriteLine("Welcome");
//            }
//        }

//        // This text is always added, making the file longer over time
//        // if it is not deleted.
//        using (StreamWriter sw = File.AppendText(path))
//        {
//            sw.WriteLine("This");
//            sw.WriteLine("is Extra");
//            sw.WriteLine("Text");
//        }

//        // Open the file to read from.
//        using (StreamReader sr = File.OpenText(path))
//        {
//            string s = "";
//            while ((s = sr.ReadLine()) != null)
//            {
//                Console.WriteLine(s);
//            }
//        }
//    }
//}




