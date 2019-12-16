using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
	public class ZeroOneKnapsackSolver
	{
		private readonly uint[] w;
		private readonly double[] v;
		private Dictionary<uint,uint> value = new Dictionary<uint, uint>();

		public ZeroOneKnapsackSolver(uint[] w, double[] v, uint capacity)
		{
			this.w = w;
			this.v = v;
		}

		public int Objective { get; private set; }

		public void Solve()
		{
			throw new NotImplementedException();
		}
	}
}
