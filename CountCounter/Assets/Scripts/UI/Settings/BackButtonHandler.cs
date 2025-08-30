using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Settings
{
    public class BackButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private Button backButton;

        private void OnEnable()
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
