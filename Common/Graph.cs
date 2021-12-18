using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common
{
    public class Graph
    {
        public Node _rootNode { get; private set; }
        private int _numNodes { get; set; } = 0;
        private List<Node> Q { get; set; } = new();

        public Graph(string[] data)
        {
            _rootNode = CreateGraph(data);
        }

        public Dictionary<string, int> FindShortestPath()
        {
            Dictionary<string, int> dist = new();
            for (int i = 0; i < _numNodes; i++)
                dist[i.ToString()] = int.MaxValue;
            dist["0"] = 0;

            while (Q.Count() > 0)
            {
                Node v = FindMin(dist);
                Q.Remove(v);

                foreach (Node u in v.Edges)
                {
                    int alt = dist[v.Name] + u.Value;
                    if (alt < dist[u.Name])
                        dist[u.Name] = alt;
                }
            }

            return dist;
        }

        private Node FindMin(Dictionary<string, int> dist)
        {
            int minValue = int.MaxValue;
            string minName = "";
            foreach (var item in Q)
            {
                if (dist[item.Name] < minValue)
                {
                    minValue = dist[item.Name];
                    minName = item.Name;
                }
            }
            Node minNode = Q.Where(n => n.Name == minName).First();
            return minNode;
        }

        private Node CreateGraph(string[] data)
        {
            Q = new List<Node>();
            _numNodes = 0;
            Node[,] nodes = new Node[data.Length, data[0].Length];
            for (int rows = 0; rows < data.Length; rows++)
            {
                for (int cols = 0; cols < data[rows].Length; cols++)
                {
                    Node currNode = new Node(_numNodes.ToString(),
                                                int.Parse(data[rows][cols].ToString()));
                    _numNodes++;
                    if (rows > 0)
                        nodes[rows - 1, cols].AddEdge(currNode);
                    if (cols > 0)
                        nodes[rows, cols - 1].AddEdge(currNode);
                    nodes[rows, cols] = currNode;
                    Q.Add(currNode);
                }
            }

            return nodes[0, 0];
        }
    }
}