using UnityEngine;

public class CreditMenuButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuManager.CreditsButtons _thisbuttonType;

    public void ButtonClicked ()
    {
        MainMenuManager._.CreditsButtonClicked(_thisbuttonType);
    }
}
