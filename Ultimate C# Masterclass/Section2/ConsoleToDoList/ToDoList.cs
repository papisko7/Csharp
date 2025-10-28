string userChoice = string.Empty;
List<string> todoList = new List<string>();
string description = string.Empty;

do
{
	Console.WriteLine("\n[S]ee all TODOs");
	Console.WriteLine("[A]dd a TODO");
	Console.WriteLine("[R]emove a TODO");
	Console.WriteLine("[E]xit");

	userChoice = Console.ReadLine()?.ToUpper() ?? "E";

	switch (userChoice)
	{
		case "A":
			bool isValid = false;

			while (!isValid)
			{
				Console.Write("Enter a TODO description: ");
				description = Console.ReadLine()?.Trim() ?? string.Empty;

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
			Console.WriteLine($"TODO successfully added: {description}");
			break;

		case "R":
			if (todoList.Count == 0)
			{
				Console.WriteLine("There are no TODOs to remove.");
				break;
			}

			int indexToRemove = -1;
			bool isValidRemove = false;

			while (!isValidRemove)
			{
				Console.Write("Select the index of the TODO you want to remove: ");
				string indexInput = Console.ReadLine() ?? string.Empty;

				if (int.TryParse(indexInput, out indexToRemove))
				{
					if (indexToRemove >= 1 && indexToRemove <= todoList.Count)
					{
						isValidRemove = true;
					}
					else
					{
						Console.WriteLine($"The given index is not valid. Please enter a number between 1 and {todoList.Count}.");
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a valid number.");
				}
			}
			string removedDescription = todoList[indexToRemove - 1];

			todoList.RemoveAt(indexToRemove - 1);
			Console.WriteLine($"TODO removed: {removedDescription}");
			break;

		case "S":
			if (todoList.Count == 0)
			{
				Console.WriteLine("No TODOs found.");
			}
			else
			{
				Console.WriteLine("Here are your TODOs:");
				for (int i = 0; i < todoList.Count; i++)
				{
					Console.WriteLine($"{i + 1}. {todoList[i]}");
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

	if (userChoice != "E")
	{
		Console.WriteLine("\nPress Enter to continue...");
		Console.ReadLine();
	}
} while (userChoice != "E");