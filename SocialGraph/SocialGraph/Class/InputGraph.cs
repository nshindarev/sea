using System;
using System.IO;
using QuickGraph;
using System.Collections.Generic;

namespace SocialGraph
{
	public class InputGraph
	{
		// Граф + словари с весами вершин и ребер;
		public AdjacencyGraph<string, Edge<string>> social_graph {get; set;}
		public Dictionary<Edge<string>, double> edgeWeight { get; set;}
		public Dictionary<string, double> vertexWeight { get; set;}

		public InputGraph (string input){
			// определяем нужные объекты
			var reader   = new StreamReader (input);
			var social_graph  = new AdjacencyGraph<string, Edge<string>> ();

			// словари, хранящие веса ребер и вершин
			var edgeWeight   = new Dictionary<Edge<string>, double> ();
			var vertexWeight = new Dictionary<string, double> ();

			// считываем взвешенный граф из файла
			// структура input.txt: start || finish || weight_edge || weight_start || weight_finish
			while (!reader.EndOfStream){
				string[] lines = reader.ReadLine ().Split (' ');
				var edge = new Edge<string> (lines [0], lines [1]);
				social_graph.AddVerticesAndEdge (edge);
				edgeWeight.Add (edge, Convert.ToDouble (lines [2]));

				// если строка содержит информацию о весах вершин
				if (lines.Length == 5) {
					vertexWeight.Add (lines[0], Convert.ToDouble(lines[3]));
					vertexWeight.Add (lines[1], Convert.ToDouble(lines[4]));
				}
			}
		}
	}
}

