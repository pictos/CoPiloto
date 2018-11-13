namespace Xamarin.Forms
{
    public static class StringExtentions
    {
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        public static bool IsNullOrWhiteSpaces(this string s) => string.IsNullOrWhiteSpace(s);
    }
}
