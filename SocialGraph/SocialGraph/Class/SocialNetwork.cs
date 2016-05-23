using System;
using System.Collections.Generic;
using QuickGraph;	

namespace SocialGraph
{
	public class SocialNetwork
	{
		public InputGraph G;
		// хранение исходного графа G
		// связи между К.З.
		public AdjacencyGraph<KnowlegePattern, Edge<KnowlegePattern>> SocGraphWithKP {get; set;}
		public Dictionary<Edge<KnowlegePattern>, List<string>> edgeWeight { get; set;}

		public List<List<string>> departments;
		public List<KnowlegePattern> KnowlegePattern_net; 

		public SocialNetwork (InputGraph G, List<string> url_for_KP){

			this.G = G;

			departments = new List<List<string>> ();
			edgeWeight = new Dictionary<Edge<KnowlegePattern>, List<string>> (); 
			KnowlegePattern_net = new List<KnowlegePattern> ();
			SocGraphWithKP = new AdjacencyGraph<KnowlegePattern, Edge<KnowlegePattern>>();

			// G_KP --- полные подграфы
			// KP-LIST --- сгенерированные отделы
			// Заполняем список отделов
			List<InputGraph> G_KP = new List<InputGraph>(url_for_KP.Count);
			KnowlegePattern_net = new List<KnowlegePattern>(url_for_KP.Count);

			int j = 0;
			List<string> vertex_list;
			foreach (string s in url_for_KP) {
				G_KP.Add(new InputGraph(s));
				vertex_list = new List<string> ();



				foreach (string department in G_KP[j].social_graph.Vertices)
					vertex_list.Add (department);
			
				departments.Add(vertex_list);


				KnowlegePattern_net.Add(new KnowlegePattern (vertex_list, G_KP[j]));
				j++;
			}

			// заполняем SocGraph
			for (int i = 0; i < KnowlegePattern_net.Count; i++)
				SocGraphWithKP.AddVertex (KnowlegePattern_net[i]);


			// заполняем всевозможные связи между отделами
			List<string> first_find_matches = new List<string>();
			List<string> second_find_matches = new List<string>();
			List<string> found = new List<string> ();

			for (int i = 0; i < KnowlegePattern_net.Count; i++)
				for (int k = i; k < KnowlegePattern_net.Count; k++){

					//first_find_matches = new string[KnowlegePattern_net [i].G.social_graph.VertexCount];
					foreach (string vert_i in KnowlegePattern_net [i].G.social_graph.Vertices)
						first_find_matches.Add (vert_i);
					foreach (string vert_k in KnowlegePattern_net [k].G.social_graph.Vertices)
						first_find_matches.Add (vert_k);
					// get list of users in both KP
					for (int a = 0; a < first_find_matches.Count; a++)
						for(int b = 0; b < second_find_matches.Count; b++) { 
							if ((first_find_matches [a] == second_find_matches [b]) && (!found.Contains (first_find_matches [a])))
								found.Add (first_find_matches [a]);
					
						//добавление дуги
						if (found.Count > 0) {
							Edge<KnowlegePattern> e = new Edge<KnowlegePattern> (KnowlegePattern_net [i],KnowlegePattern_net [k]);
							if (!SocGraphWithKP.ContainsEdge (e)) {
								SocGraphWithKP.AddEdge (e);
								edgeWeight.Add(e, found);
							}
						}
						}
					}
			
		}

		// возвращает список возможных атак через смежных пользователей 
		public List<List<double>> get_attack (string user1, string user2){

			List<List<double>> output = new List<List<double>> ();
			int _case = 0;
			/*foreach (KnowlegePattern p in SocGraphWithKP.Vertices)
				if (p.G.)*/

			// пользователи из одного отдела - используем сгенерированное
			// если нашли -> дальше не идем
			bool check = false;
			foreach (KnowlegePattern KP in SocGraphWithKP.Vertices) {
				if (KP.staff.Contains (user1) && KP.staff.Contains (user2)) {
					check = true;
					output.Add (KP.get_attack (user1, user2));
					return output;
				}
			}

			if (!check) {
				KnowlegePattern START_KP = null;
				KnowlegePattern FINISH_KP = null;
				// пользователи из разных отделов
				

				foreach (KnowlegePattern KP in SocGraphWithKP.Vertices) {
					if (KP.staff.Contains (user1)) {
						START_KP = KP;
					} else if (KP.staff.Contains (user2)) {
						FINISH_KP = KP;
					}
				

					// проверка на наличие связей между отделами
					for (int i = 0; i < START_KP.staff.Count; i++)
						for (int j = 0; j < FINISH_KP.staff.Count; j++) {

							// 1 пользователь в 2 отделах -> просмотрим атаку через него
							if (START_KP.staff [i] == FINISH_KP.staff [j]) {
								output.Add (merge_attack_by_user (START_KP, FINISH_KP, user1, user2, START_KP.staff [i]));
							}
							Edge<string> e;


							if (this.G.social_graph.TryGetEdge (START_KP.staff [i], FINISH_KP.staff [j], out e)) {
								output.Add (merge_attack_by_edge (START_KP, FINISH_KP, user1, user2, e));

							}
							
						}
			
				}
			
			}
			return output;
			}
				

				// получаем списки отделов и смотрим на пересечения
		public List<double> merge_attack_by_edge (KnowlegePattern KP_user1, KnowlegePattern KP_user2,  string user1, string user2, Edge<string> e){
			
			List<double> output = new List<double> ();

			List<double> KP_user1_getattacklist = KP_user1.get_attack (user1, e.Source);
			List<double> KP_user2_getattacklist = KP_user2.get_attack (e.Target, user2);

			double _out;
			// рассматриваем все цепочки до связи между отделами
			for (int i = 0; i < KP_user1_getattacklist.Count; i++)
				for (int j = 0; j < KP_user2_getattacklist.Count; j++) {
					_out = (KP_user2_getattacklist [j] * KP_user1_getattacklist [i] * G.edgeWeight[e])/ KP_user1.vertexWeight [user2]; 
					output.Add (_out);
				}

			return output;
		}
		public List<double> merge_attack_by_user (KnowlegePattern KP_user1, KnowlegePattern KP_user2,  string user1, string user2, string user_in_both){

			List<double> output = new List<double> ();

			List<double> KP_user1_getattacklist = KP_user1.get_attack (user1, user_in_both);
			List<double> KP_user2_getattacklist = KP_user2.get_attack (user_in_both, user2);

			// рассматриваем все цепочки до связи между отделами
			for (int i = 0; i < KP_user1_getattacklist.Count; i++)
				for (int j = 0; j < KP_user2_getattacklist.Count; j++) {
					output.Add (KP_user2_getattacklist[j] * 
						KP_user1_getattacklist[i] / KP_user1.vertexWeight[user_in_both]
								);
			}
			return output;
	
		}

	}
}

// методы, упрощающие работу с фрагментами знаний
// методы, переходящие к локальному выводу/ к глобальному
/* нужно как-то учитывать связи, которые возникают между сотрудниками из разных отделов. Например, создать
     * список самых важных связей среди сотрудников из разных отделов и  */