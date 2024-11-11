using System.Globalization;
using System.Resources;

namespace MultiLanguageTest
{
    public static class ResourceService
    {
        private static ResourceManager resourceManager = new("MultiLanguageTest.Resources.Resource", typeof(ResourceService).Assembly);

        /// <summary>
        /// 言語を変更します。
        /// </summary>
        /// <param name="cultureCode">変更するカルチャーコード</param>
        public static void ChangeCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            CultureInfo.CurrentUICulture = culture;
        }

        /// <summary>
        /// リソースファイルから名前をキーに、カルチャーコードに基づいた文字列を取得します。
        /// </summary>
        /// <param name="key">文字列を取得するリソースファイルキー</param>
        /// <returns>取得したい文字列</returns>
        public static string GetString(string key)
        {
            return resourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? string.Empty;
        }
    }
}
