using System.Text.RegularExpressions;

namespace Library.DataContract
{
    public record Rules
    {
        public Rules(int targetLength, Regex regex)
        {
            if (targetLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(targetLength));

            TargetLength = targetLength;
            Regex = regex;
        }

        /// <summary>
        /// According to the rules, the string can only be specific length
        /// </summary>
        internal int TargetLength { get; init; }

        // Additional rules
        private Regex Regex { get; }

        /// <param name="str">A string to check</param>
        /// <returns>Return true if string provided matches the rules.</returns>
        internal bool IsValidString(string str)
        {
           return Regex.Match(str).Success;
        }
    }
}
