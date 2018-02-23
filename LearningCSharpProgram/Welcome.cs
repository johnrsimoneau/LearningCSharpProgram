using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCSharpProgram
{
    public static class Welcome
    {
        public static void SetWelcomeMessage()
        {
            Console.Title = "Welcome to the Console App!".ToUpper();
            Console.WriteLine("Navigate to the MAIN MENU by typing - MAIN");
        }
    }
}
