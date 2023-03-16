using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RomanToInteger {

    public class Solution {
        private int CovertToInt(char c) {
            return c switch {
                ('I') => 1,
                ('V') => 5,
                ('X') => 10,
                ('L') => 50,
                ('C') => 100,
                ('D') => 500,
                ('M') => 1000,
                _ => 0,
            };
        }

        public int RomanToInt(string s) {
            int result = 0;
            int before = 0;
            foreach(var c in s.ToCharArray()) {
                int cur = CovertToInt(c);
                if(cur > before) {
                    cur = cur - before * 2;
                }
                before = cur;
                result += cur;
            }
            return result;
        }
    }

    [TestClass]
    public class RomanToInteger {
        readonly Solution solution = new Solution();

        [TestMethod]
        public void Test1() {
            Assert.AreEqual(0, solution.RomanToInt(""));
            Assert.AreEqual(3, solution.RomanToInt("III"));
            Assert.AreEqual(58, solution.RomanToInt("LVIII"));
            Assert.AreEqual(1994, solution.RomanToInt("MCMXCIV"));
        }
    }
}