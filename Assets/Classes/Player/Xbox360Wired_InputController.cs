using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Xbox360Wired_InputController : MonoBehaviour {
	private bool playerIndexSet = false;
	private PlayerIndex playerIndex;
	private GamePadState state;
	private GamePadState prevState;

    //behaviourModifiers
    [SerializeField]private float deadZoneAmount;
    [SerializeField]private float triggerPressedSensitivity;

    //for reading
    public float leftStickAngle;
    public float rightStickAngle;
    public bool rightStickActive;
    public bool leftStickActive;
    public float leftStickX;
    public float leftStickY;
    public float rightStickX;
    public float rightStickY;

    public bool GUION;

    //bools for buttons
    private bool leftShoulder = false;
    private bool rightShoulder = false;
    private bool leftTrigger = false;
    private bool rightTrigger = false;

    private bool aButton = false;
    private bool bButton = false;
    private bool xButton = false;
    private bool yButton = false;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		FindController ();
        SetState();
        CheckForButtonPress();
        CheckForButtonRelease();
        ButtonActions(); //do things like shooting here

        if (DeadZoneCheckRight())
        {
            rightStickX = state.ThumbSticks.Right.X;//holds x value of stick
            rightStickY = state.ThumbSticks.Right.Y;//holds y value of stick
            rightStickAngle = CalculateRotation(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y); // calculates a angle for the right stick
        }
        else
        {
            rightStickX = 0f; // set it back to 0 if inside the deadzone
            rightStickY = 0f; // set it back to 0 if inside the deadzone
        }
        if (DeadZoneCheckLeft())
        {
            leftStickX = state.ThumbSticks.Left.X;//holds x value of stick
            leftStickY = state.ThumbSticks.Left.Y;//holds y value of stick
            leftStickAngle = CalculateRotation(state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y);   // calculates a angle for the left stick
        }
        else
        {
            leftStickX = 0f; // set it back to 0 if inside the deadzone
            leftStickY = 0f; // set it back to 0 if inside the deadzone
        }

    }
    private void ButtonActions()
    {
        if(leftShoulder == true)
        {
            GetComponent<WeaponController>().ManualReload(0);
        }
        if (rightShoulder == true)
        {
            GetComponent<WeaponController>().ManualReload(1);
        }
        if(leftTrigger == true)
        {
            GetComponent<WeaponController>().Attack(0);
        }
        if(rightTrigger == true)
        {
            GetComponent<WeaponController>().Attack(1);
        }
        if (aButton == true)
        {

        }
        if (bButton == true)
        {

        }
        if (xButton == true)
        {

        }
        if (yButton == true)
        {

        }
    }
    private void CheckForButtonPress() // check if a button was pressed this frame
    {
        //shoulders
        if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            leftShoulder = true;
        }
        if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed)
        {
            rightShoulder = true;
        }
        if (prevState.Triggers.Left >= triggerPressedSensitivity && leftTrigger == false)
        {
            leftTrigger = true;
        }
        if (prevState.Triggers.Right >= triggerPressedSensitivity && rightTrigger == false)
        {
            rightTrigger = true;
        }



        // buttons
        if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
        {
            aButton = true;
        }
        if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed)
        {
            bButton = true;
        }
        if (prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed)
        {
            xButton = true;
        }
        if (prevState.Buttons.Y == ButtonState.Released && state.Buttons.Y == ButtonState.Pressed)
        {
            yButton = true;
        }
    }
    private void CheckForButtonRelease() // check if a button is released this frame
    {
        //shoulders
        if (prevState.Buttons.LeftShoulder == ButtonState.Pressed && state.Buttons.LeftShoulder == ButtonState.Released)
        {
            leftShoulder = false;
        }
        if (prevState.Buttons.RightShoulder == ButtonState.Pressed && state.Buttons.RightShoulder == ButtonState.Released)
        {
            rightShoulder = false;
        }

        if (prevState.Triggers.Left <= triggerPressedSensitivity && leftTrigger == true)
        {
            leftTrigger = false;
        }
        if (prevState.Triggers.Right <= triggerPressedSensitivity && rightTrigger == true)
        {
            rightTrigger = false;
        }

        if (prevState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released)
        {
            aButton = false;
        }
        if (prevState.Buttons.B == ButtonState.Pressed && state.Buttons.B == ButtonState.Released)
        {
            bButton = false;
        }
        if (prevState.Buttons.X == ButtonState.Pressed && state.Buttons.X == ButtonState.Released)
        {
            xButton = false;
        }
        if (prevState.Buttons.Y == ButtonState.Pressed && state.Buttons.Y == ButtonState.Released)
        {
            yButton = false;
        }
    }

    public bool DeadZoneCheckRight()
    {
        if (state.ThumbSticks.Right.X >= deadZoneAmount || state.ThumbSticks.Right.X <= -deadZoneAmount || state.ThumbSticks.Right.Y >= deadZoneAmount || state.ThumbSticks.Right.Y <= -deadZoneAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeadZoneCheckLeft()
    {
        if (state.ThumbSticks.Left.X >= deadZoneAmount || state.ThumbSticks.Left.X <= -deadZoneAmount || state.ThumbSticks.Left.Y >= deadZoneAmount || state.ThumbSticks.Left.Y <= -deadZoneAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FindController(){
		// Find a PlayerIndex, for a single player game
		// Will find the first controller that is connected and use it
		if (!playerIndexSet || !prevState.IsConnected) {
			for (int i = 0; i < 4; ++i) {
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState (testPlayerIndex);
				if (testState.IsConnected) {
					Debug.Log (string.Format ("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}
    }
    private void SetState()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
    }

    private float CalculateRotation(float X, float Y) // calculates angle based on incoming X & Y values;
    {
        float angle = Mathf.Atan2(X, Y) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        return angle;
    }

    void OnGUI() //usefull for checking if everything works
    {
        string text = "ayy";
        if (GUION)
        {
            text = "ayylmao\n";
            text += string.Format("IsConnected {0} Packet #{1}\n", state.IsConnected, state.PacketNumber);
            text += string.Format("\tTriggers {0} {1}\n", state.Triggers.Left, state.Triggers.Right);
            text += string.Format("\tD-Pad {0} {1} {2} {3}\n", state.DPad.Up, state.DPad.Right, state.DPad.Down, state.DPad.Left);
            text += string.Format("\tButtons Start {0} Back {1} Guide {2}\n", state.Buttons.Start, state.Buttons.Back, state.Buttons.Guide);
            text += string.Format("\tButtons LeftStick {0} RightStick {1} LeftShoulder {2} RightShoulder {3}\n", state.Buttons.LeftStick, state.Buttons.RightStick, state.Buttons.LeftShoulder, state.Buttons.RightShoulder);
            text += string.Format("\tButtons A {0} B {1} X {2} Y {3}\n", state.Buttons.A, state.Buttons.B, state.Buttons.X, state.Buttons.Y);
            text += string.Format("\tSticks Left {0} {1} Right {2} {3}\n", state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y, state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text);
        }
        else {
            text = "";
        }
    }
}
