using System;
public static class Errors
{
    public static void DoubleText()
    {
        Console.WriteLine(ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyCannotEnterEmptyCharacters));
    }
    public static void DoubleEmpty()
    {
        Console.WriteLine(ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyEmpty));
    }
    public static void Range()
    {
        Console.WriteLine(ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyNotThisRange));
    }
    public static void RemoveProduct()
    {
        Console.WriteLine(ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeyFailedRemoveProduct));
    }
}