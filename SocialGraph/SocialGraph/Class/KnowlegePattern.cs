using System;

namespace SocialGraph
{
	public class KnowlegePattern
	{
		public KnowlegePattern (List<string> staff)
		{
			
		}
	}
}

/*
	// размер данного фрагмента знаний
	private int size;
	public int get_size(){
		return this.size;
	}

	// таблицы с вероятностями
	public double[][] relations;
	public double[][] single_user_probability;

	//TODO: добавить чтение таблиц вероятностей из txt-файлов
	//TODO: для этого выяснить где их хранить
	public Knowledge_fragment (int size){
		this.size = size;
	}

	//TODO: метод генерирует все цепочки, использ. статич. методы из Main
	public void generate_all_propositions (){

	}
	//TODO: несколько перегрузок
	/*
	   * --- все цепочки от одного пользователя, вероятность успешности >= 1%
 	   * --- все цепочки от одного пользователя к другому, вероятность >=1%
 	   * --- наиболее "опасная" цепочка, ведущая от пользователя к пользователю
 	   * --- ?: наиболее опасная цепочка, ведущая к документ
   
	public void get_chain (){

	}
*/