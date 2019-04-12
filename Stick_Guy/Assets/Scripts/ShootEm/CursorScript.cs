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
        if (rb.position.x >= 8.75 && movementX > 0) // if out of bounds right and moving right
        {
            movementX *= -1; 
        }
        if (rb.position.x <= -8.75 && movementX < 0) // if out of bounds left and moving left
        {
            movementX *= -1;
        }
        if (rb.position.y >= 5.8 && movementY > 0) // if out of bounds up and moving up
        {
            movementY *= -1;
        }
        if (rb.position.y <= -3.85 && movementY < 0) // if out of bounds down and moving down
        {
            movementY *= -1;
        }
        Vector2 movementVector = new Vector2(movementX, movementY);
        Vector2 movementVelocity = movementVector * moveSpeed;
        rb.velocity = movementVelocity;

        // Shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            Debug.DrawRay(rb.position, Vector3.forward * 10f, Color.blue);
            hit = Physics2D.Raycast(rb.position, Vector3.forward); 
        }
        
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            print("IT WORKS");
            hit.collider.gameObject.SetActive(false);
        }
    }
}
