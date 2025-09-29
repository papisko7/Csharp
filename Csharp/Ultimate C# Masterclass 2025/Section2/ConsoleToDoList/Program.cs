string userChoice = string.Empty;
int todoCounter = 1;
List<string> todoList = new List<string>();

do
{
	Console.WriteLine("[S]ee all TODOs");
	Console.WriteLine("[A]dd a TODO");
	Console.WriteLine("[R]emove a TODO");
	Console.WriteLine("[E]xit");

	userChoice = Console.ReadLine()?.ToUpper() ?? "E";

	switch (userChoice)
	{
		case "A":
			bool isValid = false;
			string description = string.Empty;

			if (todoList == null)
			{
				todoList = new List<string>();
			}

			while (!isValid)
			{
				Console.WriteLine("Enter a TODO description: ");
				description = Console.ReadLine() ?? string.Empty;

				if (string.IsNullOrEmpty(description))
				{
					Console.WriteLine("The description cannot be empty. No TODO is added.");
					continue;
				}

				if (todoList.Contains(description))
				{
					Console.WriteLine("The description must be unique. No TODO is added.");
					continue;
				}
				isValid = true;
			}
			todoList.Add(description);
			Console.WriteLine($"TODO successfuly added: {description}");
			break;

		case "R":
			if (todoList == null || todoList.Count == 0)
			{
				todoList = new List<string>();
				Console.WriteLine("There are no TODOs to remove.");
				break;
			}

			else
			{
				bool isValidRemove = false;
				int index = 0;

				while (!isValidRemove)
				{
					Console.WriteLine("Select the index of the TODO you want to remove:");
					index = int.Parse(Console.ReadLine() ?? "0");

					if (string.IsNullOrWhiteSpace(index.ToString()))
					{
						Console.WriteLine("Selected index cannot be empty. No TODO is removed.");
						continue;
					}

					if (index < 1 || index > todoList.Count)
					{
						Console.WriteLine("The given index is not valid. No TODO is removed.");
						continue;
					}
				}
				todoList.RemoveAt(index);	
			}
			break;

		case "S":
			if (todoList == null || todoList.Count == 0)
			{
				todoList = new List<string>();
				Console.WriteLine("No TODOs found.");
			}

			else
			{
				Console.WriteLine("Here are your TODOs:");
				foreach (string todo in todoList)
				{
					Console.WriteLine($"{todoCounter++}. {todo}");
				}
			}
			break;

		case "E":
			Console.WriteLine("Exiting the program. Goodbye!");
			break;

		default:
			Console.WriteLine("Incorrect option, please try again.");
			break;
	}
	if(userChoice != "E")
	{
		Console.WriteLine("What do you want to do?");
	}
} while (userChoice != "E");