using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartButtonClicked);
        mainMenuButton.onClick.AddListener(MainMenuButtonClicked);
    }

    private void MainMenuButtonClicked()
    {
        SoundManager.Instance.PlaySoundEffect(Sound.BUTTON_CLICK);
        SceneManager.LoadScene(0);
    }

    private void RestartButtonClicked()
    {
        SoundManager.Instance.PlaySoundEffect(Sound.BUTTON_CLICK);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
