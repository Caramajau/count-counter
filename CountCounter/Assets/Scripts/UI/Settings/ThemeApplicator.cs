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

            foreach (var image in FindObjectsByType<Image>(includeInactive, noSort))
            {
                if (image.CompareTag("ThemedBackground"))
                {
                    ApplyThemeToBackgroundImage(theme, image);
                }
            }
        }

        private static void ApplyThemeToButton(ThemeSO theme, Button button)
        {
            ColorBlock colours = button.colors;

            colours.normalColor = theme.ButtonNormal;
            colours.highlightedColor = theme.ButtonHighlighted;
            colours.selectedColor = theme.ButtonSelected;
            colours.pressedColor = theme.ButtonPressed;
            colours.disabledColor = theme.ButtonDisabled;

            button.colors = colours;
        }

        private static void ApplyThemeToText(ThemeSO theme, TextMeshProUGUI text)
        {
            if (text.outlineWidth > 0)
            {
                text.color = theme.TextWithOutlineColour;
                text.outlineColor = theme.TextOutlineColour;
                return;
            }
            text.color = theme.TextColour;
        }

        private static void ApplyThemeToBackgroundImage(ThemeSO theme, Image image)
        {
            image.color = theme.BackgroundColour;
        }
    }
}
