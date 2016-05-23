using System;
using System.IO;
using QuickGraph;
using System.Collections.Generic;

namespace SocialGraph
{
	class MainClass
	{
		public static void Main (string[] args){

			//InputGraph G  = new InputGraph ("../../input_13_users.txt");
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


			/*List<string> vertex_list = new List<string> ();
			foreach (string s in G.social_graph.Vertices)
				vertex_list.Add (s);
			KnowlegePattern KP = new KnowlegePattern (vertex_list, G);

			List<double> probabilities = KP.get_attack("user_1", "user_3");*/

		    List<string> urls = new List<string>() 
			{
				"../../Input_3_users.txt",
				"../../Input_4_users.txt",
				"../../Input_6_users.txt"
			};

			SocialNetwork SN = new SocialNetwork (new InputGraph ("../../Input_13_users.txt"), urls);

			//проверка правильности списка отделов
			for (int i = 0; i < SN.departments.Count; i++) {
				foreach (string s in SN.departments[i])
					Console.Write (s + " ");
				Console.WriteLine ();
			}

			SN.get_attack ("user_9", "user_10");

 				
		}
	
	}
}