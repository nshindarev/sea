using System;
using System.Collections.Generic;

namespace SocialGraph
{
	public static class Model
	{	
		/// <summary>
		/// Methods for permutation 
		/// </summary>
		/// <param name="length">Length.</param>
		/// <param name="sort">Sort.</param>
		public static void get_value_bysort(int length, int[] sort) {

			// инициализируем диапазон поиска и факториал
			int temp_length = length - 1;
			int fact_length = Model.math_factorial(temp_length);

			int[] range = new int[2];
			range[0] = 0;
			range[1] = fact_length - 1;

			//массив флажков для проверки посещения
			bool[] visited = new bool[length];


			//порядковое по возрастанию из непосещенных
			int count_visited = sort[0];

			for (int i=0; i< sort.Length; i++){

				count_visited = sort[i];
				for (int j=0; j<sort[i]; j++)
					if (visited[j]) count_visited--;


				range[0] += (count_visited - 1)*fact_length;
				range[1] = count_visited * fact_length;

				temp_length--;
				fact_length = Model.math_factorial(temp_length);

				visited[sort[i]-1] = true;
			}
			Console.WriteLine("\n" + range[0]);
			//   System.out.println("\n" + range[1]);
		}
		public static List<string> get_sort_bynumber(int number, List<string> chosen_staff) {

			// для записи непосещенных
			int[] numbersleft = new int[chosen_staff.Count];
			int k = 1;
			for (int i = 0; i< chosen_staff.Count; i++) {
				numbersleft[i] = k;
				k++;
			}
			//return
			int[] sort = new int[chosen_staff.Count];

			// для факториала
			int fact_length;
			int temp_length = chosen_staff.Count - 1; // 3!

			// диапазон поиска, инициируем [0..23]
			int[] range = new int[2];
			range[0] = 0;
			range[1] = Model.math_factorial(chosen_staff.Count)-1; //

			//для записи следующего значения
			int counter;
			for (int i = 0; i<chosen_staff.Count; i++){
				fact_length = Model.math_factorial(temp_length);

				int j = (number - range[0])/fact_length + 1;

				int needed = -1;
				int icounter = 0;
				while (icounter != j){
					needed++;
					if(numbersleft[needed]!=0) icounter++;
				}

				sort[i] =numbersleft[needed];
				numbersleft[needed]=0;


				if (number - range[0] > 0)
					range[0] = (number /fact_length )* fact_length;

				range[1] = range[0] + fact_length;
				temp_length--;
			}
		/*	    File output = new File ("/resources/OUTPUT");
		        FileWriter writer = new FileWriter(output);
			for(int i=0; i< length; i++) {
				Console.Write(sort[i] + " ");
				//  writer.write(sort[i] + " ");
			}
			// writer.write("\n"); */

			List<string> output = new List<string> ();
			for (int i = 0; i < sort.Length; i++) {
				output.Add (chosen_staff [sort [i]-1]);
				Console.Write (output [i] + " ");
			}
			Console.WriteLine ();
			return output;
			


		}
		public static void get_chain_bystartfinish  (int length, int start, int finish){


			// инициализируем диапазон поиска и факториал
			int temp_length = length - 1;
			int fact_length = Model.math_factorial(temp_length);

			int[] range = new int[2];
			range[0] = 0;
			range[1] = length - 1;

			//массив флажков для проверки посещения
			bool[] visited = new bool[length];
			visited[start-1] = true;
			// visited[finish-1] = true;

			// массив с номерами подходящих нам перестановок
			List<int> chain = new List<int>();



			//порядковое по возрастанию из непосещенных
			int count_visited = start;
			range[0] += (count_visited - 1)*fact_length;
			range[1] = count_visited * fact_length - 1;

			//вспомогательная нижняя граница
			int range_zero = range[0];

			temp_length--;
			fact_length = Model.math_factorial(temp_length);


			for (int i=range[0]; i< range[1]; i++){
				temp_length = length - 2;

				bool incorrect = false;
				for (int j = 1; j<visited.Length; j++) {


					if (!incorrect) {

						fact_length = Model.math_factorial(temp_length);

						// cur задает порядковый номер свободного элемента в массиве, который должен быть заполнен
						// а pos указывает номер, уже с учетом посещенных (не порядковый)
						int cur = (i - range_zero) / fact_length;

						int pos = 0;
						while(visited[pos]) pos++;

						while (cur != 0) {
							pos++;
							if(visited[pos]) while(visited[pos]) pos++;
							cur--;
						}

						if (pos != (finish - 1) && j < (visited.Length - 1)) visited[pos] = true;
						else
							if (pos == (finish - 1) &&  j < (visited.Length - 1)) incorrect = true;

						if (j == visited.Length-2 && !incorrect){
							chain.Add(i);
							incorrect = true;
						}

						if (fact_length != 1) range_zero = (i /fact_length )* fact_length;
						temp_length--;
					}

				}
				visited = new bool[length];
				visited[start-1] = true;
				// visited[finish-1] = true;
				range_zero = range[0];
			}


			/*for (int i = 0; i< chain.; i++)
				Console.WriteLine(chain.get(i));
			//   System.out.println("\n" + range[1]);*/
		}
		/// <summary>
		/// Методы по созданию двоичного числа из 10чного
		/// </summary>
		/// <param name="temp">Temp.</param>
		//получает обратную запись двоичного числа из дсятичного
		public static int perevod(int temp)
		{
			int temp1 = 0;
			List<int> s = new List<int>();
			while(temp>0)
			{
				temp1 = temp % 2;
				temp = temp / 2;
				s.Add(temp1);
			}
			return obrat(s);
		}
		public static int obrat(List<int> norm)
		{
			int[] s= new int[norm.Count];
			for (int i = norm.Count-1; i >=0 ; i--)
			{
				s[norm.Count-1-i] = norm[i];
			}
			foreach (int k in s)
				Console.Write (k.ToString());
			Console.WriteLine ();
			return Convert.ToInt32(string.Join<int>("",s));
		}
		/// <summary>
		/// Комбинаторика и факториал
		/// </summary>
		/// <returns>The nk.</returns>
		/// <param name="n">N.</param>
		/// <param name="k">K.</param>
		//C_nk
		public static int C_nk (int n, int k){
			return Model.math_factorial (n) / (Model.math_factorial (k) * Model.math_factorial (n - k));;
		}
		// факториал от n
		public static int math_factorial(int n){

			int fc = 1;
			if (n>1) {
				while (n!=0) {
					fc*=n;
					n--;
				}}

			return fc;
		}

		// (число элементов, порядковый номер - выборка) 
		public static List<string> generate_selection(int num, List<string> staff){
			List<string> output = new List<string> ();
			int binary_num = Model.perevod (num);
			int i = 0;
			while (binary_num != 0) {
				if (binary_num % 10 == 1)
					output.Add (staff [i]);
				i++;
				binary_num /= 10;
			}
		   /* Для вывода выборки на консоль	
		    * foreach (string s in output)
				Console.Write (s + " ");  */
			return output;
		}
	}
}

