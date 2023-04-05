using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ThreeSum {
    public class Solution {

        public IList<IList<int>> ThreeSum(int[] nums) {
            var results = new List<IList<int>>();
            var candidateResult = new int[3] { 0, 0, 0 };
            bool[] isExist = new bool[3] { false, false, false };

            for (int firstElementIndex = 0; nums.Length - firstElementIndex >= 3; ++firstElementIndex) {
                candidateResult[0] = nums[firstElementIndex];
                for (int secondElementIndex = firstElementIndex + 1; nums.Length - secondElementIndex >= 2; ++secondElementIndex) {
                    candidateResult[1] = nums[secondElementIndex];
                    for (int thirdElementIndex = secondElementIndex + 1; nums.Length - thirdElementIndex >= 1; ++thirdElementIndex) {
                        candidateResult[2] = nums[thirdElementIndex];
                        if (candidateResult[0] == 0 && candidateResult[1] == 0 && candidateResult[2] == 0) {
                            candidateResult[0] = 0;
                        }
                        if (candidateResult.Sum() == 0) {
                            if (!results.Any((resultArray) => {
                                isExist[0] = false;
                                isExist[1] = false;
                                isExist[2] = false;
                                for (int i = 0; i < 3; ++i) {
                                    for (int j = 0; j < 3; ++j) {
                                        if(!isExist[j] && candidateResult[i] == resultArray[j]) {
                                            isExist[j] = true;
                                            break;
                                        }
                                    }
                                }
                                return isExist.All((x) => x == true);
                            })) {
                                results.Add(candidateResult);
                            }
                        }
                    }
                }
            }

            return results;
        }
    }

    [TestClass]
    public class ThreeSum {
        readonly Solution solution = new Solution();

        [TestMethod]
        public void Test1() {
            IList<IList<int>> resultList = solution.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            IList<IList<int>> expectList = new List<IList<int>>(new List<IList<int>>()
            {
                new int[] { -1, 0, 1 },
                new int[] { -1, 2, -1 }
            });

            CollectionAssert(expectList, resultList);
        }

        [TestMethod]
        public void Test2() {
            IList<IList<int>> resultList = solution.ThreeSum(new int[] { 0, 0, 0 });
            IList<IList<int>> expectList = new List<IList<int>>(new List<IList<int>>()
            {
                new int[] { 0, 0, 0 }
            });

            CollectionAssert(expectList, resultList);
        }

        [TestMethod]
        public void Test3() {
            IList<IList<int>> resultList = solution.ThreeSum(new int[] { 0, 1, 1 });
            IList<IList<int>> expectList = new List<IList<int>>(new List<IList<int>>() { });

            CollectionAssert(expectList, resultList);
        }

        [TestMethod]
        public void Test4() {
            IList<IList<int>> resultList = solution.ThreeSum(new int[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 });
            IList<IList<int>> expectList = new List<IList<int>>() {
                new List<int>() { -4, -2, 6 },
                new List<int>() { -4, 0, 4 },
                new List<int>() { -4, 1, 3 },
                new List<int>() { -4, 2, 2 },
                new List<int>() { -2, -2, 4 },
                new List<int>() { -2, 0, 2 }
            };

            CollectionAssert(expectList, resultList);
        }
        private void CollectionAssert(IList<IList<int>> expectList, IList<IList<int>> resultList) {
            for (int i = 0; i < expectList.Count; ++i) {
                for (int j = 0; j < expectList[i].Count; ++j) {
                    Assert.AreEqual(expectList[i][j], resultList[i][j]);
                }
            }
        }
    }
}
