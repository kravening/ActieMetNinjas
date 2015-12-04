using UnityEngine;
using System.Collections;

public class BodyPartRotation : MonoBehaviour {
    [SerializeField]private bool isupperBody; // using this script for upper body? set this true otherwise false
    [SerializeField]private bool islowerBody; // using this script for lower body? set this true otherwise false
    [SerializeField]private Xbox360Wired_InputController controller; //store controller from parentObj in here
    [SerializeField]private GameObject parent;
    [SerializeField]private float rotationSpeed;
    private float LeftAngle; // for storing left stick angle, probably can store it in another class?
    private float rightAngle;// for storing right stick angle.

    void Start()
    {
    }

    void Update()
    {
        if (isupperBody)
        {
            // rotate body based on right stick angle
            UpdateAngle(1);
            CalculateAngle(rightAngle);
            //Debug.Log(rightAngle);
        }
        if(islowerBody)
        {
            //rotate body based on left stick angle
            UpdateAngle(0);
            CalculateAngle(LeftAngle);
            //Debug.Log(LeftAngle);
        }
        if(!islowerBody && !isupperBody)
        {
            Debug.Log("boolean is not set, you dingus!");
        }

    }
    private void UpdateAngle(int wichStick)// for updating angles (0 = left, 1 = right, 2 = both)
    {
        if (controller != null)
        {
            switch (wichStick)// don't update both if you don't need to should save some performance i guess?
            {
                case 0:
                    LeftAngle = controller.leftStickAngle;
                    break;
                case 1:
                    rightAngle = controller.rightStickAngle;
                    break;
                case 2:
                    rightAngle = controller.rightStickAngle;
                    LeftAngle = controller.leftStickAngle;
                    break;
            }
        }
        else
        {
            ControllerNullCheck();
        }
    }

    private void ControllerNullCheck()
    {
        if(controller == null)
        {
            controller = parent.GetComponent<Xbox360Wired_InputController>();
        }
    }
   private void CalculateAngle(float incomingRotation)
    {
        Quaternion rot = Quaternion.Euler(0f, incomingRotation-90f, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
        //Debug.Log(rot);
        //rotate axis based on incoming calculated angle
    }
}
