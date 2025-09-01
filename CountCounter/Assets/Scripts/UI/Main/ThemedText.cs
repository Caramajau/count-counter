using UnityEngine;
using TMPro;
using UI.Settings;

namespace UI.Main
{
    public class ThemedText : MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Awake()
        {
            if (!TryGetComponent<TextMeshProUGUI>(out text))
            {
                Debug.LogError("Themed text requires a Text component.");
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
            text.color = theme.TextColour;
        }
    }
}
