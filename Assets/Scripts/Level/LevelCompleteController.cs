using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour
{
    public Button nextLevelButton;
    public Button mainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        nextLevelButton.onClick.AddListener(NextButtonClicked);
        mainMenuButton.onClick.AddListener(MainMenuButtonClicked);
    }

    private void MainMenuButtonClicked()
    {
        SoundManager.Instance.PlaySoundEffect(Sound.BUTTON_CLICK);
        SceneManager.LoadScene(0);
    }

    private void NextButtonClicked()
    {
        SoundManager.Instance.PlaySoundEffect(Sound.BUTTON_CLICK);
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
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
