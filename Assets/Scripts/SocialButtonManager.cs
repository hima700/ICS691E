using UnityEngine;

public class SocialButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuManager.SocialButtons _thisbuttonType;

    public void ButtonClicked ()
    {
        MainMenuManager._.SocialButtonClicked(_thisbuttonType);
    }
}
