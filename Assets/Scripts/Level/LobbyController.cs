using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
        quitButton.onClick.AddListener(QuitButtonClicked);
    }

    private void QuitButtonClicked()
    {
       Application.Quit();
    }

    private void PlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
