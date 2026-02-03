using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuManager.MainMenuButtons _thisbuttonType;

    public void ButtonClicked ()
    {
        MainMenuManager._.MainMenuButtonClicked(_thisbuttonType);
    }
}
