using UnityEngine;
using System;

namespace UI.Settings
{
    public class ThemeManager : MonoBehaviour
    {
        public static ThemeManager Instance { get; private set; }

        [SerializeField]
        private ThemeSO lightTheme;

        [SerializeField]
        private ThemeSO darkTheme;

        // TODO: Persist theme choice between sessions
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

            CurrentTheme = lightTheme;
        }

        private void Start()
        {
            ApplyTheme(CurrentTheme);
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
    }
}
