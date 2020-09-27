using System.Text;

namespace Text_Formatting
{
    public class FormattedText
    {
        private readonly string _plainText;
        private readonly bool[] _capitalize;

        public FormattedText(string plainText)
        {
            _plainText = plainText;
            _capitalize = new bool[_plainText.Length];
        }

        public void Capitalize(int start, int end)
        {
            for (var i = start; i <= end; i++) _capitalize[i] = true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var index = 0; index < _plainText.Length; index++)
            {
                var c = _plainText[index];
                sb.Append(_capitalize[index] ? char.ToUpper(c) : c);
            }

            return sb.ToString();
        }
    }
}