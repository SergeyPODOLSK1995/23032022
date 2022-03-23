using System;
using System.Collections;
using System.Linq;
namespace our_prog
{
	public class place_to_visit
	{
		public string name="";
		public int priority=0;
		public double time=0;
		public place_to_visit(string c_name, int c_priority, double c_time)
		{
			name=c_name;
			priority=c_priority;
			time=c_time;
		}
		//public class ReverserClass : IComparer
   		//{
      //Call CaseInsensitiveComparer.Compare with the parameters reversed.
      		//int IComparer.Compare(Object x, Object y)
      		//{
          		//return ((new CaseInsensitiveComparer()).Compare(y, x));
      		//}
	}

	public class Program
	{
		public const int quality_of_places=20;
		public const double quality_of_time=32;//48 часов за 2 суток - 16 часов на сон
		public static void Main()
		{
			//Console.WriteLine("Hello");
			//public const int quality_of_places=20;
			//Использовал онлайн - компилятор, ввиду неболшьшого количества данных ввод организовал следующим образом
			place_to_visit[] My_place_to_visit_program=new place_to_visit[quality_of_places];
			My_place_to_visit_program[0] = new place_to_visit("Исаакиевский собор",10,5);
			My_place_to_visit_program[1] = new place_to_visit("Эрмитаж",11,8);
			My_place_to_visit_program[2] = new place_to_visit("Кунсткамера",4,3.5);
			My_place_to_visit_program[3] = new place_to_visit("Петропавловская крепость",7,10);
			My_place_to_visit_program[4] = new place_to_visit("Ленинградский зоопарк",15,9);
			My_place_to_visit_program[5] = new place_to_visit("Медный всадник",17,1);
			My_place_to_visit_program[6] = new place_to_visit("Казанский собор",3,4);
			My_place_to_visit_program[7] = new place_to_visit("Спас на Крови",9,2);
			My_place_to_visit_program[8] = new place_to_visit("Зимний дворец Петра I",12,7);
			My_place_to_visit_program[9] = new place_to_visit("Музей обороны и блокады Ленинграда",12,2);
			My_place_to_visit_program[10] = new place_to_visit("Русский музей",8,5);
			My_place_to_visit_program[11] = new place_to_visit("Навестить друзей",20,12);
			My_place_to_visit_program[12] = new place_to_visit("Музей восковых фигур",13,2);
			My_place_to_visit_program[13] = new place_to_visit("Литературно-мемориальный музей Ф.М. Достоевского",2,4);
			My_place_to_visit_program[14] = new place_to_visit("Екатерининский дворец",5,1.5);
			My_place_to_visit_program[15] = new place_to_visit("Петербургский музей кукол",14,1);
			My_place_to_visit_program[16] = new place_to_visit("Музей микроминиатюры «Русский Левша»",18,3);
			My_place_to_visit_program[17] = new place_to_visit("Всероссийский музей А.С. Пушкина и филиалы",1,6);
			My_place_to_visit_program[18] = new place_to_visit("Музей современного искусства Эрарта",16,7);
			My_place_to_visit_program[19] = new place_to_visit("Зоологический музей",6,5.5);
			
			//Array.Sort(My_place_to_visit_program, (IComparer)place_to_visit=>place_to_visit.priority);
			var Sorted_My_place_to_visit_program = My_place_to_visit_program.OrderByDescending(place_to_visit=>place_to_visit.priority);
			
			//foreach(var elem in Sorted_My_place_to_visit_program)
			//{
				//Console.WriteLine(elem.name);
			//}
			
			double free_time= quality_of_time;
			//Первый вариант - в отсортированном по важности массиве выписываем все дела, на которые у нас хватит времени
			Console.WriteLine("Первый вариант - в отсортированном по важности массиве выписываем все дела, на которые у нас хватит времени");
			foreach(var elem in Sorted_My_place_to_visit_program)
			{
				free_time-=elem.time;
				if(free_time<0)
					break;
				Console.WriteLine(elem.name+"   "+elem.time);	
			}
			
			
			//второй вариант - в отсортированном по важности массиве выявляем срез, на котором сумма очков важности максимальна, чтобы у нас хватило времени
			Console.WriteLine("второй вариант - в отсортированном по важности массиве выявляем срез, на котором сумма очков важности максимальна, чтобы у нас хватило времени");
			free_time= quality_of_time;
			int shift=0;
			int iter=0;
			place_to_visit[] Sorted_Array_My_place_to_visit_program = Sorted_My_place_to_visit_program.ToArray();
			int max_prior_scores=0;
			int scored_shift=0;
			while(shift<quality_of_places)
			{
				int prio_scores=0;
				free_time= quality_of_time;
				while((iter+shift<quality_of_places) && (free_time>=0))
				{
					place_to_visit pv = Sorted_Array_My_place_to_visit_program[iter+shift];
					free_time-=pv.time;
					//Console.WriteLine(pv.name+"  "+pv.time);
					prio_scores+=pv.priority;	
				}
				if(prio_scores>max_prior_scores)
				{
					max_prior_scores=prio_scores;
					scored_shift=shift;	
				}
				shift++;
			}
			
			free_time=quality_of_time;
			for(int i=scored_shift; i<quality_of_places; i++)
			{
				place_to_visit pv = Sorted_Array_My_place_to_visit_program[i];
				free_time-=pv.time;
				if(free_time<0)
					break;
				Console.WriteLine(pv.name+"   "+pv.time);	
			}
			//Два подхода к решению данной задачи
		Console.WriteLine("Два подхода к решению данной задачи");
		}
		
	}
}