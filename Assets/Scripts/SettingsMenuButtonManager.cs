using UnityEngine;

public class SettingsMenuButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuManager.SettingsButtons _thisbuttonType;

    public void ButtonClicked ()
    {
        MainMenuManager._.SettingsButtonClicked(_thisbuttonType);
    }
}
