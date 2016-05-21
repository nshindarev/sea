using System;
using System.Collections.Generic;
using QuickGraph;

namespace SocialGraph
{
	public class KnowlegePattern
	{
		public List<List<Dictionary<string,double>>> Data;
		public Dictionary<Edge<string>, double> edgeWeight { get; set;}
		public Dictionary<string, double> vertexWeight { get; set;}
		public InputGraph G;
		public List<string> staff;


		/* для хранения перестановок: ярусы 1..staff.length
		                              выборки 1..C_{staff.length}*/
				
		public KnowlegePattern (List<string> staff, InputGraph G, Dictionary<Edge<string>, double> edgeWeight, Dictionary<string, double> vertexWeight){
			this.G = G;
			foreach ( string s in staff ) this.staff.Add(s);
			for (int i = 0; i < vertexWeight.Count; i++) {
				
			}
			this.vertexWeight = vertexWeight;
			this.edgeWeight = edgeWeight;
		}
		public void create_structure(){
			
			// сначала добавляем одиночные вершины
			// <<n>> списков одиночных списков из 1го словаря: "("user1_user1", p(user1))"
			List<Dictionary<string,double>> first_floor = new List<Dictionary<string, double>>(staff.Count);
			for (int i = 0; i < staff.Count; i++) {
				// создаем 1 список одиночных вершин
				Dictionary<string,double> cur = new Dictionary<string,double> ();
				cur.Add(staff[i],vertexWeight[staff[i]]);
				first_floor.Add (cur);
			}
			Data.Add (first_floor);


			/* Теперь генерируем для каждого уровня "n" число списков = числу выборки "C_n^k"
			 * k - это текущий уровень
			 */
			if(staff.Count > 2){

			
				// ярус
				for (int k = 2; k < staff.Count; k++) {
					// список - для каждого яруса
					List<Dictionary<string,double>> floor = new List<Dictionary<string, double>>(Model.C_nk(staff.Count, k));
					// для каждого такого списка существует C_nk выборок 
					// для каждой из выборок создаем словарь с перестановками в лексикографическом порядке
					for (int m = 0; m < Model.C_nk (staff.Count, k); m++) {
     					// а дальше начинается вендепиздец, потому что кое-кому необходимо генерировать выборку по ее номеру в зависимости от числа элементов
					}
				}
			}

			int fragmentlength = 0;
			for (int i = 1; i < staff.Count; i++)
				fragmentlength += Model.C_nk (staff.Count, i);

			// 1) Сопоставляем двоичному коду индекса списка выборку.
			// 2) Для выборки генерируем перестановки (см. Java)
			// TODO: надо расширить функционал Java кода с цифр на пользователей И.С. 
			for (int i = 1; i < fragmentlength; i++) {
				List<string> check = Model.generate_selection (i, staff);
				for (int j = 0; j < check.Count; j++) {
 					
				}
			}
		}
		/*public string[] getusersbynumber (int num){ return 0;
			// переводим число в двоичную систему счисления
		}*/
				
	}
}