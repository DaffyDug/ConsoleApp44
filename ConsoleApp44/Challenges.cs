using System;
using System.Collections.Generic;

public class ChallengesManager
{
    private List<Challenges> challenges = new();
    public static readonly ChallengesManager challengesManager;
    private ChallengesManager()
    { }
    static ChallengesManager()
    {
        challengesManager = new ChallengesManager();
    }
    public void AddChallanger(Challenges challenges)
    {
        this.challenges.Add(challenges);
    }
    public void RemoveChallanger(int index)
    {
        challenges.RemoveAt(index);
    }
    public void PrintInfoChallanger()
    {
        var Pm = ProjectManager.projectManager;
        for (int i = 0; i < challenges.Count; i++)
        {
            Challenges item = challenges[i];
            Console.WriteLine($"{Pm._TEXT.GetDictionaryValue(Keys.KeyNameProject)} {item.Name} \n " +
                $"{Pm._TEXT.GetDictionaryValue(Keys.KeyGoalChallenge)}: {item.Description}\n " +
                $"{Pm._TEXT.GetDictionaryValue(Keys.KeyTimeAddProject)} {item.Time}");
        }
    }
    public int GetCountList()
    {
        return challenges.Count;
    }
    public List<Challenges> GetChallenges()
    {
        return challenges;
    }
}

public class Challenges
{
    public string Name { get; }
    public string Description { get; }
    public DateTime Time { get; }
    public Challenges(string name, string description, DateTime dateTime)
    {
        Name = name;
        Description = description;
        Time = dateTime;
    }

}
class AddChallanger : ICommand
{
    public string Description => throw new NotImplementedException();

    public void Run()
    {
        var Pm = ProjectManager.projectManager;
        Console.WriteLine(Pm._TEXT.GetDictionaryValue(Keys.KeyNameChallanger));
        string Name = Console.ReadLine();
        if (Name.Length != 0)
        {
            Console.WriteLine(Pm._TEXT.GetDictionaryValue(Keys.KeyDescriptionChallanger));
            string Description = Console.ReadLine();
            if (Description.Length != 0)
            {
                Challenges challenges = new(Name, Description, DateTime.Now);
                ChallengesManager.challengesManager.AddChallanger(challenges);
            }
            else
            {
                Errors.DoubleEmpty();
            }
        }
        else
        {
            Errors.DoubleEmpty();
        }
    }
}
class RemoveChallanger : ICommand
{
    public string Description => ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyRemoveChallenge);

    public void Run()
    {
        var Pm = ProjectManager.projectManager;
        if (InputHelper.Input(Pm._TEXT.GetDictionaryValue(Keys.KeyWhatChallangerWhantRemove), 1, Pm.GetCountList(), out int inputvalue))
        {
            Pm.GetProjects(inputvalue - 1);
        }
    }
}
class PrintInfoChallange : ICommand
{
    public string Description => throw new NotImplementedException();

    public void Run()
    {
        if (ProjectManager.projectManager.GetCountList() > 0)
        {
            ProjectManager.projectManager.PrintInfoProject();
        }
        else
        {
            Errors.DoubleEmpty();
        }
    }
}