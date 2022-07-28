using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private bool turnLeft, turnRight, canTurnLeft = true, canTurnRight = true;
    public float speed = 7.0f;
    private CharacterController myCharacterController;
    public float speedtime;
    public UnityEvent Event;

    public void Awake()
    {
        if(instance == null)
        instance = this;
    }
    public void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -5f)
            Event.Invoke();

        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);

        if (turnLeft && canTurnLeft)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
            canTurnLeft = false;
            canTurnRight = true;
        }
        else if (turnRight && canTurnRight)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
            canTurnRight = false;
            canTurnLeft = true;
        }


        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
        speed += speedtime * Time.deltaTime;
        
    }
    
}

