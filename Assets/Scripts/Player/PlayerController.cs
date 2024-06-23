using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;
    private bool crouched = false;
    private Vector2 initColliderSize;
    private Vector2 initColliderOffset;

    void Start()
    {
        initColliderSize = boxCollider2D.size;
        initColliderOffset = boxCollider2D.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vecticalInput = Input.GetAxisRaw("Jump");
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetBool("Crouch", crouched);
        }
        playJumpAnimation(vecticalInput);
        crouch(Input.GetKeyDown(KeyCode.LeftControl));
        RotatePlayer(horizontal);

    }

    private void RotatePlayer(float horizontal)
    {
        Vector3 scale = transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(horizontal);
        }
        else if (horizontal > 0f)
        {
            scale.x = Mathf.Abs(horizontal);
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
                Vector2 crouchedColliderSize = new Vector2(0.7272125f, 1.358973f);
                Vector2 crouchedColliderOffset = new Vector2(0f, -0.4f);

                boxCollider2D.size = crouchedColliderSize;
                boxCollider2D.offset = new Vector2(initColliderOffset.x + crouchedColliderOffset.x, initColliderOffset.y + crouchedColliderOffset.y);
            }
            else
            {
                boxCollider2D.size = initColliderSize;
                boxCollider2D.offset = initColliderOffset;
            }
        }
    }

    void playJumpAnimation(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
