using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        Debug.Log(speed);
        if (animator != null)
        {
            animator.SetFloat("Speed",Mathf.Abs(speed));
        }
        Vector3 scale = transform.localScale;
        if (speed < 0f)
        {
           scale.x = -1f * Mathf.Abs(speed);
        }
        else if(speed>0f)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;

    }
}
