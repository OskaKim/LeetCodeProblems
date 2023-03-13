using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PalindromeNumber {

    public class Solution {
        public bool IsPalindrome(int x) {
            if (x < 0) return false;
            if (x < 10) return true;

            List<int> nums = new List<int>(1);
            while(x > 0) {
                nums.Add(x % 10);
                x /= 10;
            }

            for(int i = 0; i < nums.Count / 2; ++i) {
                if(nums[i] != nums[nums.Count - 1 - i]) {
                    return false;
                }
            }

            return true;
        }
    }

    [TestClass]
    public class PalindromeNumber {
        readonly Solution solution = new Solution();

        [TestMethod]
        public void Test1() {
            Assert.IsTrue(solution.IsPalindrome(0));
            Assert.IsTrue(solution.IsPalindrome(1));
            Assert.IsTrue(solution.IsPalindrome(11));
            Assert.IsTrue(solution.IsPalindrome(121));
            Assert.IsFalse(solution.IsPalindrome(-121));
            Assert.IsFalse(solution.IsPalindrome(10));
        }
    }
}