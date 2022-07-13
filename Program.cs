namespace Generic Lists
{
	public interface List<T>
	{
		public void add(T element);
		public void replace(T element, int position);
		public void remove(int position);
		public int find(T element);
		public void print();
	}


	public class ArrayList<T> : List<T>
	{
		private T[] arr;
		private int DEFAULT_ARRAYLIST_SIZE = 10;
		private int size;
		private int max_len;
		public ArrayList()
		{
			size = 0;
			arr = new T[DEFAULT_ARRAYLIST_SIZE];
			max_len = DEFAULT_ARRAYLIST_SIZE;
		}
		public ArrayList(int n)
		{
			size = 0;
			arr = new T[n];
			max_len = n;
		}

		public void add(T element)
		{
			if (size < max_len)
			{
				arr[size] = element;
				size++;
			}
			else
			{
				max_len = 2 * max_len;
				T[] tmp = new T[max_len];
				for (int i = 0; i < size; ++i)
				{
					tmp[i] = arr[i];
				}
				tmp[size] = element;
				size++;
				arr = tmp;
			}
		}

		public void replace(T element, int position)
		{
			if (position >= 0 && position < max_len)
			{
				arr[position] = element;
			}
			else
			{
				Console.WriteLine("The position doesn't fit the size");
			}
		}

		public void remove(int position)
		{
			if (position >= 0 && position < size)
			{
				T[] tmp = new T[max_len];
				for (int i = 0; i < size; ++i)
				{
					if (i < position)
					{
						tmp[i] = arr[i];
					}
					else if (i == position)
					{
						continue;
					}
					else
					{
						tmp[--i] = arr[i];
					}
					arr = tmp;
					size--;
				}
			}
			else
			{
				Console.WriteLine("The position doesn't fit the size");
			}
		}

		public int find(T element)
		{
			for (int i = 0; i < size; ++i)
			{
				if (arr[i].Equals(element))
				{
					return i;
				}
			}
			return -1;
		}
		public void print()
		{
			for (int i = 0; i < size; ++i)
			{
				Console.WriteLine(arr[i] + " ");
			}
			Console.WriteLine();
		}
	}


	public class LinkedList<T> : List<T>
	{
		private class Node<Y>
		{
			public Node<Y> previous;
			public Node<Y> next;
			public Y value;
		}
		private Node<T> head;
		private Node<T> tail;
		private int size;
		public LinkedList()
		{
			head = null;
			tail = null;
		}

		public void add(T element)
		{
			Node<T> node = new Node<T>();
			node.value = element;
			if (size == 0)
			{
				head = node;
				node.previous = null;
				node.next = null;
			}
			else
			{
				tail.next = node;
				node.previous = tail;
				node.next = null;
			}
			tail = node;
			size++;
		}

		public void replace(T element, int position)
		{
			if (position >= 0 && position < size)
			{
				Node<T> node = new Node<T>();
				node.value = element;
				int index = 0;
				for (Node<T> i = head; i != null; i = i.next)
				{
					if (position == 0)
					{
						i.previous = node;
						node.next = i;
						node.previous = null;
						head = node;
						break;
					}
					else if (position == size - 1)
					{
						i.next = node;
						node.previous = i;
						node.next = null;
						tail = node;
						break;
					}
					else if (index == position)
					{
						node.previous.next = node;
						node.previous = i.previous;
						node.next = i;
						i.previous = node;
						break;
					}
					++index;
				}
				size++;
			}
			else
			{
				Console.WriteLine("The position doesn't fit the size");
			}
		}

		public void remove(int position)
		{
			if (position >= 0 && position < size)
			{
				int index = 0;
				for (Node<T> i = head; i != null; i = i.next)
				{
					if (position == 0 && position == size - 1)
					{
						tail = null;
						head = null;
						break;
					}
					else if (position == 0)
					{
						i.next.previous = null;
						head = i.next;
						break;
					}
					else if (position == this.size - 1)
					{
						i.previous.next = null;
						tail = i.previous;
						break;
					}
					else if (index == position)
					{
						i.previous.next = i.next;
						i.next.previous = i.previous;
						break;
					}
					++index;
				}
				size++;
			}
			else
			{
				Console.WriteLine("The position doesn't fit the size");
			}
		}

		public int find(T element)
		{
			int index = 0;
			for (Node<T> i = head; i != null; i = i.next)
			{
				if (i.value.Equals(element))
				{
					return index;
				}
				++index;
			}
			return -1;
		}

		public void print()
		{
			for (Node<T> i = this.head; i != null; i = i.next)
			{
				Console.WriteLine(i.value + " ");
			}
			Console.WriteLine();
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			ArrayList<int> arr = new ArrayList<int>();
			arr.add(1);
			arr.add(9);
			arr.add(8);
			arr.add(7);
			arr.replace(100, 2);
			arr.remove(1);
			arr.print();
			arr.remove(10);
			Console.WriteLine(arr.find(10));
			LinkedList<int> li_arr = new LinkedList<int>();
			li_arr.add(2);
			li_arr.add(1);
			li_arr.add(1);
			li_arr.add(1);
			li_arr.remove(7);
			li_arr.print();
			li_arr.replace(100, 10);
			Console.WriteLine(li_arr.find(2));
		}
	}
}