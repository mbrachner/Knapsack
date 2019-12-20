using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimal.Knapsack
{
	public class ZeroOneKnapsackSolver
	{
		private readonly int[] w;
		private readonly double[] v;
		private Dictionary<(int,int), double> valueCache 
			= new Dictionary<(int numItems, int capacity), double>();

		public ZeroOneKnapsackSolver(int[] w, double[] v)
		{
			this.w = w;
			this.v = v;
		}

		public int Objective { get; private set; }

		private double bestValueFor(int numItems, int capacity)
		{
			if (numItems == 0 || capacity == 0)
			{
				return 0;
			}

			if (valueCache.TryGetValue((numItems, capacity), out var value))
				return value;
			else
			{
				double v;
				if (w[numItems - 1] > capacity)
				{
					v = this.bestValueFor(numItems - 1, capacity);
				}
				else
				{
					v = Math.Max(
						this.bestValueFor(numItems - 1, capacity),
						this.bestValueFor(numItems - 1, capacity - w[numItems - 1]) + this.v[numItems - 1]
					);
				}
				valueCache[(numItems, capacity)] = v;
				return v;
			}
		}


		public List<bool> GetSelectedItems(int numItems, int capacity)
		{
			var selectionList = new List<bool>();
			var currentCapacity = capacity;
			for (var currentItem = numItems; currentItem > 0; currentItem--)
			{
				bool isSelected;
				if (bestValueFor(currentItem-1, currentCapacity)==bestValueFor(currentItem, currentCapacity))
				{
					isSelected = false;
				} else
				{
					isSelected = true;
					currentCapacity -= this.w[currentItem - 1];
				}
				selectionList.Insert(0, isSelected);
			}
			return selectionList;
		}
	}
}
