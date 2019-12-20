# Optimal.Knapsack

This is a simple zero/one knapsack solver using a dynamic programming algorithm from https://en.wikipedia.org/wiki/Knapsack_problem.

Getting a optimal knapsack is as easy as this:
```

      var capacity = 67;
      var weights = new int[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
      var values = new double[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543 };
      var numItems = weights.Length;
      
      var solver = new ZeroOneKnapsackSolver(weights, values);
      var isInKnapsack = solver.GetSelectedItems(numItems, capacity);
      
```
