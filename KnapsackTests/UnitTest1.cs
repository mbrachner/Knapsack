using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimal.Knapsack;

namespace KnapsackTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod2()
		{
			var capacity = 67;
			var w = new int[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
			var v = new double[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543 };
			var solver = new ZeroOneKnapsackSolver(w, v);
			var res = solver.GetSelectedItems(w.Length, capacity);
			//Assert.AreEqual(res, 1270);
		}
	}
}
