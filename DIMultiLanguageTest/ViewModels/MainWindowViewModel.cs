using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DIMultiLanguageTest.Services;

namespace DIMultiLanguageTest.ViewModels
{
    public interface IMainWindowViewModel;

    public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        /// <summary>
        /// 挨拶をするボタンのテキスト
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
        public string Greetings => ResourceService.GetString("Greetings");

        /// <summary>
        /// 挨拶のためのカルチャーコードを変更します。
        /// </summary>
        /// <param name="cultureCode">カルチャーコード</param>
        private void ChangeGreetingsCulture(string cultureCode)
        {
            ResourceService.ChangeCulture(cultureCode);
            OnPropertyChanged(nameof(Greetings));
        }

        [RelayCommand]
        private void ToEnglish() => ChangeGreetingsCulture("en");

        [RelayCommand]
        private void ToJapanese() => ChangeGreetingsCulture("ja");

        [RelayCommand]
        private void ToRussian() => ChangeGreetingsCulture("ru");
    }
}
