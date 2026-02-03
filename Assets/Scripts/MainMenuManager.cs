using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager _;
    [SerializeField] private bool _debugMode;
    public enum MainMenuButtons { play, options, credits, quit };
    public enum SocialButtons { website, twitter, youtube  };
    public enum CreditsButtons { back };
    public enum SettingsButtons { back };
    [SerializeField] GameObject _MainMenuContainer;
    [SerializeField] GameObject _SettingMenuContainer;
    [SerializeField] GameObject _CreditsMenuContainer;
    [SerializeField] private string _sceneToLoadAfterClickingPlay;
    public void Awake()
    {
        if (_ == null)
        {
           _ = this;
        }
        else
        {
            Debug.LogError("There are more than 1 MainMenuManager's in the scene");
        }  
    }

    private void Start()
    {
        OpenMenu(_MainMenuContainer);
    }

    public void MainMenuButtonClicked (MainMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked: " + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case MainMenuButtons.play:
                PlayClicked();
                break;
            case MainMenuButtons.options:
                OptionsClicked();
                break;
            case MainMenuButtons.credits:
                CreditsClicked();
                break;
            case MainMenuButtons.quit:
                QuitGaame();
                break;
            default:
                Debug.Log("Button clicked that wasn't implemented in MainMenuManager Method");
                break;


        }
    }

        public void SocialButtonClicked (SocialButtons buttonClicked)
    {
        string websiteLink = "";
        switch (buttonClicked)
        {
            case SocialButtons.website:
                websiteLink = "http://www.google.com"; //TODO: Put actual website
                break;
            case SocialButtons.twitter:
                websiteLink = "";
                break;
            case SocialButtons.youtube:
                websiteLink = "";
                break;
            default:
                Debug.LogError("Social button clicked not implemented on SocialButtonClicked method");
                break;
        }
        if (websiteLink != "")
        {
            Application.OpenURL(websiteLink);
        }
    }

    public void CreditsClicked()
    {
        OpenMenu(_CreditsMenuContainer);
    }

    public void OptionsClicked()
    {
        OpenMenu(_SettingMenuContainer);
    }

    public void ReturnToMainMenu()
    {
        OpenMenu(_MainMenuContainer);
    }

    public void CreditsButtonClicked(CreditsButtons buttonClicked)
    {
        switch (buttonClicked)
        {
            case CreditsButtons.back:
                ReturnToMainMenu();
                break;

        }
    }

    public void SettingsButtonClicked(SettingsButtons buttonClicked)
    {
        switch (buttonClicked)
        {
            case SettingsButtons.back:
                ReturnToMainMenu();
                break;
        }
    }

    void DebugMessage(string message)
    {
        if (_debugMode)
        {
            Debug.Log(message);
        }
    }

    public void PlayClicked()
    {
        SceneManager.LoadScene(_sceneToLoadAfterClickingPlay);
    }

    public void QuitGaame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void OpenMenu(GameObject menuToOpen)
    {
        _MainMenuContainer.SetActive(menuToOpen == _MainMenuContainer);
        _CreditsMenuContainer.SetActive(menuToOpen == _CreditsMenuContainer);
        _SettingMenuContainer.SetActive(menuToOpen == _SettingMenuContainer);
    }
}
