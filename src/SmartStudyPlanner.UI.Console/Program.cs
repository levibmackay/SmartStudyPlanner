using SmartStudyPlanner.Core.Models;

namespace SmartStudyPlanner.UI.Console;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ShowDashboard();
    }

    static void ShowDashboard()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=================================================");
        Console.WriteLine("       🎓 SMART STUDY PLANNER DASHBOARD 🎓       ");
        Console.WriteLine("=================================================");
        Console.ResetColor();

        Console.WriteLine($"\n📅 Today: {DateTime.Now:dddd, MMMM dd, yyyy}");
        
        // Mock Data for the visual
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- 📖 Upcoming Assignments ---");
        Console.ResetColor();
        Console.WriteLine("1. [Data Structures] Final Project    - Due: In 3 days (High Priority)");
        Console.WriteLine("2. [Calculus II] Homework Set 4       - Due: Tomorrow");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n--- ✍️ Suggested Study Sessions Today ---");
        Console.ResetColor();
        Console.WriteLine("• 14:00 - 15:30 : Final Project (Deep Work)");
        Console.WriteLine("• 16:00 - 17:00 : Calc Review");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n--- 📊 Grade Overview ---");
        Console.ResetColor();
        Console.WriteLine("Current GPA Estimate: 3.8");
        Console.WriteLine("Status: On track for Dean's List!");

        Console.WriteLine("\n=================================================");
        Console.WriteLine("  [1] View Courses  [2] Add Task  [3] Settings   ");
        Console.WriteLine("=================================================");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
