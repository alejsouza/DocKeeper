using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Ranallo.DocKeeper.Localization
{
    public static class DocKeeperLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DocKeeperConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DocKeeperLocalizationConfigurer).GetAssembly(),
                        "Ranallo.DocKeeper.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
