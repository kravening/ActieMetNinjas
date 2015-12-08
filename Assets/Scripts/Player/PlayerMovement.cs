using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private Xbox360Wired_InputController controller;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]private float rotationSpeed;
    [SerializeField]private float ccelerationSpeed;
    [SerializeField]private float baseMovementSpeed;
    [SerializeField]private float maxMovementSpeed;
    [SerializeField]private float currentMaxMovementSpeed;
    [SerializeField]private float currentMovementSpeed;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        controller = GetComponent<Xbox360Wired_InputController>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveCharacter();
	}

    private void MoveCharacter()
    {
        DynamicSpeedControl();

        if (controller.DeadZoneCheckLeft() == true)// only move if the controller is out of the deadzone
        {
            moveDirection = new Vector3(controller.leftStickX, 0 , controller.leftStickY);
            moveDirection = transform.TransformDirection(moveDirection);

            if(currentMovementSpeed <= currentMaxMovementSpeed)// for acceleration of the movement
            {
                currentMovementSpeed = currentMovementSpeed + (ccelerationSpeed * Time.deltaTime);
            }
            else if(currentMovementSpeed >= maxMovementSpeed)
            {
                currentMovementSpeed = Mathf.Clamp(currentMovementSpeed,0,maxMovementSpeed);
            }

            //moveDirection *= currentMovementSpeed;// sets speed

            //characterController.Move(moveDirection * Time.deltaTime);
        }
        else// if the stick is not used deaccalerate
        {
            if(currentMovementSpeed >= 0)
            {
                currentMovementSpeed = currentMovementSpeed - (ccelerationSpeed * Time.deltaTime); // for deccelerating of the movements
            }
            if (currentMovementSpeed <= 0)
            {
                currentMovementSpeed = 0;
            }
            //moveDirection *= -currentMovementSpeed;// sets speed
        }

        moveDirection.y -= 30 * Time.deltaTime; // gravity
        characterController.Move(moveDirection * currentMovementSpeed * Time.deltaTime);

        //how can i move in a direction without changing the actual rotation of an object (using rigidbody) or rotate without affecting the child objects.
    }

    private void DynamicSpeedControl()
    {
        if (controller.leftStickX >= .1f)
        {
            currentMaxMovementSpeed = maxMovementSpeed * controller.leftStickX; // do this so max movement speed is based on how far you push the stick
        }
        else if (controller.leftStickX <= -.1f)
        {
            currentMaxMovementSpeed = -maxMovementSpeed * controller.leftStickX; // multiplying by negatives makes positives
        }
        if (controller.leftStickY >= .1f)
        {
            currentMaxMovementSpeed = maxMovementSpeed * controller.leftStickY; // do this so max movement speed is based on how far you push the stick
        }
        else if (controller.leftStickY <= -.1f)
        {
            currentMaxMovementSpeed = -maxMovementSpeed * controller.leftStickY; // multiplying by negatives makes positives
        }
    }

    public void knockback()
    {

    }
}
