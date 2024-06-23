using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = gameObject.GetComponent<TextMeshProUGUI>();
        updateHealth(3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void updateHealth(int health)
    {
        healthText.text = "Health: " + health;
        
    }
}
