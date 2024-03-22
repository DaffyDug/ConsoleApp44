using System;
using System.Collections.Generic;
public class CurrentDictionary : ICommand
{
    public static readonly CurrentDictionary Instance;
    public Dictionary<Keys, string> keyValuePairs = new Dictionary<Keys, string>();
    public string Description => ProjectManager.projectManager._TEXT.GetDictionaryValue(Keys.KeySettingsForTranslateProgramm);
    private CurrentDictionary()
    { }
    static CurrentDictionary()
    {
        Instance = new CurrentDictionary();
    }
    public string GetDictionaryValue(Keys keys)
    {
        return keyValuePairs[keys];
    }
    public void SetLeocale(string language)
    {
        keyValuePairs = Locales.GetLocale(language);
    }
    public void Run()
    {
        Array collection = Enum.GetValues(typeof(Language));
        MenuLanguage();
        string language;
        if (InputHelper.Input("выберите язык: \n", 1, collection.Length, out int inputvalue))
        {
            if (inputvalue == 1)
            {
                language = "RU";
                SetLeocale(language);
            }
            else if (inputvalue == 2)
            {
                language = "EN";
                SetLeocale(language);
            }
        }
    }
    public void MenuLanguage()
    {
        Array collection = Enum.GetValues(typeof(Language));
        System.Collections.IList list = collection;
        for (int i = 0; i < list.Count; i++)
        {
            object item = list[i];
            Console.WriteLine($"{i + 1}--{item}");
        }
    }
}

public static class Locales
{
    private static Dictionary<Keys, string> Locales_RU = new Dictionary<Keys, string>()
    {
        #region методы
                {Keys.KeyAddProject,"Добавить проект" },
                {Keys.KeyRemoveProject,"Удалить проект" },
                {Keys.KeyPrintInfoProject,"Информация о проектах" },
                {Keys.KeySettingsForTranslateProgramm,"настройки для переводв программы" },
                {Keys.KeyAddChallenge,"добавить задачу:" },
                {Keys.KeyRemoveChallenge,"удалить задачу: " },
        #endregion
        #region ввод данных
                {Keys.KeyNameProject,"имя проекта: " },

                {Keys.KeyNameChallanger,"имя задачи:" },
                {Keys.KeyDescriptionChallanger,"цель задачи: " },

                {Keys.KeyWhatProjectWhantRemove,"\nкакой проект вы хотите удалить: " },
                {Keys.KeyWhatChallangerWhantRemove,"какую цель вы хотите удалить: " },
                {Keys.KeyWhatProjectWhantCheckInformation,"о каком проекте хотите получить информацию: \n" },
                {Keys.KeyWhatWillDo,"выберите что вы будете делать: " },
        #endregion
        #region завершенные выводы
                {Keys.KeyAddProjectCompleted,"проект добавлен\n" },
                {Keys.KeyRemoveProjectCompleted,"\nпроект удален\n" },
                {Keys.KeyTimeAddProject,"время добавление проекта: " },
                {Keys.KeyGoalChallenge, "цель задачи: " },
        #endregion
        #region ошибки
                {Keys.KeyCannotEnterEmptyCharacters,"нельзя воодить пустые символы" },
                {Keys.KeyEmpty,"пусто!" },
                {Keys.KeyNotThisRange,"нету такого диапозона!" },
                {Keys.KeyFailedRemoveProduct,"не удалось удалить продукт" }
        #endregion
    };
    private static Dictionary<Keys, string> Locales_EN = new Dictionary<Keys, string>()
    {
        #region методы
                {Keys.KeyAddProject,"Add a product" },
                {Keys.KeyRemoveProject,"Remove a product" },
                {Keys.KeyPrintInfoProject,"Information a products" },
                {Keys.KeySettingsForTranslateProgramm,"Settings For Translate Programm" },
                {Keys.KeyAddChallenge,"Add Challenge: " },
                {Keys.KeyRemoveChallenge,"Remove Challenge: " },
                #endregion
        #region ввод данных
                {Keys.KeyNameProject,"Name Project: " },

                {Keys.KeyNameChallanger,"Name Challanger: " },
                {Keys.KeyDescriptionChallanger,"Description Challanger: " },

                {Keys.KeyWhatProjectWhantRemove,"\nWhat Project Whant Remove: " },
                {Keys.KeyWhatChallangerWhantRemove,"What Challeng Whant Remove: " },
                {Keys.KeyWhatProjectWhantCheckInformation,"\nWhat Product Whant Check Information:\n " },
                {Keys.KeyWhatWillDo,"What Will Do: " },
                #endregion
        #region завершенные выводы
                {Keys.KeyAddProjectCompleted,"\nAdd Project Completed\n" },
                {Keys.KeyRemoveProjectCompleted,"\nARemove Project Completed\n" },
                {Keys.KeyGoalChallenge, "Goal Challenge: " },
                #endregion
        #region ошибки
                {Keys.KeyCannotEnterEmptyCharacters,"Cannot Enter Empty Characters" },
                {Keys.KeyEmpty,"Empty!" },
                {Keys.KeyNotThisRange,"Not This Range!" },
                {Keys.KeyFailedRemoveProduct,"Failed Remove Product" }
                #endregion
    };
    public static Dictionary<Keys, string> GetLocale(string locale)
    {
        if (locale == "RU")
        {
            return Locales_RU;
        }
        else
        {
            return Locales_EN;
        }
    }
};
public enum Language
{
    RU = 1,
    En
}