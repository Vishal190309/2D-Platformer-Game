using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.Play("Base Layer.KeyFadeOut",0,0.25f);
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();

            float counter = 0;
            float waitTime = 0.4f;
            //Now, Wait until the current state is done playing
            while (counter < (waitTime))
            {
                
                counter += Time.deltaTime;
                yield return null;
            }
            Destroy(gameObject);
        }

    }
}
