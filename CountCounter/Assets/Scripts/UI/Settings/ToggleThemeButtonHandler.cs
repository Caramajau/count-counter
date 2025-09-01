using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class ToggleThemeButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private Button toggleThemeButton;

        [SerializeField] 
        private ThemeSO lightTheme;

        [SerializeField] 
        private ThemeSO darkTheme;

        // TODO: Persist theme choice between sessions and correctly between scenes.
        private bool isDarkMode = false;

        private void OnEnable()
        {
            toggleThemeButton.onClick.AddListener(ToggleTheme);
        }

        private void OnDisable()
        {
            toggleThemeButton.onClick.RemoveListener(ToggleTheme);
        }

        private void ToggleTheme()
        {
            isDarkMode = !isDarkMode;
            ThemeManager.Instance.ApplyTheme(isDarkMode ? darkTheme : lightTheme);
        }
    }
}
