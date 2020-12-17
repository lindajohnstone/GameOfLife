using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class DimensionSetUp : IValidator
    {
        public DimensionSetUp()
        {
        }

        public bool CorrectFormat(string[] line)
        {
            var regex = new Regex(@"\d{1,2} \d{1,2}");
            return regex.IsMatch(line[0]);
        }
    }
}