using UnityEngine;
using System.Collections;

public class ObjectFollower : MonoBehaviour {
	[SerializeField]private Transform objectToFollow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform newTransform = objectToFollow.transform;
		transform.position = newTransform.position;
	}
}
