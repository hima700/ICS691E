/** 
Creating a start menu in Unity with C# involves setting up UI elements in a separate scene and using a C# script to manage scene transitions and application controls. 
Step 1: Set up the Menu Scene
Create a New Scene: In the Project window, right-click in your "Scenes" folder, select Create > Scene, and name it MainMenu. Double-click the scene to open it.
Add UI Canvas: In the Hierarchy window, right-click and select UI > Canvas. All other UI elements will be children of this Canvas GameObject.
Add Menu Title: Right-click the Canvas GameObject, select UI > Text - TextMeshPro (ensure you import the TMP essentials if prompted), and name it TitleText. Position and format the text in the Inspector window as desired.
Add Buttons:
Right-click the Canvas GameObject, select UI > Button - TextMeshPro, and name it PlayButton.
Duplicate the PlayButton and rename the new one QuitButton.
Adjust the text labels on each button to read "Play" and "Quit" respectively. Position the buttons within the canvas.
Add Scene to Build Settings: Go to File > Build Settings. Drag your MainMenu scene into the "Scenes in Build" list and ensure it is at index 0 (this is important for loading the correct scene later). Add your main game scene to the list as index 1. 
Step 2: Create the C# Script 
Create a Script: In the Project window, create a new folder called "Scripts" if you don't have one. Right-click within the folder, select Create > C# Script, and name it MainMenuManager.
Attach Script: Drag the MainMenuManager script onto your Canvas GameObject in the Hierarchy.
Edit the Script: Double-click the script to open it in your code editor. Add the UnityEngine.SceneManagement namespace and define public functions for the buttons. 
csharp
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class MainMenuManager : MonoBehaviour
{
    // Function to load the main game scene
    public void StartGame()
    {
        // Loads the scene at build index 1 (your game scene)
        SceneManager.LoadScene(1);
    }

    // Function to quit the application
    public void QuitGame()
    {
        // Closes the game application (only works in a built game, not the Unity Editor)
        Application.Quit();
        Debug.Log("Game Quit (Note: This only works in a built game)");
    }
}
Step 3: Link Buttons to the Script
Select PlayButton: In the Hierarchy, select the PlayButton.
Configure On Click() Event: In the Inspector, scroll to the Button component and find the On Click () section. Click the + icon to add a new event.
Drag and Drop: Drag the Canvas GameObject (which has the MainMenuManager script attached) from the Hierarchy into the object field (labeled "None (Object)").
Select Function: In the dropdown menu that appears, select MainMenuManager > StartGame().
Repeat for QuitButton: Select the QuitButton, add a new On Click () event, drag the Canvas GameObject into the object field, and select MainMenuManager > QuitGame() from the dropdown. 
You can now press Play in the Unity Editor to test your start menu functionality. The "Play" button will load your game scene, and the "Quit" button will log a message in the console (and quit the application when you build the project). */