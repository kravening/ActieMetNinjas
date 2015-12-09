using UnityEngine;
using System.Collections;

public class MpOnConnect : MonoBehaviour {

	private Vector3 position;
	void OnJoinedRoom()
	{
		CreatePlayerObject();
	}

	void CreatePlayerObject()
	{
		position = Vector3.zero;
		GameObject newPlayerObject = PhotonNetwork.Instantiate("PlayerTank", position, Quaternion.identity, 0);
		
	}
}
