using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyController : MonoBehaviour
{
    private Transform currentPatrolPoint;
    public Transform patrolPointA;
    public Transform patrolPointB;
    private Rigidbody2D rb;
    private Animator animator;
    public float speed;
    public float damage =1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPatrolPoint = patrolPointB;
        animator.SetBool("Walking",false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToCurrentPatrolPoint();
    }

    void MoveToCurrentPatrolPoint()
    {
        animator.SetBool("Walking", true);
        Vector2 point = transform.position - currentPatrolPoint.position;
        if (currentPatrolPoint == patrolPointB)
        {
            RotatePlayer(1);
            rb.velocity = new Vector2(speed, 0);
            
        }
        else
        {
            RotatePlayer(-1);
            rb.velocity = new Vector2(-speed, 0);
            
        }
        checkIfPatrolPointReached();
    }

    void checkIfPatrolPointReached()
    {
        if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 0.2f && currentPatrolPoint == patrolPointB)
        {
            currentPatrolPoint = patrolPointA;
        }
        else if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 0.2f && currentPatrolPoint == patrolPointA)
        {
            currentPatrolPoint = patrolPointB;
        }
    }

    void RotatePlayer(int direction)
    {
        if (direction == 1)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (direction == -1) 
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.ReduceHealth((int)damage);
        }
    }

    


}
