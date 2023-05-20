using System.Collections.Generic;

namespace CO_Driver.Libraries
{
    public static class Utilities
    {
        public static void AddToListIfNotExists(List<string> list, string item)
        {
            if (!list.Contains(item))
                list.Add(item);
        }

        public static void AddTranslatedStringIfNotExists(List<string> list, string description, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translations)
        {
            var translatedString = Translate.TranslateString(description, session, translations);
            if (!string.IsNullOrEmpty(translatedString))
            {
                AddToListIfNotExists(list, translatedString);
            }
        }
    }
}
