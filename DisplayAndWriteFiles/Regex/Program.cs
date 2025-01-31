using System.Text.RegularExpressions;

namespace _Regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidateName("Abror"));
            Console.WriteLine(ValidateName("abror"));
            Console.WriteLine(ValidateName("ab ror"));
            Console.WriteLine(ValidateName("ab1ror"));
            Console.WriteLine(ValidateName("aBror"));
            Console.WriteLine(ValidateName("AbrorfkjlkflkKfklsadfsfsdf"));
        }
        public static bool ValidateName(string name)
        {
            var namePattern = @"^[A-Z]{1}[a-z]+$";
            var res = Regex.IsMatch(name, namePattern);
            // Match an Email Address
            string emailPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";

            // Match a Phone Number (Format: 123-456-7890)
            string phonePattern = @"^\d{3}-\d{3}-\d{4}$";

            // Match a URL
            string urlPattern = @"^https?:\/\/[\w\-]+(\.[\w\-]+)+[/#?]?.*$";

            // Match a Number (Integer or Decimal)
            string numberPattern = @"^-?\d+(\.\d+)?$";

            // Match a Password (At Least 8 Characters, 1 Letter, 1 Number)
            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            return res;


        }
    }
}
