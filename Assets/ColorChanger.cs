using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorChanger : MonoBehaviour
{
	private MeshRenderer _meshRenderer;
	[SerializeField]
	private List<Color> _colorList = new List<Color> ();
	//[SerializeField]
	//private List<Color> _colorListB = new List<Color> ();
	private int colorIndexA = 0;
	private int colorIndexB = 1;
	private Color _newColor;
	private bool _colorShiftRoutine = false;
	private float timer;
	private bool aOrB = true;// false is add B true = add A
	// Use this for initialization
	void Start ()
	{
		_meshRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer >= 1) {
			timer--;

			if(aOrB){
				colorIndexA++;
				aOrB = false;
				if(colorIndexA > _colorList.Count - 1){
					colorIndexA = 0;
				}
			}else{
				aOrB = true;
				colorIndexB++;
				if(colorIndexB > _colorList.Count - 1){
					colorIndexB = 0;
				}
			}
		}

		float lerp = Mathf.PingPong (Time.time, 1);
		_newColor = Color.Lerp (_colorList[colorIndexA], _colorList[colorIndexB], lerp);

		_meshRenderer.material.color = _newColor;
	}
}
