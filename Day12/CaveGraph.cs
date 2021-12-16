using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day12
{
    public class CaveGraph
    {
        private CaveNode _rootNode = null;

        public CaveGraph(string[] data)
        {
            CreateGraph(data);
        }

        public List<string> FindPaths()
        {
            return TravelPaths(_rootNode, new List<CaveNode>());
        }

        public List<string> FindPathsWithOneSmallCaveVisitedTwice()
        {
            return TravelPaths2(_rootNode, new List<CaveNode>(), null);
        }

        private List<string> TravelPaths2(CaveNode currNode, List<CaveNode> visited, CaveNode smallCave)
        {
            if (currNode.Name == "end")
                return new List<string> { ",end" };

            if (currNode.Name == "start" &&
                    visited.Contains(currNode))
                return new List<string>();

            if (currNode.IsSmallCave() &&
                    smallCave != null &&
                    smallCave.Name == currNode.Name &&
                    visited.Where(n => n.Name == currNode.Name).Count() > 1)
                return new List<string>();

            if (currNode.IsSmallCave() &&
                    smallCave != null &&
                    smallCave.Name != currNode.Name &&
                    visited.Contains(currNode))
                return new List<string>();

            if (currNode.IsSmallCave() &&
                    smallCave == null &&
                    visited.Contains(currNode))
                return new List<string>();

            List<string> currPaths = new();
            foreach (var node in currNode.Edges)
            {
                List<string> paths = new();
                if (smallCave is null && currNode.IsSmallCave())
                {
                    paths.AddRange(TravelPaths2(node, new List<CaveNode>(visited) { currNode }, currNode));
                    paths.AddRange(TravelPaths2(node, new List<CaveNode>(visited) { currNode }, null));
                }
                else
                {
                    paths.AddRange(TravelPaths2(node, new List<CaveNode>(visited) { currNode }, smallCave));
                }
                string prefix = currNode.Name == "start" ? "" : ",";
                paths = paths.Select(p => prefix + currNode.Name + p).ToList();
                currPaths.AddRange(paths);
            }

            return currPaths;
        }

        private List<string> TravelPaths(CaveNode currNode, List<CaveNode> visited)
        {
            if (currNode.Name == "end") return new List<string> { ",end" };
            if (currNode.IsSmallCave() && visited.Contains(currNode)) return new List<string>();

            List<string> currPaths = new();
            foreach (var node in currNode.Edges)
            {
                List<string> paths = TravelPaths(node, new List<CaveNode>(visited) { currNode });
                string prefix = currNode.Name == "start" ? "" : ",";
                paths = paths.Select(p => prefix + currNode.Name + p).ToList();
                currPaths.AddRange(paths);
            }

            return currPaths;
        }

        private void CreateGraph(string[] data)
        {
            List<CaveNode> nodes = new();
            for (int i = 0; i < data.Length; i++)
            {
                CaveNode node1 = GetNodeOrDefault(data[i].Split('-', StringSplitOptions.TrimEntries)[0], nodes);
                CaveNode node2 = GetNodeOrDefault(data[i].Split('-', StringSplitOptions.TrimEntries)[1], nodes);

                if (_rootNode is null && node1.Name == "start") _rootNode = node1;
                if (_rootNode is null && node2.Name == "start") _rootNode = node2;

                node1.AddEdge(node2);
                node2.AddEdge(node1);

                if (nodes.Find(n => n.Name == node1.Name) is null) nodes.Add(node1);
                if (nodes.Find(n => n.Name == node2.Name) is null) nodes.Add(node2);
            }
        }

        private CaveNode GetNodeOrDefault(string nodeName, List<CaveNode> nodes)
        {
            CaveNode search = nodes.Find(n => n.Name == nodeName);
            if (search is not null) return search;
            else return new CaveNode(nodeName);
        }

        public CaveNode GetRootNode() => _rootNode;
    }
}