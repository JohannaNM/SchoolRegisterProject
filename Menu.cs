using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegisterProject
{
    internal class Menu
    {

        public static int Menus(string option1, string option2, string option3, string option4, string option5, string option6, string option7, string option8)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("Use ⬆️ and ⬇️ to navigate and press Enter / Return to select:");
            Console.WriteLine("Please make a choice ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}");
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}3 {option3}");
                Console.WriteLine($"{(option == 4 ? decorator : "   ")}4 {option4}");
                Console.WriteLine($"{(option == 5 ? decorator : "   ")}5 {option5}");
                Console.WriteLine($"{(option == 6 ? decorator : "   ")}6 {option6}");
                Console.WriteLine($"{(option == 7 ? decorator : "   ")}7 {option7}");
                Console.WriteLine($"{(option == 8 ? decorator : "   ")}8 {option8}");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 8 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 8 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }

        public static int Menus(string option1, string option2, string option3, string option4, string option5, string option6)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("Use ⬆️ and ⬇️ to navigate and press Enter / Return to select:");
            Console.WriteLine("Please make a choice");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}");
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}3 {option3}");
                Console.WriteLine($"{(option == 4 ? decorator : "   ")}4 {option4}");
                Console.WriteLine($"{(option == 5 ? decorator : "   ")}5 {option5}");
                Console.WriteLine($"{(option == 6 ? decorator : "   ")}6 {option6}");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 6 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 6 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }

        public static int Menus(string option1, string option2, string option3, string option4, string option5)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("Use ⬆️ and ⬇️ to navigate and press Enter / Return to select:");
            Console.WriteLine("Please make a choice");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}");
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}3 {option3}");
                Console.WriteLine($"{(option == 4 ? decorator : "   ")}4 {option4}");
                Console.WriteLine($"{(option == 5 ? decorator : "   ")}5 {option5}");


                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 5 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 5 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }

        public static int Menus(string option1, string option2, string option3, string option4)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("Use ⬆️ and ⬇️ to navigate and press Enter / Return to select:");
            Console.WriteLine("Please make a choice ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}");
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}3 {option3}");
                Console.WriteLine($"{(option == 4 ? decorator : "   ")}4 {option4}");


                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }

        public static int Menus(string option1, string option2, string option3)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("Use ⬆️ and ⬇️ to navigate and press Enter / Return to select:");
            Console.WriteLine("Please make a choice ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}");
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}3 {option3}");


                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 3 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 3 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }

        public static int Menus(string option1, string option2)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("Use ⬆️ and ⬇️ to navigate and press Enter / Return to select:");
            Console.WriteLine("Please make a choice ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}");


                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 2 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 2 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }
    }
}
