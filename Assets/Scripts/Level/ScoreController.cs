using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    int score;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
       scoreText =  gameObject.GetComponent<TextMeshProUGUI>();
        RefereshUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RefereshUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore(int scoreToAdd)
    {
        score += scoreToAdd;
        RefereshUI();
    }

}
