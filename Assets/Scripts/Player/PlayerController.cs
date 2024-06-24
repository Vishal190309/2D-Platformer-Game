using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;
    private Rigidbody2D rg2D;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private int health = 3;
    private bool IsGrounded;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundedLayer;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private HealthController healthController;
    [SerializeField] private GameOverController gameOverController;

    private bool crouched = false;
    private Vector2 initColliderSize;
    private Vector2 initColliderOffset;

    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        initColliderSize = boxCollider2D.size;
        initColliderOffset = boxCollider2D.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vectical = Input.GetAxisRaw("Jump");
        JumpCharacter(vectical);
        MoveCharacter(horizontal);
        RotatePlayer(horizontal);
        PlayAnimations(horizontal, vectical);

    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    void PlayFootStepSound()
    {
        SoundManager.Instance.PlaySoundEffect(Sound.PLAYER_MOVE);
    }
    public void ReduceHealth(int damage)
    {
        health -= damage;
        healthController.updateHealth(health);
        if(health <= 0)
        {
            gameOverController.PlayerDied();
            this.enabled = false;
        }

    }
    void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    void JumpCharacter(float vertical)
    {
        if (vertical > 0 &&  IsGrounded )
        {
            rg2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

   

    private void PlayAnimations(float horizontal, float vectical)
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetBool("Crouch", crouched);
        }
        playJumpAnimation(vectical);
        crouch(Input.GetKeyDown(KeyCode.LeftControl));
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
        if (vertical > 0 && IsGrounded)
        {
            SoundManager.Instance.PlaySoundEffect(Sound.PLAYER_JUMP,0.01f);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump",false);
        }
        
    }

   /* private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundedLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position  - transform.up * castDistance, boxSize);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }
}
