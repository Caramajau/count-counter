using CounterLogic;
using System.IO;
using TMPro;
# if UNITY_EDITOR
using UnityEditor;
# endif
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI counterText;

        [SerializeField]
        private Button incrementButton;

        [SerializeField]
        private Button resetButton;

        [SerializeField]
        private Button saveButton;

        [SerializeField]
        private Button quitButton;

        private CounterHandler counterHandler;

        private void Awake()
        {
            string dataPath = Path.Combine(Application.persistentDataPath, "counter.txt");
            counterHandler = new CounterHandler(new TextFileHandler(dataPath));
            UpdateCounterText();
        }

        private void OnEnable()
        {
            incrementButton.onClick.AddListener(OnIncrementButtonClicked);
            resetButton.onClick.AddListener(OnResetButtonClicked);
            saveButton.onClick.AddListener(OnSaveButtonClicked);
            quitButton.onClick.AddListener(OnQuitButtonClicked);
        }

        private void OnDisable()
        {
            incrementButton.onClick.RemoveListener(OnIncrementButtonClicked);
            resetButton.onClick.RemoveListener(OnResetButtonClicked);
            saveButton.onClick.RemoveListener(OnSaveButtonClicked);
            quitButton.onClick.RemoveListener(OnQuitButtonClicked);
        }

        public void OnApplicationQuit()
        {
            OnSaveButtonClicked();
        }

        public void OnIncrementButtonClicked()
        {
            counterHandler.IncrementCounter();
            UpdateCounterText();
        }

        public void OnResetButtonClicked()
        {
            counterHandler.ResetCounter();
            UpdateCounterText();
        }

        public void OnSaveButtonClicked()
        {
            counterHandler.SaveCounter();
        }

        public void OnQuitButtonClicked()
        {
            OnSaveButtonClicked();
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        private void UpdateCounterText()
        {
            counterText.text = counterHandler.Counter.ToString();
        }
    }
}
