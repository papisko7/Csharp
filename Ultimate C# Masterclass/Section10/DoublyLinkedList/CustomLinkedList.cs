using System.Collections;

namespace DoublyLinkedList;

public class CustomLinkedList<T> : ILinkedList<T>
{
	public class Node(T? value)
	{
		public Node? Previous { get; set; }

		public Node? Next { get; set; }

		public T? Value { get; } = value;
	}

	private Node? _head;
	private Node? _tail;

	public int Count { get; private set; }

	public bool IsReadOnly => false;

	public void AddToFront(T? item)
	{
		var newNode = new Node(item);

		if (_head != null)
		{
			newNode.Next = _head;
			_head.Previous = newNode;
		}

		else
		{
			_tail = newNode;
		}

		_head = newNode;
		Count++;
	}

	public void AddToEnd(T? item)
	{
		var newNode = new Node(item);

		if (_tail != null)
		{
			newNode.Previous = _tail;
			_tail.Next = newNode;
		}

		else
		{
			_head = newNode;
		}

		_tail = newNode;
		Count++;
	}

	public void Add(T? item)
	{
		AddToEnd(item);
	}

	public bool Contains(T? item)
	{
		var currentNode = _head;

		while (currentNode != null)
		{
			if (Equals(currentNode.Value, item))
			{
				return true;
			}

			currentNode = currentNode.Next;
		}

		return false;
	}

	public void Clear()
	{
		_head = null;
		_tail = null;
		Count = 0;
	}

	public void CopyTo(T?[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException(nameof(array), "Array cannot be null.");
		}

		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index cannot be negative.");
		}

		if (array.Length - arrayIndex < Count)
		{
			throw new ArgumentException("The destination array does not have enough space.");
		}

		var currentNode = _head;
		while (currentNode != null)
		{
			array[arrayIndex] = currentNode.Value;
			arrayIndex++;
			currentNode = currentNode.Next;
		}
	}

	public bool Remove(T? item)
	{
		var currentNode = _head;

		while (currentNode != null)
		{
			if (EqualityComparer<T?>.Default.Equals(currentNode.Value, item))
			{
				RemoveNode(currentNode);
				return true;
			}

			currentNode = currentNode.Next;
		}

		return false;
	}

	private void RemoveNode(Node node)
	{
		if (node == _head)
		{
			_head = node.Next;

			if (_head != null)
			{
				_head.Previous = null;
			}
			else
			{
				_tail = null;
			}
		}
		else if (node == _tail)
		{
			_tail = node.Previous;

			if (_tail != null)
			{
				_tail.Next = null;
			}
		}
		else
		{
			node.Previous!.Next = node.Next;
			node.Next!.Previous = node.Previous;
		}

		Count--;
	}

	public IEnumerator<T?> GetEnumerator()
	{
		var currentNode = _head;

		while (currentNode != null)
		{
			yield return currentNode.Value;
			currentNode = currentNode.Next;
		}
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		var currentNode = _head;

		while (currentNode != null)
		{
			yield return currentNode.Value!;
			currentNode = currentNode.Next;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}