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
            toggleThemeButton.onClick.AddListener(ToggleTheme);
        }

        private void OnDisable()
        {
            toggleThemeButton.onClick.RemoveListener(ToggleTheme);
        }

        private void ToggleTheme()
        {
            ThemeManager.Instance.ToggleTheme();
        }
    }
}
