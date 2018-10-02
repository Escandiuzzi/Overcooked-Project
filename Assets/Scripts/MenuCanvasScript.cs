using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasScript : MonoBehaviour {

    public GameObject instructionsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

}
