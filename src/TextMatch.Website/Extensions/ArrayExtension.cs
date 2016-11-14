namespace TextMatch.Website.Extension
{
    public static class ArrayExtension
    {
        public static string JoinArrayIntoStringBySeparator(this int[] array, char separator)
        {
            string joinedText = null;

            for (int i = 0; i < array.Length; i++)
            {
                joinedText = joinedText + array[i];

                if (i + 1 < array.Length)
                {
                    joinedText = joinedText + separator;
                }
            }

            return joinedText;
        }
    }
}