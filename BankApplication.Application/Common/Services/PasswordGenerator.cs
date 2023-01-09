using System;
using System.Text;

namespace BankApplication.Application.Common.Services;

public static class PasswordGenerator
{
    // Generate a random number between two numbers    
    public static int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    // Generate a random string with a given size and case.   
    // If second parameter is true, the return string is lowercase  
    public static string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    // Generate a random password of a given length (optional)  
    public static string RandomPassword(int size = 0)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(RandomString(4, true));
        builder.Append(RandomNumber(1000, 9999));
        builder.Append(RandomString(2, false));
        return builder.ToString();
    }
}

