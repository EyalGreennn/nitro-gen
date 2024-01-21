using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to EG Nitro Generator | Made by eyalgreen.com");
        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Generate Codes");
            Console.WriteLine("2. Exit");
            Console.WriteLine("3. Credits");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    GenerateCodes();
                    break;
                case "2":
                    Console.WriteLine("Exiting the program...");
                    return;
                case "3":
                    Console.WriteLine("Developed by EyalGreennn in github | Website: eyalgreen.com");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void GenerateCodes()
    {
        Console.WriteLine("Enter the amount of codes to generate");
        if (!int.TryParse(Console.ReadLine(), out int numberOfCodes))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }
        Console.Write("Enter the codes per second: ");
        if (!int.TryParse(Console.ReadLine(), out int generationRate))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }
        Console.WriteLine($"Generating {numberOfCodes} gift codes...");
        List<string> codes = new List<string>();
        for (int i = 1; i <= numberOfCodes; i++)
        {
            codes.Add($"https://discord.gg/gift/{GenerateCode()}");
            Thread.Sleep(1000 / generationRate);
        }
        SaveCodes(codes);
    }

    static string GenerateCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        char[] codeArray = new char[16];
        for (int i = 0; i < codeArray.Length; i++)
        {
            codeArray[i] = chars[random.Next(chars.Length)];
        }
        return new string(codeArray);
    }

    static void SaveCodes(List<string> codes)
    {
        string folder = "codes";
        Directory.CreateDirectory(folder);
        string filename = $"codes_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        string path = Path.Combine(folder, filename);
        try
        {
            File.WriteAllLines(path, codes);
            Console.WriteLine($"Generated gift codes have been saved to: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving codes: {ex.Message}");
        }
    }
}
