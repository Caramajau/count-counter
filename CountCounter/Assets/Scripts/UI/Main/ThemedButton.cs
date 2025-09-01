using UI.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    public class ThemedButton : MonoBehaviour
    {
        private Image buttonImage;

        private Button button;

        private void Awake()
        {
            if (!TryGetComponent<Image>(out buttonImage))
            {
                Debug.LogError("A themed button requires an Image component.");
            }

            if (!TryGetComponent<Button>(out button))
            {
                Debug.LogError("A themed button requires a Button component.");
            }
        }

        private void OnEnable()
        {
            ThemeManager.OnThemeChanged += ApplyTheme;
            ApplyTheme(ThemeManager.Instance.CurrentTheme);
        }

        private void OnDisable()
        {
            ThemeManager.OnThemeChanged -= ApplyTheme;
        }

        private void ApplyTheme(ThemeSO theme)
        {
            if (theme == null)
            {
                return;
            }

            ColorBlock colors = button.colors;

            colors.normalColor = theme.ButtonNormal;
            colors.highlightedColor = theme.ButtonHighlighted;
            colors.selectedColor = theme.ButtonSelected;
            colors.pressedColor = theme.ButtonPressed;
            colors.disabledColor = theme.ButtonDisabled;

            button.colors = colors;

            buttonImage.color = theme.ButtonNormal;
        }
    }
}
