using UnityEngine;
using System.Collections;

public class LightIntensity : MonoBehaviour {
	private Light _light;
	private float _baseIntensity;
	private float _baseRange;
	[SerializeField]private float _startIntensity;
	[SerializeField]private float _startRange;
	[SerializeField]private float _intensityFallOff;
	[SerializeField]private float _rangeFallOff;
	// Use this for initialization
	void Start () {
		_light = this.gameObject.GetComponent<Light>();
		_baseIntensity = _light.intensity;
		_baseRange = _light.range;         //sets value to fall off to


		_light.intensity = _startIntensity;
		_light.range = _startRange;

	}

	void Update(){
		if (_light.intensity >= _baseIntensity) {
			_light.intensity -= _intensityFallOff * Time.deltaTime;
		}
		if (_light.range >= _baseRange) {
			_light.range -= _rangeFallOff * Time.deltaTime;
		}
	}
}
