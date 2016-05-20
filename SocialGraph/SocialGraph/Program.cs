using System;
using System.IO;
using QuickGraph;
using System.Collections.Generic;

namespace SocialGraph
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// определяем нужные объекты
			var reader = new StreamReader ("../../input.txt");
			var social_graph = new AdjacencyGraph<string, Edge<string>> ();
			var edgeWeight = new Dictionary<Edge<string>, double> ();

			// считываем
			while (!reader.EndOfStream){
				string[] lines = reader.ReadLine ().Split (' ');
				var edge = new Edge<string> (lines [0], lines [1]);
				social_graph.AddVerticesAndEdge (edge);
				edgeWeight.Add (edge, Convert.ToDouble (lines [2]));
			}
		}
	
	}
}