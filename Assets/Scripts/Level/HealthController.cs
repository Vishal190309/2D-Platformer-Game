using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    int health =3;
    TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = gameObject.GetComponent<TextMeshProUGUI>();
        RefereshUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RefereshUI()
    {
        healthText.text = "Score: " + health;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
        RefereshUI();
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
