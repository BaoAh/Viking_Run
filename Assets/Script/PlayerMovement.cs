using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool turnLeft, turnRight,jump;
    public float speed = 10.0f;
    private float movingSpeed = 7f;

    public float jumpForceAmmount;
    private Vector3 jumpDir = new Vector3(0, 1, 0);
    private bool onGround = true, run = false;
    Animator animator;
    public Rigidbody transformRigidbody;
    //private CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        //myCharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        transformRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        run = true;

        transform.localPosition += movingSpeed * Time.deltaTime * transform.forward;

        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        jump = Input.GetKeyDown(KeyCode.Space);

        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));

        jump = false;

        if ((onGround == true) && (Input.GetKey(KeyCode.Space)))
        {
            onGround = false;
            transformRigidbody.AddForce(jumpDir * jumpForceAmmount);
        }

        if (transform.localPosition.y < 1 && transform.localPosition.y > -1)
        {
            onGround = true;
        }
        else
        {
            jump = true;
        }

        animator.SetBool("Running",run);

        //myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        //myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}
