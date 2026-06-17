using DiceRollGame.Application;
using DiceRollGame.Model;
using DiceRollGame.Services;
using DiceRollGame.Ui;

GameSettings gameSettings = new GameSettings();

IDice dice = new Dice();
IConsoleReader reader = new ConsoleReader();
IConsoleWriter writer = new ConsoleWriter();

var diceRollGame = new App(gameSettings, dice,
	reader, writer);
diceRollGame.Start();