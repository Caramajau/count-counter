using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Main
{
    public class UIFocusHandler : MonoBehaviour
    {
        [SerializeField]
        private Button defaultFocusButton;

        // Has default state as not selected, in other words, the way that mouse controls wants it.
        // Could alternatively have it selected as default, which would be how keyboard/gamepad controls wants it.
        private void Update()
        {
            if (IsMouseMoving() && IsObjectSelected())
            {
                EventSystem.current.SetSelectedGameObject(null);
            }

            if ((WasKeyboardPressed() || WasGamepadUpdated()) && !IsObjectSelected() && defaultFocusButton != null)
            {
                EventSystem.current.SetSelectedGameObject(defaultFocusButton.gameObject);
            }
        }

        private static bool IsMouseMoving()
        {
            return Mouse.current.delta.ReadValue() != Vector2.zero;
        }

        private static bool IsObjectSelected()
        {
            return EventSystem.current.currentSelectedGameObject != null;
        }

        private static bool WasKeyboardPressed()
        {
            return Keyboard.current.anyKey.wasPressedThisFrame;
        }

        private static bool WasGamepadUpdated()
        {
            return Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame;
        }
    }
}
