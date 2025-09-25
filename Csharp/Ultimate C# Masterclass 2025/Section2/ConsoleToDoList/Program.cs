string userChoice = string.Empty;
HashSet<string> todoList = new HashSet<string>();

while (userChoice != "E")
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
				todoList = new HashSet<string>();
			}

			while (!isValid)
			{
				Console.WriteLine("Enter a TODO description: ");
				description = Console.ReadLine() ?? string.Empty;

				if (string.IsNullOrEmpty(description) || description.Equals(" "))
				{
					Console.WriteLine("Description cannot be empty. Please try again.");
					break;
				}

				if (todoList.Contains(description))
				{
					Console.WriteLine("The description must be unique. No TODO is added.");

				}
			}

			todoList.Add(description);

			Console.WriteLine("TODO successfuly added! :)");
			Console.WriteLine("What do you want to do?");
			break;

		case "R":
			if(todoList == null || todoList.Count == 0 )
			{
				todoList = new HashSet<string>();

				Console.WriteLine("There are no TODOs to remove.");
				break;
			}else 
			{
				todoList.Remove(Console.ReadLine() ?? string.Empty);
			}
				
			break;

		case "S":
			if(todoList == null || todoList.Count == 0)
			{
				todoList = new HashSet<string>();

				Console.WriteLine("No TODOs found.");
				break;
			}else
			{
				foreach (string todo in todoList)
				{
					int todoCounter = 0;
					Console.WriteLine($"{todoCounter}.	{todo}");
				}
				Console.WriteLine("What do you want to do?");
			}
			break;

		default:
			Console.WriteLine("Incorrect option, please try again.");
			continue;
	}
}
