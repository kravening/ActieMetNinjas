using UnityEngine;
using System.Collections;

public class AimLine : MonoBehaviour {
	[SerializeField]private GameObject _marker;
	[SerializeField]private GameObject _player;
	[SerializeField]private float _lineLength;
	[SerializeField]private float _maxLineLength;
	private LineRenderer _lineRenderer;
	// Use this for initialization
	void Start () {
		_lineRenderer = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (_marker.transform.position,_player.transform.position) * _lineLength;
		float clampedDistance = Mathf.Clamp (distance, 0,_maxLineLength);
		_lineRenderer.SetPosition(0,new Vector3(0,-_player.transform.position.y,0));
		_lineRenderer.SetPosition(1,new Vector3(0,-_player.transform.position.y,clampedDistance));
	}
}
