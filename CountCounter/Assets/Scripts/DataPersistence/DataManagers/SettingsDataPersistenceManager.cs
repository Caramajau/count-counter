using DataPersistence.DataClasses;
using UI.Settings;

namespace DataPersistence.DataManagers
{
    // Unity does not support having parametrized classes as components
    // so have to make a subclass for each data type to be saved.
    public class SettingsDataPersistenceManager : DataPersistenceManager<SettingsData>
    {
        private void Start()
        {
            if (!HasData())
            {
                CreateNewData();
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            ThemeManager.OnThemeChanged += SaveTheme;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ThemeManager.OnThemeChanged -= SaveTheme;
        }

        private void SaveTheme(ThemeSO _)
        {
            SaveTheData();
        }
    }
}
