using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class ToggleThemeButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private Button toggleThemeButton;

        private void OnEnable()
        {
            toggleThemeButton.onClick.AddListener(OnToggleThemeButtonClicked);
        }

        private void OnDisable()
        {
            toggleThemeButton.onClick.RemoveListener(OnToggleThemeButtonClicked);
        }

        private static void OnToggleThemeButtonClicked()
        {
            ThemeManager.Instance.ToggleTheme();
        }
    }
}
