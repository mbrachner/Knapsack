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

		private double value(uint numItems, uint capacity)
		{
			if (numItems == 0 || capacity == 0)
			{
				return 0;
			}

			if (valueCache.TryGetValue((numItems, capacity), out var value))
				return value;
			else
			{
				var v = Solve(numItems, capacity);
				valueCache[(numItems, capacity)] = v;
				return v;
			}
		}

		public double Solve(uint numItems, uint capacity)
		{
			if (numItems==0 || capacity == 0)
			{
				return 0;
			}

			if (w[numItems-1] > capacity)
			{
				valueCache[(numItems, capacity)] = value(numItems - 1, capacity);
			}
			else
			{
				valueCache[(numItems, capacity)] = Math.Max(
					value(numItems - 1, capacity),
					value(numItems - 1, capacity - w[numItems-1]) + v[numItems-1]
				);
			}

			return valueCache[(numItems, capacity)];
		}

		public List<bool> GetSelectedItems(uint numItems, uint capacity)
		{
			var selectionList = new List<bool>();
			var currentCapacity = capacity;
			for (var currentItem = numItems; currentItem > 0; currentItem--)
			{
				bool isSelected;
				if (value(currentItem-1, currentCapacity)==value(currentItem, currentCapacity))
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
