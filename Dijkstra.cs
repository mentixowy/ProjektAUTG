using System;
using System.Collections.Generic;
using System.Linq;

namespace Grafy
{
    static public class Dijkstra
    {

        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            var n = graph.GetLength(0);

            var distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[sourceNode] = 0;

            var used = new bool[n];
            var previous = new int?[n];

            while (true)
            {
                var minDistance = int.MaxValue;
                var minNode = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && minDistance > distance[i])
                    {
                        minDistance = distance[i];
                        minNode = i;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        var shortestToMinNode = distance[minNode];
                        var distanceToNextNode = graph[minNode, i];

                        var totalDistance = shortestToMinNode + distanceToNextNode;

                        if (totalDistance < distance[i])
                        {
                            distance[i] = totalDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new LinkedList<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.AddFirst(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            return path.ToList();
        }

        public static string PrintPath(int[,] graph, int sourceNode, int destinationNode)
        {
            string temp = "";


            var path = DijkstraAlgorithm(graph, sourceNode, destinationNode);

            if (path == null)
            {
                return temp;
            }
            else
            {
                int pathLength = 0;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                }

                var formattedPath = string.Join("->", path);


                temp += " " + formattedPath + "\n" + "Długość scieżki: " + pathLength;
                return temp;
            }
        }

        public static string GraphDiameter(int[,] graph)
        {
            string result = "";
            string currentPath = "";
            var pathLenght = 0;
            int diameter = 0;
            for (int sourceNode = 0; sourceNode < graph.GetLength(0); sourceNode++)
            {
                for (int destinationNode = 0; destinationNode < graph.GetLength(0); destinationNode++)
                {
                    currentPath = "";
                    pathLenght = 0;
                    var path = DijkstraAlgorithm(graph, sourceNode, destinationNode);
                    foreach (var item in path)
                    {
                        currentPath += item.ToString();
                    };
                    pathLenght = currentPath.Length - 1;
                    if (pathLenght > diameter)
                    {
                        diameter = pathLenght;
                    }
                }
            }
            result = diameter.ToString();
            return result;
        }

        public static bool Check(int[,] graph)
        {
            bool result = true;
            for (int sourceNode = 0; sourceNode < graph.GetLength(0); sourceNode++)
            {
                for (int destinationNode = 0; destinationNode < graph.GetLength(0); destinationNode++)
                {
                    if (sourceNode != destinationNode)
                    {
                        var path = DijkstraAlgorithm(graph, sourceNode, destinationNode);
                        if (path == null) result = false;
                    }
                }
            }
            return result;
        }

        public static string Density(int[,] graph, int counter)
        {
            string result = "";
            double maxValue = graph.GetLength(0) * (graph.GetLength(0) - 1);
            double density = 2 * (double)counter / maxValue;
            result = density.ToString();
            return result;
        }

        public static string Center(int[,] graph)
        {
            int n = graph.GetLength(0);
            string result = "";
            int[] tab = new int[n];
            int minPaths = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                tab[i] = 0;
            }
            for (int sourceNode = 0; sourceNode < graph.GetLength(0); sourceNode++)
            {
                for (int destinationNode = 0; destinationNode < graph.GetLength(0); destinationNode++)
                {
                    if (sourceNode != destinationNode)
                    {
                        var path = DijkstraAlgorithm(graph, sourceNode, destinationNode);
                        tab[sourceNode] += path.Count;
                    }
                }
                if (tab[sourceNode] < minPaths)
                {
                    minPaths = tab[sourceNode];
                    result = sourceNode.ToString();
                }
            }
            return result;
        }
    }
}
