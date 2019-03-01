using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 movementVector;
    private Vector2 movementVelocity;
    private float pressRightTrigger;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
        Vector2 movementVector = new Vector2(movementX, movementY);
        Vector2 movementVelocity = movementVector * moveSpeed;
        rb.velocity = movementVelocity;

        pressRightTrigger = Input.GetAxisRaw("Fire1");

        // Shooting
        if (pressRightTrigger > 0)
        {
            hit = Physics2D.Raycast(rb.position, Vector2.down);
        }
        
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            print("IT WORKS");
            //hit.collider.gameObject.SetActive(false);
        }
    }
}
