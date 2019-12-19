using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Knapsack;

namespace KnapsackTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var w = new uint[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
			var v = new double[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543};
			var solver = new ZeroOneKnapsackSolver(w, v, 67);
			var res = solver.Solve(10, 67);
			Assert.AreEqual(res, 1270);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var w = new uint[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
			var v = new double[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543 };
			var solver = new ZeroOneKnapsackSolver(w, v, 67);
			var res = solver.GetSelectedItems(10, 67);
			//Assert.AreEqual(res, 1270);
		}
	}
}
