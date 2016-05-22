using System;
using System.IO;
using QuickGraph;
using System.Collections.Generic;

namespace SocialGraph
{
	class MainClass
	{
		public static void Main (string[] args){
			
			InputGraph G = new InputGraph ("../../Input.txt");

			/*int fragmentlength = 12;
			List<string> staff = new List<string> {
				{ "user1" },
				{ "user2" },
				{ "user3" },
				{ "user4" },
				{ "user5" }
			};
			// 1) Сопоставляем двоичному коду индекса списка выборку.
			// 2) Для выборки генерируем перестановки (см. Java)
			// TODO: надо расширить функционал Java кода с цифр на пользователей И.С. 
			Model.get_sort_bynumber (0, staff);
			Model.get_sort_bynumber (1, staff);
			Model.get_sort_bynumber (2, staff);
			Model.get_sort_bynumber (3, staff);
			for (int i = 1; i < fragmentlength; i++) {
				//List<string> check = Model.generate_selection (i, staff);
			}
 			*/


			List<string> vertex_list = new List<string> ();
			foreach (string s in G.social_graph.Vertices)
				vertex_list.Add (s);
			KnowlegePattern KP = new KnowlegePattern (vertex_list, G, G.edgeWeight, G.vertexWeight);
			KP.create_structure ();
			for (int i = 0; i< KP.Data.Count; i++){
				foreach (string key in KP.Data[i].Keys ){
					string s = key.Remove (15);
					/*Console.Write(s);
					Console.WriteLine(); */
				}

			
			}
		}
	
	}
}