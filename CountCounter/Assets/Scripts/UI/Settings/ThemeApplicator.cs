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

        private static void ApplyThemeToScene(ThemeSO theme)
        {
            if (theme == null)
            {
                Debug.LogError("Theme is null, cannot apply theme to scene.");
                return;
            }

            foreach (var button in FindObjectsByType<Button>(includeInactive, noSort))
            {
                ApplyThemeToButton(theme, button);
            }

            foreach (var text in FindObjectsByType<TextMeshProUGUI>(includeInactive, noSort))
            {
                ApplyThemeToText(theme, text);
            }
        }

        private static void ApplyThemeToButton(ThemeSO theme, Button button)
        {
            ColorBlock colors = button.colors;

            colors.normalColor = theme.ButtonNormal;
            colors.highlightedColor = theme.ButtonHighlighted;
            colors.selectedColor = theme.ButtonSelected;
            colors.pressedColor = theme.ButtonPressed;
            colors.disabledColor = theme.ButtonDisabled;

            button.colors = colors;
        }

        private static void ApplyThemeToText(ThemeSO theme, TextMeshProUGUI text)
        {
            text.color = theme.TextColour;
        }
    }
}
