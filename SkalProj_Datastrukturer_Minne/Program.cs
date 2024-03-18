using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>

        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }


        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}


            /*Frågor
             *****************************************************************************************************************************
             2. När ökar listans kapacitet?
            
                Svar: Kapaciteten ökar när man lägger till items som överstiger kapacitetens gräns
            
             3. Med hur mycket ökar kapaciteten?
            
                Svar: Kapaciteten fördublas när man överstiger gränsen
            
             4. varför ökar inte listans kapacitet i samma takt som elements läggs till? 
            
                Svar: . När du lägger till element i listan och den underliggande arrayen når sin kapacitet,
                        behöver listan alloka en ny array med större kapacitet och kopiera alla befintliga element till den.
                        Denna process medför en prestandaöverhead, så kapaciteten ökas inte med varje elementtillägg.
            
             5. Minskar Kapaciteten när element tas bort från listan?
            
                Svar: Nej, kapaciteten behåller sin ökad storlek även när man tar bort element
            
             6. När är det fördelaktigt att använda en egendefinerad array istället för en lista?
            
                Svar: man kan använda en array istället för en lista om man vet i förväg hur många element den kommer att hålla,
                      vilket kan hjälpa till att undvika onödiga reallokeringar.
            *************************************************************************************************************************************/



            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter '+' to add or '-' to remove from the list" +
                                "(Or type exit to go back to the menu) :");
                string input = Console.ReadLine();

                if (input.Length == 0) // Check if input is empty
                    continue;

                char nav = input[0];
                string value = input.Substring(1).Trim();// Remove any whitespaces

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added '{value}' to the list");
                        break;
                    case '-':
                        if (theList.Remove(value))
                            Console.WriteLine($"Removed '{value}' from the list");
                        else
                            Console.WriteLine($"'{value}' not found in the list");
                        break;
                    default:
                        Console.WriteLine("Please use only '+' or '-' ");
                        break;
                }
                Console.WriteLine($"Current count: {theList.Count}");
                Console.WriteLine($"Current capacity: {theList.Capacity}");

                // To exit the loop if the user inputs any other key
                if (input.ToLower() == "exit")
                    break;



            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */


            Queue<string> theQueue = new Queue<string>();
            while (true)
            {
                Console.WriteLine("Enter 'e' to enqueue or 'd' to dequeue from the queue (Or type exit to go back to the menu) :");
                string input = Console.ReadLine();

                if (input.ToLower().Length == 0)
                    continue;

                char nav = input[0];
                string value = input.Substring(1).Trim();

                switch (nav)
                {
                    case 'e':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"Enqueued '{value}' to the queue");
                        break;
                    case 'd':
                        if (theQueue.Count > 0)
                            Console.WriteLine($"Dequeued '{theQueue.Dequeue()}' from the queue");
                        else
                            Console.WriteLine("Queue is empty");
                        break;
                    default:
                        Console.WriteLine("Please use only 'e' or 'd' ");
                        break;
                }

                Console.WriteLine($"Current count: {theQueue.Count}");
                Console.WriteLine("Current items in the queue :");
                foreach (var item in theQueue)
                {
                    Console.WriteLine(item);
                }



                if (input.ToLower() == "exit")

                    break;

            }
        }
        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> theStack = new Stack<string>();
            while (true)
            {
                Console.WriteLine("Enter 'p' to push or 'o' to pop from the stack (Or type exit to go back to the menu) :");
                string input = Console.ReadLine();

                if (input.ToUpper().Length == 0)
                    continue;

                char nav = input[0];
                string value = input.Substring(1).Trim();

                switch (nav)
                {
                    case 'p':
                        theStack.Push(value);
                        Console.WriteLine($"Pushed '{value}' to the stack");
                        break;
                    case 'o':
                        if (theStack.Count > 0)
                            Console.WriteLine($"Popped '{theStack.Pop()}' from the stack");
                        else
                            Console.WriteLine("Stack is empty");
                        break;
                    default:
                        Console.WriteLine("Please use only 'p' or 'o' ");
                        break;
                }

                Console.WriteLine($"Current count: {theStack.Count}");
                Console.WriteLine("Current items in the list :");
                foreach (var item in theStack)
                {
                    Console.WriteLine(item);
                }

                if (input.ToLower() == "exit")
                    break;
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Enter a string to check the balance of parentheses:");
            string input = Console.ReadLine();

            if (IsBalanced(input))
            {
                Console.WriteLine("The parentheses are balanced.");
            }
            else
            {
                Console.WriteLine("The parentheses are not balanced.");
            }

        }

        static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        return false; // There is no opening parenthesis for this closing one
                    }

                    char top = stack.Pop();

                    if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    {
                        return false; // Mismatched parentheses
                    }
                }
            }

            return stack.Count == 0; // If stack is empty, all parentheses were balanced
        }

    }

    /*Fråga 1. Hur fungerar stacken och heapen?
     * 
     * Svar:
     * 
     * Stacken (Stack):

     Stacken är en datastruktur som använder sig av en sist in first ut -metod,det är vanligtvis mindre och har en fast storlek som bestäms vid programkörning.
     Variabler som skapas på stacken lever bara så länge som funktionen de är deklarerade i är aktiv.
     När en funktion anropas läggs dess lokala variabler och återvändningsadress till den aktuella funktionen på stacken.
     När funktionen slutförs tas dessa variabler bort från stacken.


     Exempel:
     void ExampleMethod()
     {
      int x = 5; // Variabeln x lagras på stacken
      string message = "Hello"; // Strängen message lagras på stacken
     }



     Heapen (Heap):

     Heapen är en del av minnet där objekt och stora datatyper lagras,Objekt som skapas med nyckelordet new lagras på heapen.

     Till skillnad från stacken är heapen ostrukturerad, och objekt lagras och tas bort i vilken ordning som helst.

     Objekt på heapen har längre livslängd än de som lagras på stacken och finns kvar tills de inte längre refereras till.


     Exempel:
     class Person
     {
      public string Name;
      public int Age;
     }

     void Main()
     {
      Person person = new Person(); // Ett nytt Person-objekt skapas och lagras på heapen
      person.Name = "Alice";
      person.Age = 30;
     }
     I exemplet ovan lagras variabeln person (som är en referens till ett objekt av typen Person) på stacken,
     medan det faktiska Person-objektet lagras på heapen
    --------------------------------------------------------------------------------------------------------
    Fråga 2. Vad är value types respektive Reference types och vad skiljer dem åt?

    Svar:
    
    Value Types:

    Valur types lagras direkt i minnet där variabeln är definierad.
    De innehåller själva värdet.
    När en variabel tilldelas en värde typ, skapas en kopia av värdet.
    Exempel på value types inkluderar int, float, double, char, bool och structs.

    Reference Types:

    Referenstyper lagrar en referens (en pekare) till platsen där datan finns lagrad i minnet.
    De innehåller inte själva värdet, utan en referens till värdet.
    När en variabel tilldelas en referenstyp, pekar den på en plats i minnet där datan finns.
    Exempel på referenstyper inkluderar klasser, arrays, interfaces och delegates.

    Skillnader:

    Value types lagras direkt där variabeln är definierad medan reference types lagrar en referens
    till platsen där datan finns.
    När en värde typ kopieras, kopieras själva värdet medan när en referenstyp kopieras, kopieras bara referensen.
    --------------------------------------------------------------------------------------------------------------
    Fråga 3.Följande metoder generar olika svar . den första returnerar 3, den andra returnerar 4,varför?

    Svar:

    I den första metoden hanterar du primitiva typer (int), så tilldelningen av y påverkar inte x.
    I den andra metoden hanterar du dock referenstyper (MyInt), så när du tilldelar y = x,
    pekar du faktiskt både x och y på samma objekt, och att ändra y.MyValue ändrar också x.MyValue.
     */
}

