using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AddTwoNumbers {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            ListNode outNode = new ListNode();
            ListNode curNode = null, curL1 = null, curL2 = null;
            int addValFromBefore = 0;
            for (int i = 0; ; ++i) {
                if (curNode == null) {
                    curNode = outNode;
                    curL1 = l1;
                    curL2 = l2;
                }
                else {
                    if (curL1 != null) { curL1 = curL1.next; }
                    if (curL2 != null) { curL2 = curL2.next; }
                    if (curL1 == null && curL2 == null) {
                        if(addValFromBefore > 0) {
                            curNode.next = new ListNode(addValFromBefore);
                        }
                        break;
                    }
                    curNode.next = new ListNode();
                    curNode = curNode.next;
                }
                var curL1Val = curL1 == null ? 0 : curL1.val;
                var curL2Val = curL2 == null ? 0 : curL2.val;
                var curVal = curL1Val + curL2Val + addValFromBefore;

                addValFromBefore = 0;
                while (curVal >= 10) {
                    curVal -= 10;
                    ++addValFromBefore;
                }
                curNode.val = curVal;
            }
            return outNode;
        }
    }

    [TestClass]
    public class AddTwoNumbers {
        readonly Solution solution = new Solution();

        [TestMethod]
        public void Test1() {
            var param1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var param2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            var result = solution.AddTwoNumbers(param1, param2);
            Assert.AreEqual(7, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(8, result.val);
            Assert.IsNull(result.next);
        }

        [TestMethod]
        public void Test2() {
            var param1 = new ListNode(0);
            var param2 = new ListNode(0);

            var result = solution.AddTwoNumbers(param1, param2);
            Assert.AreEqual(0, result.val);
            Assert.IsNull(result.next);
        }

        [TestMethod]
        public void Test3() {
            var param1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            var param2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));

            var result = solution.AddTwoNumbers(param1, param2);
            Assert.AreEqual(8, result.val);

            result = result.next;
            Assert.AreEqual(9, result.val);

            result = result.next;
            Assert.AreEqual(9, result.val);

            result = result.next;
            Assert.AreEqual(9, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(1, result.val);
            Assert.IsNull(result.next);
        }

        [TestMethod]
        public void Test4() {
            var param1 = new ListNode(2, new ListNode(4, new ListNode(9)));
            var param2 = new ListNode(5, new ListNode(6, new ListNode(4, new ListNode(9))));

            var result = solution.AddTwoNumbers(param1, param2);
            Assert.AreEqual(7, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(4, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(1, result.val);
            Assert.IsNull(result.next);
        }

        [TestMethod]
        public void Test5() {
            var param1 = new ListNode(9);
            var param2 = new ListNode(1, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))));

            var result = solution.AddTwoNumbers(param1, param2);
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(0, result.val);

            result = result.next;
            Assert.AreEqual(1, result.val);
            Assert.IsNull(result.next);
        }
    }
}
