using System;

namespace TextMatch.Website.Utilities
{
    public static class TextMatchUtility
    {
        public static int[] GetMatchedIndexes(string text, string subtext)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (subtext == null)
            {
                throw new ArgumentNullException(nameof(subtext));
            }

            int textCharsCount = text.Length;
            int subtextCharsCount = subtext.Length;

            int indexesArraySize = 0;

            int[] indexes = new int[indexesArraySize];

            for (int i = 0; i < textCharsCount; i++)
            {
                bool isCharStartsMatch = char.ToLower(subtext[0]) == char.ToLower(text[i]);
                if (isCharStartsMatch)
                {
                    int charsMatchCount = 0;

                    for (int j = 0; j < subtextCharsCount; j++)
                    {
                        int nextCharIndex = i + j >= textCharsCount ? textCharsCount - 1 : i + j;

                        char nextTextChar = text[nextCharIndex];
                        char currentSubtextChar = subtext[j];

                        if (char.IsSeparator(currentSubtextChar))
                        {
                            subtextCharsCount = j;

                            break;
                        }

                        bool isNextCharMatch = char.ToLower(nextTextChar) == char.ToLower(currentSubtextChar);
                        if (isNextCharMatch)
                        {
                            charsMatchCount++;
                        }
                    }

                    if (charsMatchCount == subtextCharsCount)
                    {
                        indexesArraySize++;

                        Array.Resize(ref indexes, indexesArraySize);

                        int charIndex = i + 1;

                        indexes[indexesArraySize - 1] = charIndex;
                    }
                }
            }

            return indexes;
        }
    }
}