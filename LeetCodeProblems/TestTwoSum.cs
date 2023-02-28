using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTwoSum {
    public class Solution {
        public int[] TwoSum(int[] nums, int target) {
            var result = new int[2] { 0, 0 };
            for (int i = 0; i < nums.Length; ++i) {
                int value1 = nums[i];
                for (int j = i + 1; j < nums.Length; ++j) {
                    int value2 = nums[j];
                    if(value1 + value2 == target) {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }

            return result;
        }
    }

    [TestClass]
    public class TestTwoSum {
        readonly Solution solution = new Solution();

        [TestMethod]
        public void Test() {
            var result1 = solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Assert.AreEqual(0, result1[0]);
            Assert.AreEqual(1, result1[1]);

            var result2 = solution.TwoSum(new int[] { 3, 2, 4 }, 6);
            Assert.AreEqual(1, result2[0]);
            Assert.AreEqual(2, result2[1]);

            var result3 = solution.TwoSum(new int[] { 3, 3 }, 6);
            Assert.AreEqual(0, result3[0]);
            Assert.AreEqual(1, result3[1]);
        }
    }
}
