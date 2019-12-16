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
			var w = new double[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
			var v = new double[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543};
			var solver = new ZeroOneKnapsackSolver(w, v);
			solver.Solve();
			Assert.AreEqual(solver.Objective, 1270);
		}
	}
}
