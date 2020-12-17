using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class GridSetUp : IValidator
    {
        public bool CorrectFormat(string[] setUp)
        {
            var regex = new Regex(@"[A-Za-z] ");
            var lines = setUp.Skip(1).ToArray();
            var count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (!regex.IsMatch(lines[i])) count++;
            }
            if (count > 0) return false;
            return true;
        }
    }
}