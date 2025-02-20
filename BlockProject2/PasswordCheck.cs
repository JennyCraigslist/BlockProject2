using System.Xml.Serialization;
using System.Text.RegularExpressions;

class PasswordCheck
{
    public enum Strength {WEAK,MEH,STRONG};
    static void Main(string[] args)
    {
        int score = 0;
        Enum strength = Strength.MEH;
        Console.WriteLine("Enter a password to tested for strength!");
        Console.WriteLine("Remember a strong password consists of the following");
        Console.WriteLine("A length exceeding 8");
        Console.WriteLine("At least one capital letter");
        Console.WriteLine("A special character like \' ! @ # $ & * \' etc");
        Console.WriteLine("At least one number");
        
        Console.WriteLine("Enter here:");
        string password = Console.ReadLine();
        if(password.Equals("Password") || password.Equals("password") || password.Equals(""))
        {
            Console.WriteLine("C'mon dude, stop screwing around..");
            return;
        }
        if (password.Length >= 8)
        {
            score++;
        }
        else
        {
            score--;
        }
        if (Regex.IsMatch(password, "[A-Z]"))
        {
            score++;
        }
        else
        {
            score--;
        }
        if (Regex.IsMatch(password, "\\W"))
        {
            score++;
        }
        else
        {
            score--;
        }
        if (!Regex.IsMatch(password, "/d"))
        {
            score++;
        }
        else
        {
            score--;
        }

        //Assign score

        if (score < 0)
        {
            strength = Strength.WEAK;
        }
        else if(score < 0 && score< 2 )
        {
            strength = Strength.MEH;
        }
        else if (score > 2)
        {
            strength = Strength.STRONG;
        }

        switch (strength)
        {
            case Strength.STRONG:
                Console.WriteLine("Your password is considered strong");
                break;
            case Strength.WEAK:
                Console.WriteLine("Your password is considered weak. Consider using another password");
                break;
            case Strength.MEH:
                Console.WriteLine("Your password could use some improvement, but use at your own risk...");
                break;
        }
    }
}