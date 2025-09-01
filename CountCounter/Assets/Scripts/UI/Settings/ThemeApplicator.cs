using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class ThemeApplicator : MonoBehaviour
    {
        private const FindObjectsInactive includeInactive = FindObjectsInactive.Include;
        private const FindObjectsSortMode noSort = FindObjectsSortMode.None;

        private void OnEnable()
        {
            ThemeManager.OnThemeChanged += ApplyThemeToScene;
            ApplyThemeToScene(ThemeManager.Instance.CurrentTheme);
        }

        private void OnDisable()
        {
            ThemeManager.OnThemeChanged -= ApplyThemeToScene;
        }

        private void ApplyThemeToScene(ThemeSO theme)
        {
            foreach (var button in FindObjectsByType<Button>(includeInactive, noSort))
            {
                ApplyThemeToButton(theme, button);
            }

            foreach (var text in FindObjectsByType<TextMeshProUGUI>(includeInactive, noSort))
            {
                ApplyThemeToText(theme, text);
            }

            Debug.Log("Applied theme to scene.");
        }

        private void ApplyThemeToButton(ThemeSO theme, Button button)
        {
            ColorBlock colors = button.colors;

            colors.normalColor = theme.ButtonNormal;
            colors.highlightedColor = theme.ButtonHighlighted;
            colors.selectedColor = theme.ButtonSelected;
            colors.pressedColor = theme.ButtonPressed;
            colors.disabledColor = theme.ButtonDisabled;

            button.colors = colors;
        }

        private void ApplyThemeToText(ThemeSO theme, TextMeshProUGUI text)
        {
            text.color = theme.TextColour;
        }
    }
}
