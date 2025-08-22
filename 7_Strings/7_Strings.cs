using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace _7_Strings
{
    internal class Program
    {
        public static string ConcatenateStrings(string string1, string string2)
        {
            return (string1 + string2);
        }

        public static string GreetUser(string name, int age)
        {
            return $"Hello, {name}!\nYou are {age} years old.";
        }

        public static string InfoString(string str)
        {
            int len = str.Length;
            string upper = str.ToUpper();
            string lower = str.ToLower();
            return $"line length = {len}. uppercase string - {upper}. lowercase string - {lower}.";
        }

        public static string first5char(string str)
        {
            string chars5 = str.Substring(0, 5);
            return chars5;
        }

        public static string stringBuild(string[] str)
        {
            StringBuilder build = new StringBuilder(); 
            for (int i = 0; i < str.Length; i++)
            {
                build.Append(str[i]);
                build.Append(" ");
            }
            return build.ToString();
        }

        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord) 
        {
            return inputString.Replace(wordToReplace, replacementWord);;
        } 
      
        static void Main(string[] args)
        {
            string[] testArrayString = {"Hello,", "world", "!", "123"};
            string str1 = "aBc";
            string str2 = "DEf";
            string username = "Username";
            int age = 150;

            Console.WriteLine(ConcatenateStrings(str1, str2));

            Console.WriteLine(GreetUser(username, age));

            Console.WriteLine(InfoString(ConcatenateStrings(str1, str2)));

            string c = first5char(str1 + str2 + str1);
            Console.WriteLine(c);

            Console.WriteLine(stringBuild(testArrayString));

            string result = ReplaceWords("Hello world Hello world Hello world", "world", "universe");
            Console.WriteLine(result);
        }
    }

}

