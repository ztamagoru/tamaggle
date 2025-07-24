using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadRandomLevel()
    {
        int index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        Debug.Log($"Loading random level with index: {index}");
        //SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
        
        // If running in the editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
