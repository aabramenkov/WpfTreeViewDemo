﻿using System;

namespace TreeView.Common {
    /// <summary>
    /// Help class to add method for String
    /// </summary>
    public static class StringExtensions {

        /// <summary>
        /// Check whether string Contain another.
        /// Need for possibility compare ignore case.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp) {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
