using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    bool isOnRange = false;
    public float speed;
    private GameObject ballProje;
    public Animator dogAnimator;

    // Update is called once per frame
    void Update()
    {

        Vector2 lastPost = transform.position;

        if (isOnRange)
        {
            if (Vector2.Distance(transform.position, ballProje.transform.position) > 0.5)
            {
                transform.position = Vector2.MoveTowards(transform.position, ballProje.transform.position, speed * Time.deltaTime);
                dogAnimator.SetBool("Moving", true);
            }
            else
            {
                dogAnimator.SetBool("Moving", false);
            }

            Vector3 characterScale = transform.localScale;
            if (transform.position.x > ballProje.transform.position.x)
            {
                characterScale.x = 1;
            }
            else
            {
                characterScale.x = -1;
            }
            transform.localScale = characterScale;
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Projectile")
        {
            isOnRange = true;
            ballProje = collision.gameObject;
        }
    }
}
