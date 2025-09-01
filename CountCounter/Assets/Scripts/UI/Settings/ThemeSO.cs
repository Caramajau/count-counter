using UnityEngine;

namespace UI.Settings
{
    [CreateAssetMenu(menuName = "UI/Theme")]
    public class ThemeSO : ScriptableObject
    {
        [Header("General Colours")]
        [field: SerializeField]
        public Color BackgroundColour { get; private set; } = Color.white;

        [field: SerializeField]
        public Color TextColour { get; private set; } = Color.black;

        [Header("Button Colours")]
        [field: SerializeField]
        public Color ButtonNormal { get; private set; } = Color.white;

        [field: SerializeField]
        public Color ButtonHighlighted { get; private set; } = new(0.9607843f, 0.9607843f, 0.9607843f, 1);

        [field: SerializeField]
        public Color ButtonSelected { get; private set; } = new(0.9607843f, 0.9607843f, 0.9607843f, 1);

        [field: SerializeField]
        public Color ButtonPressed { get; private set; } = new(0.7843137f, 0.7843137f, 0.7843137f, 1);

        [field: SerializeField]
        public Color ButtonDisabled { get; private set; } = new(0.7843137f, 0.7843137f, 0.7843137f, 0.5019608f);
    }
}
