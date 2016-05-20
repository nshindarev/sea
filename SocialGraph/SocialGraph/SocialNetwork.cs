using System;

namespace SocialGraph
{
	public class SocialNetwork
	{
		public SocialNetwork ()
		{
		}
	}
}

/*public class Bayesian_network {
	public File relationships_txt;
	public File users_txt;

	public ArrayList<Knowledge_fragment> network;
	public Bayesian_network(String users, String relations ){
		this.relationships_txt = new File (relations);
		this.users_txt = new File(users);
	}
}
// методы, упрощающие работу с фрагментами знаний
// методы, переходящие к локальному выводу/ к глобальному
/* нужно как-то учитывать связи, которые возникают между сотрудниками из разных отделов. Например, создать
     * список самых важных связей среди сотрудников из разных отделов и  */

// TODO: Алгоритм Брона-Кербоша. (?: клика -> это контролируемая зона/ отдел)
/* ПРОЦЕДУРА extend (candidates, not):
        ПОКА candidates НЕ пусто И not НЕ содержит вершины, СОЕДИНЕННОЙ СО ВСЕМИ вершинами из candidates,
        ВЫПОЛНЯТЬ:
        1 Выбираем вершину v из candidates и добавляем её в compsub
        2 Формируем new_candidates и new_not, удаляя из candidates и not вершины, не СОЕДИНЕННЫЕ с v
        3 ЕСЛИ new_candidates и new_not пусты
        4 ТО compsub – клика
        5 ИНАЧЕ рекурсивно вызываем extend (new_candidates, new_not)
        6 Удаляем v из compsub и candidates, и помещаем в not*/