using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Vector3 lastVelocity;
    Rigidbody2D rb;
    public int DogsGathered = 0;
    private List<GameObject> listOfDogs;
    private Vector2 enemyPos;
    private bool canMove = true;
    public GameObject manager;

    void Start()
    {
        listOfDogs = new List<GameObject>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce((GetMousePosition() - gameObject.transform.position).normalized * speed);   
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            rb.velocity =  Vector2.zero;
        }
        lastVelocity = rb.velocity;
    }

    Vector3 GetMousePosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dog")
        {
            if (!listOfDogs.Contains(collision.gameObject))
            {
                listOfDogs.Add(collision.gameObject);
                GameEvents.current.GatherDog();
            }

        }

        if (collision.gameObject.tag == "Ogre")
        {
            canMove = false;
            GameEvents.current.FinishGame();
        }
    }
}
