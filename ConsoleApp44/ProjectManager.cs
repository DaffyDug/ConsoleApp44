using System;
using System.Collections.Generic;

public class ProjectManager
{
    private List<Projects> Projects = new List<Projects>();
    public static readonly ProjectManager projectManager;
    public CurrentDictionary _TEXT = CurrentDictionary.Instance;
    private ProjectManager()
    { }
    static ProjectManager()
    {
        projectManager = new ProjectManager();
    }
    public void AddProject(Projects projects)
    {
        Projects.Add(projects);
    }
    public void RemoveProject(int index)
    {
        Projects.RemoveAt(index);
    }
    public void PrintInfoProject()
    {
        for (int i = 0; i < Projects.Count; i++)
        {
            Projects item = Projects[i];
            Console.WriteLine($"{i + 1}--{item.Name}");
        }
    }
    public int GetCountList()
    {
        return Projects.Count;
    }
    public Projects GetProjects(int index)
    {
        return Projects[index];
    }
}

class AddProject : ICommand
{
    public string Description => ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyAddProject);

    public void Run()
    {
        Console.WriteLine(ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyNameProject));
        string NameProject = Console.ReadLine();
        if (NameProject.Length != 0)
        {
            Projects projects = new Projects(NameProject, DateTime.Now);
            ProjectManager.projectManager.AddProject(projects);
            Console.WriteLine(ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyAddProjectCompleted));
        }
        else
        {
            Errors.DoubleEmpty();
        }
    }
}
class RemoveProject : ICommand
{
    public string Description => ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyRemoveProject);

    public void Run()
    {
        ProjectManager.projectManager.PrintInfoProject();
        var Pr = ProjectManager.projectManager;
        if (InputHelper.Input(Pr._TEXT.GetDictionaryValue(Keys.KeyWhatProjectWhantRemove), 1, ProjectManager.projectManager.GetCountList(), out int inputvalue))
        {
            ProjectManager.projectManager.RemoveProject(inputvalue - 1);
            Console.WriteLine(ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyRemoveProjectCompleted));
        }
    }
}
class PrintInfoProject : ICommand
{
    public string Description => ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyPrintInfoProject);
    public void Run()
    {
        var Pm = ProjectManager.projectManager;
        ProjectManager.projectManager.PrintInfoProject();
        if (InputHelper.Input(Pm._TEXT.GetDictionaryValue(Keys.KeyWhatProjectWhantCheckInformation), 1, Pm.GetCountList(), out int inputvalue))
        {
            #region вывод имени продукта и даты добавления 
            Console.WriteLine($"{Pm._TEXT.GetDictionaryValue(Keys.KeyNameProject)} {Pm.GetProjects(inputvalue - 1).Name}" +
                $"\n{Pm._TEXT.GetDictionaryValue(Keys.KeyTimeAddProject)} {Pm.GetProjects(inputvalue - 1).Time}");
            #endregion
        }
    }
}
