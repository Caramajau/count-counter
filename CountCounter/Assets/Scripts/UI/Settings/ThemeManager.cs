using UnityEngine;
using System;

namespace UI.Settings
{
    public class ThemeManager : MonoBehaviour
    {
        public static ThemeManager Instance { get; private set; }

        [field: SerializeField]
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

        private void Start()
        {
            ApplyTheme(CurrentTheme);
        }

        public void ApplyTheme(ThemeSO newTheme)
        {
            CurrentTheme = newTheme;
            OnThemeChanged?.Invoke(CurrentTheme);
        }
    }
}
