namespace SplitItScrap.Domain.Helpers
{
    public static class StringSplitHelper
    {
        public static (string text1, string text2) SplitText(string input, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(input))
                return (string.Empty, string.Empty);

            int dotIndex = input.IndexOf(delimiter);
            if (dotIndex == -1)
                return (string.Empty, input.Trim());

            string number = input.Substring(0, dotIndex).Trim();
            string text = input.Substring(dotIndex + 1).Trim();

            return (number, text);
        }
    }
}
