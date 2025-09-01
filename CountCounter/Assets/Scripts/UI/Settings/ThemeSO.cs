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
        public Color TextColour { get; private set; } = new Color32(50, 50, 50, 255);

        [field: SerializeField]
        [Tooltip("The colour of text with outlines in the UI.")]
        public Color TextWithOutlineColour { get; private set; } = Color.white;

        [field: SerializeField]
        [Tooltip("The outline colour of text with outlines in the UI.")]
        public Color TextOutlineColour { get; private set; } = new Color32(50, 50, 50, 255);

        [field: SerializeField]
        [Tooltip("The colour of buttons in their normal state.")]
        public Color ButtonNormal { get; private set; } = Color.white;

        [field: SerializeField]
        [Tooltip("The colour of buttons when highlighted.")]
        public Color ButtonHighlighted { get; private set; } = new Color32(245, 245, 245, 255);

        [field: SerializeField]
        [Tooltip("The colour of buttons when selected.")]
        public Color ButtonSelected { get; private set; } = new Color32(245, 245, 245, 255);

        [field: SerializeField]
        [Tooltip("The colour of buttons when pressed.")]
        public Color ButtonPressed { get; private set; } = new Color32(200, 200, 200, 255);

        [field: SerializeField]
        [Tooltip("The colour of buttons when disabled.")]
        public Color ButtonDisabled { get; private set; } = new Color32(200, 200, 200, 128);
    }
}
