
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    
    private Rigidbody rb;

    private float movementX;

    private float movementY;

    private Vector3 startPosition;

    public Canvas uiCanvas;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;       
    }



    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            uiCanvas.gameObject.SetActive(true);
        }

        Move();     
    }


    private void Move()
    {
        movementX = Input.GetAxis("Horizontal");

        movementY = Input.GetAxis("Vertical");
    }


    private void FixedUpdate()
    {
        PlayerMovement();
    }


    private void PlayerMovement()
    {
        Vector3 movement = new Vector3(-movementX, 0.0f, -movementY);

        rb.AddForce(movement.normalized * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lava")
        {
            transform.position = startPosition;

            rb.linearVelocity = Vector3.zero;
        }
    }

    private void OnCollision(Collision other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            rb.linearVelocity = Vector3.zero;

            uiCanvas.gameObject.SetActive(true);
        }
    }


} // end of class
