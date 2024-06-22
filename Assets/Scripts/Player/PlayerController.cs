using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private bool crouched = false;
    private Vector2 normalColliderSize = new Vector2(0.5507991f, 2.073027f);
    private Vector2 crouchedColliderSize = new Vector2(0.7272125f, 1.358973f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        crouch(Input.GetKeyDown(KeyCode.LeftControl));
        Debug.Log(speed);
        if (animator != null)
        {
            animator.SetFloat("Speed",Mathf.Abs(speed));
            animator.SetBool("Crouch", crouched);
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

    void crouch(bool crouch)
    {
        if (crouch)
        {
            crouched = !crouched;
            if (crouched)
            {
                GetComponent<BoxCollider2D>().size = crouchedColliderSize;
                GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, GetComponent<BoxCollider2D>().offset.y -0.4f);
            }
            else
            {
                GetComponent<BoxCollider2D>().size = normalColliderSize;
                GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, GetComponent<BoxCollider2D>().offset.y + 0.4f);

            }
        }
    }
}
