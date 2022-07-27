using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private bool turnLeft, turnRight;
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

        if (turnLeft&& this.transform.localRotation.y - 90 >=  -90)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight && this.transform.localRotation.y + 90<=90)
            transform.Rotate(new Vector3(0f, 90f, 0f));

        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
        speed += speedtime * Time.deltaTime;
        
    }
    
}

