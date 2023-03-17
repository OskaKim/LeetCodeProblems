using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedianOfTwoSortedArrays {

    public class Solution {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            int[] arrays = nums1.Concat(nums2).ToArray();
            Array.Sort(arrays, delegate (int x, int y) { return x.CompareTo(y); });
            int size = arrays.Length;
            int middleOfArray = arrays.Length / 2;
            if (arrays.Length % 2 == 0) {
                return Convert.ToDouble(arrays[middleOfArray - 1] + arrays[middleOfArray]) / 2;
            }
            return arrays[middleOfArray];
        }
    }

    [TestClass]
    public class MedianOfTwoSortedArrays {
        readonly Solution solution = new Solution();

        [TestMethod]
        public void Test1() {
            Assert.AreEqual(0, solution.FindMedianSortedArrays(new int[] { }, new int[] { 0 }));
            Assert.AreEqual(-0.5, solution.FindMedianSortedArrays(new int[] { -1, 0 }, new int[] { }));
            Assert.AreEqual(2, solution.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
            Assert.AreEqual(2.5, solution.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
        }
    }
}