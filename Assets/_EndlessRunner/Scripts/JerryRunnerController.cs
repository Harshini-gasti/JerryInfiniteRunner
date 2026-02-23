using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryRunnerController : MonoBehaviour
{
    // Reference for Character Controller, Animator
    CharacterController controller;
    Animator animator;

    // Player Movement Vector
    Vector3 Movement;

    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reset Movement to zero every frame
        Movement = Vector3.zero; // Movement -> Vector3(0,0,0)

        // Get Input - X --> Right and Left directions
        Movement.x = Input.GetAxisRaw("Horizontal") * speed; // Left and Right arrows / A,D

        // Get Input - Y --> Up  and Down directions

        // Get Input - Z --> Forward
        Movement.z = speed;

        //transform.Translate(Vector3.forward); // change pos of the player one unit per frame
        //transform.Translate(Vector3.forward * Time.deltaTime); // change pos of the player one unit per second
        
        controller.Move(Movement * Time.deltaTime);
    }
}
