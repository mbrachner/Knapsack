using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimal.Knapsack
{
	public class ZeroOneKnapsackSolver
	{
		private readonly uint[] w;
		private readonly double[] v;
		private readonly uint capacity;
		private Dictionary<(uint,uint), double> valueCache 
			= new Dictionary<(uint numItems, uint capacity), double>();

		public ZeroOneKnapsackSolver(uint[] w, double[] v, uint capacity)
		{
			this.w = w;
			this.v = v;
			this.capacity = capacity;
		}

		public int Objective { get; private set; }

		private double bestValueFor(uint numItems, uint capacity)
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


		public List<bool> GetSelectedItems(uint numItems, uint capacity)
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
