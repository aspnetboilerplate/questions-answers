using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace QuestionsAnswers.Localization
{
    public static class QuestionsAnswersLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(QuestionsAnswersConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(QuestionsAnswersLocalizationConfigurer).GetAssembly(),
                        "QuestionsAnswers.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
