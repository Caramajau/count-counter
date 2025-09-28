using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using DataPersistence;
using DataPersistence.DataClasses;

namespace UI.Settings
{
    public class ThemeManager : MonoBehaviour, IDataPersistence<SettingsData>
    {
        public static ThemeManager Instance { get; private set; }

        [SerializeField]
        private ThemeSO lightTheme;

        [SerializeField]
        private ThemeSO darkTheme;

        public ThemeSO CurrentTheme { get; private set; }

        public static event Action<ThemeSO> OnThemeChanged;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void ApplyTheme(ThemeSO newTheme)
        {
            CurrentTheme = newTheme;
            OnThemeChanged?.Invoke(CurrentTheme);
        }

        public void ToggleTheme()
        {
            if (CurrentTheme == null)
            {
                Debug.LogError("Current theme is null!");
                return;
            }

            ApplyTheme(CurrentTheme == lightTheme ? darkTheme : lightTheme);
        }

        public void LoadData(SettingsData data)
        {
            if (data.CurrentTheme == null)
            {
                // If no theme has been saved, default to light.
                CurrentTheme = lightTheme;
                return;
            }
            CurrentTheme = data.CurrentTheme;
            ApplyTheme(CurrentTheme);
        }

        public void SaveData(SettingsData data)
        {
            data.CurrentTheme = CurrentTheme;
        }
    }
}
