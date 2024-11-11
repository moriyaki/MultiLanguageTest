using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MultiLanguageTest
{
    public class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// 挨拶をするボタンのテキスト
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static")]
        public string Greetings
        {
            get => ResourceService.GetString("Greetings");
        }

        /// <summary>
        /// 日本語にする
        /// </summary>
        public RelayCommand ToJapanese { get; set; }

        /// <summary>
        /// 英語にする
        /// </summary>
        public RelayCommand ToEnglish { get; set; }

        /// <summary>
        /// ロシア語にする
        /// </summary>
        public RelayCommand ToRussian { get; set; }

        public MainWindowViewModel()
        {
            ToEnglish = new RelayCommand(() => ChangeGreetingsCulture("en"));
            ToJapanese = new RelayCommand(() => ChangeGreetingsCulture("ja"));
            ToRussian = new RelayCommand(() => ChangeGreetingsCulture("ru"));
            ResourceService.ChangeCulture("en");
        }

        /// <summary>
        /// 挨拶のためのカルチャーコードを変更します。
        /// </summary>
        /// <param name="cultureCode">カルチャーコード</param>
        private void ChangeGreetingsCulture(string cultureCode)
        {
            ResourceService.ChangeCulture(cultureCode);
            OnPropertyChanged(nameof(Greetings));
        }
    }
}