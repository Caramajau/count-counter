using UI.Settings;
using UnityEngine;

namespace DataPersistence.DataClasses
{
    [System.Serializable]
    public class SettingsData : Data
    {
        [SerializeField]
        private ThemeSO currentTheme;
        public ThemeSO CurrentTheme { get => currentTheme; set => currentTheme = value; }
    }
}
