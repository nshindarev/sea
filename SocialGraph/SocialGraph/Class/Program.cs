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

			int fragmentlength = 12;
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
			Model.get_sort_bynumber (staff.Count, 0, staff);
			Model.get_sort_bynumber (staff.Count, 1, staff);
			Model.get_sort_bynumber (staff.Count, 2, staff);
			Model.get_sort_bynumber (staff.Count, 3, staff);
			for (int i = 1; i < fragmentlength; i++) {
				//List<string> check = Model.generate_selection (i, staff);
			}
		}
	
	}
}