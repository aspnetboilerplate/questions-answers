using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsAnswers.Configuration
{
    public class MySettingProvider : SettingProvider
    {
        public const string QuestionsDefaultPageSize = "QuestionsDefaultPageSize";
        public const string QuestionsDefaultSorting = "QuestionsDefaultSorting";
        public const string AllowMultipleVote = "AllowMultipleVote";

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                   {
                       new SettingDefinition(QuestionsDefaultPageSize, "10"),
                       new SettingDefinition(QuestionsDefaultSorting, "CreationTime DESC"),
                       new SettingDefinition(AllowMultipleVote, "true")
                   };
        }
    }
}
