using UnityEngine;

namespace UI.Settings
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Theme")]
    public class ThemeSO : ScriptableObject
    {
        [field: SerializeField]
        [Tooltip("The background colour of the UI.")]
        public Color BackgroundColour { get; private set; } = Color.white;

        [field: SerializeField]
        [Tooltip("The text colour of the UI.")]
        public Color TextColour { get; private set; } = Color.black;

        [field: SerializeField]
        [Tooltip("The colour of buttons in their normal state.")]
        public Color ButtonNormal { get; private set; } = Color.white;

        [field: SerializeField]
        [Tooltip("The colour of buttons when highlighted.")]
        public Color ButtonHighlighted { get; private set; } = new(0.9607843f, 0.9607843f, 0.9607843f);

        [field: SerializeField]
        [Tooltip("The colour of buttons when selected.")]
        public Color ButtonSelected { get; private set; } = new(0.9607843f, 0.9607843f, 0.9607843f);

        [field: SerializeField]
        [Tooltip("The colour of buttons when pressed.")]
        public Color ButtonPressed { get; private set; } = new(0.7843137f, 0.7843137f, 0.7843137f);

        [field: SerializeField]
        [Tooltip("The colour of buttons when disabled.")]
        public Color ButtonDisabled { get; private set; } = new(0.7843137f, 0.7843137f, 0.7843137f, 0.5019608f);
    }
}
