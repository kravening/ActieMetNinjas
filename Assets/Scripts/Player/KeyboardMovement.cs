using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController characterController;
	[SerializeField]
	private float currentMovementSpeed = 5f;

	//multiplayervars
	PhotonView m_PhotonView;
	PhotonTransformView m_TransformView;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		m_PhotonView = GetComponent<PhotonView>();
		m_TransformView = GetComponent<PhotonTransformView>();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_PhotonView.isMine == true)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			if (moveHorizontal > 0f || moveHorizontal < 0f || moveVertical > 0f || moveVertical < 0f)
			{
				moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
				moveDirection = transform.TransformDirection(moveDirection);

				characterController.Move(moveDirection * currentMovementSpeed * Time.deltaTime);
			}
		}
	}
}
