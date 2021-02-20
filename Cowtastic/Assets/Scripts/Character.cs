using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    // Start is called before the first frame update
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        float moving = 0f;
        if(Mathf.Abs(movement.x) > 0 && movement.y == 0)
        {
            moving = movement.x;
        }else if (movement.x == 0 && Mathf.Abs(movement.y) > 0)
        {
            moving = movement.y;
        }
        else
        {
            moving = movement.x;
        }
        animator.SetFloat("Moving", Mathf.Abs(moving));
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector3 characterScale = transform.localScale;

        if (Mathf.Abs(HandleCharacterDirection()) > 90)
        {
            characterScale.x = 1;
        }
        else
        {
            characterScale.x = -1;
        }
        transform.localScale = characterScale;
    }

    Vector3 GetMousePosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }

    private float HandleCharacterDirection()
    {
        Vector3 dir = (GetMousePosition() - gameObject.transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0, 0, angle);
        return angle;
    }
}
