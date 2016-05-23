using System;
using System.IO;
using QuickGraph;
using System.Collections.Generic;

namespace SocialGraph
{
	public class InputGraph {
		// Граф + словари с весами вершин и ребер;
		public AdjacencyGraph<string, Edge<string>> social_graph {get; set;}
		public Dictionary<Edge<string>, double> edgeWeight { get; set;}
		public Dictionary<string, double> vertexWeight { get; set;}

		public InputGraph (string input){
			// определяем нужные объекты



			StreamReader reader   = new StreamReader (input);
			this.social_graph  = new AdjacencyGraph<string, Edge<string>> ();

			// словари, хранящие веса ребер и вершин
			this.edgeWeight   = new Dictionary<Edge<string>, double> ();
			this.vertexWeight = new Dictionary<string, double> ();

			//for(int i = 0; i< departmentstxt.Count; i++)
				//department[i] = 
			// считываем взвешенный граф из файла
			// структура input.txt: start || finish || weight_edge || weight_start || weight_finish


			while (!reader.EndOfStream){



				string[] lines = reader.ReadLine ().Split (' ');
				Edge<string> edge = new Edge<string> (lines [0], lines [1]);
				this.social_graph.AddVerticesAndEdge (edge);
				this.edgeWeight.Add (edge, Convert.ToDouble (lines [2]));


				// если строка содержит информацию о весах вершин
				if (lines.Length == 5) {
					if (!vertexWeight.ContainsKey(lines[0]))
					this.vertexWeight.Add (lines[0], Convert.ToDouble(lines[2]));

					if (!vertexWeight.ContainsKey(lines[1]))
					this.vertexWeight.Add (lines[1], Convert.ToDouble(lines[3]));
				}
			}
		}
	}
}

