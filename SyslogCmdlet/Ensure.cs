//-----------------------------------------------------------------------
// <copyright file="Ensure.cs">
//     Copyright
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Poesoft
{
    /// <summary>
    /// Ensures certain conditions are met.
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// Throws an ArgumentNullException if the value is null
        /// </summary>
        /// <param name="value">The value to test for null</param>
        /// <param name="name">The name of the argument to display in the exception</param>
        public static void ArgumentIsNotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException if the value is null
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <param name="name">The name of the argument to display in the exception</param>
        public static void ArgumentIsAPositiveInt(int value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the value is null
        /// </summary>
        /// <param name="value">The value to test for null or whiteSpace</param>
        /// <param name="name">The name of the argument to display in the exception</param>
        public static void ArgumentIsNotNullOrWhiteSpace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(name);
            }
        }
    }
}
