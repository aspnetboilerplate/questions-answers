using QuestionsAnswers.Debugging;

namespace QuestionsAnswers
{
    public class QuestionsAnswersConsts
    {
        public const string LocalizationSourceName = "QuestionsAnswers";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "b40d4f37a3054f4681dc11f5dedd1ace";
    }
}
