using System;
using System.Collections.Generic;

class Program
{


    public static List<ICommand> commands = new List<ICommand>
        {
            new AddProject(),
            new RemoveProject(),
            new PrintInfoProject()
        };
    static void Main(string[] args)
    {
        CurrentDictionary.Instance.SetLeocale("RU");
        var Pm = ProjectManager.projectManager;
        while (true)
        {
            StartMenu(commands);
            if (InputHelper.Input(Pm._TEXT.GetDictionaryValue(Keys.KeyWhatWillDo), 1, commands.Count, out int inputvalue))
            {
                commands[inputvalue - 1].Run();
            }
            if (ChallengesManager.challengesManager.GetCountList() > 0)
            {
                commands.Add(new AddChallanger());
                commands.Add(new RemoveChallanger());
                commands.Add(new PrintInfoChallange());
            }
        }
    }
    public static void StartMenu(List<ICommand> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            ICommand item = commands[i];
            Console.WriteLine($"{i + 1}--{item.Description}");
        }
    }
}
