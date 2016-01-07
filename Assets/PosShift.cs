using UnityEngine;
using System.Collections;

public class PosShift : MonoBehaviour {
	[SerializeField]public float shiftMultiplier = 5f;
	[SerializeField]private GameObject _player;
	private Transform _neutralPos;
	private float _stickX;
	private float _stickY;

	private Xbox360Wired_InputController _getStick;
	// Use this for initialization
	void Start () {
		_neutralPos = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (_player != null) {
			GetRightStickValue();
			TrackPos ();
			ChangePos();
		} else {
			Debug.Log("no reference to the player");
		}


	}


	void TrackPos(){
		Transform ParentTransform = _player.transform;
		transform.position = ParentTransform.position;
	}

	void GetRightStickValue(){
		if (_getStick == null) {
			_getStick = _player.GetComponent<Xbox360Wired_InputController> ();
		} else {
			_stickX = _getStick.rightStickX;
			_stickY = _getStick.rightStickY;
		}
	}

	void ChangePos(){
		float newXPos = _neutralPos.position.x + _stickX * shiftMultiplier;
		float newZPos = _neutralPos.position.z + _stickY * shiftMultiplier;
		Vector3 newPos = new Vector3(newXPos,_neutralPos.position.y,newZPos);
		transform.position = newPos;
	}
}
