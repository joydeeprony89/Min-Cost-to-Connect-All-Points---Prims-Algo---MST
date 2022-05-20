using System;
using System.Collections.Generic;

namespace Min_Cost_to_Connect_All_Points___Prims_Algo___MST
{
  class Program
  {
    static void Main(string[] args)
    {
      int[][] points = new int[5][] { new int[] { 0 , 0 }, new int[] { 2 , 2 }, new int[] { 3 , 10 }, new int[] { 5, 2 }, new int[] { 7, 0 } };
      Program p = new Program();
      var result =  p.MinCostConnectPoints(points);
      Console.WriteLine(result);
    }

    public int MinCostConnectPoints(int[][] points)
    {
      int minCost = 0;
      // PQ to hold the each nodes dostance from its neighbours
      PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
      // push 0 initially to start the looping
      pq.Enqueue(0, 0);
      // visited HashSet to keep track of nodes are already processed
      HashSet<int> visited = new HashSet<int>();
      int totalNodes = points.Length;
      while (visited.Count < totalNodes)
      {
        // dequeue the minimum ditance for a node
        pq.TryDequeue(out var currentNode, out var currentDistance);
        if (visited.Contains(currentNode)) continue;
        visited.Add(currentNode);
        minCost += currentDistance;
        if (visited.Count == totalNodes) return minCost;
        // count the distance from current node to all neighbours
        for (int nextNode = 1; nextNode < totalNodes; nextNode++)
        {
          if (visited.Contains(nextNode)) continue;
          pq.Enqueue(nextNode, Distance(currentNode, nextNode));
        }
      }
      return minCost;

      int Distance(int i, int j)
      {
        int x1 = points[i][0];
        int x2 = points[j][0];
        int y1 = points[i][1];
        int y2 = points[j][1];
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
      }
    }
  }
}
