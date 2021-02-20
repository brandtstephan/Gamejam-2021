using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : MonoBehaviour
{
    public Animator ogreAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("heheh");
        if (collision.gameObject.tag == "Projectile")
        {
            ogreAnimator.SetTrigger("Kill");
        }
        //Change animation
        //WaitTillAnimationFinishes
        //Destroy
    }
}
