using UI.Settings;
using UnityEngine;

namespace DataPersistence.DataClasses
{
    [System.Serializable]
    public class SettingsData : Data
    {
        [field: SerializeField]
        public ThemeSO SelectedTheme { get; set; }
    }
}
