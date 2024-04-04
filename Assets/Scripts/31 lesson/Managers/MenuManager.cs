using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Window menuPanel;
    [SerializeField] private Window authorPanel;
    [SerializeField] private Window settingsPanel;
    [SerializeField] private Window levelPanel;

    public void ShowAuthorPanel()
    {
        authorPanel.Open_Instantly();
        menuPanel.Close_Instantly();
    }

    public void ShowLevelPanel()
    {
        levelPanel.Open_Instantly();
        menuPanel.Close_Instantly();
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.Open_Instantly();
        menuPanel.Close_Instantly();
    }

    public void ShowMenuPanel()
    {
        menuPanel.Open_Instantly();
        authorPanel.Close_Instantly();
        levelPanel.Close_Instantly();
        settingsPanel.Close_Instantly();
    }
}
