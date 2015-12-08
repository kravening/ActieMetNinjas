using UnityEngine;
using System.Collections;

public class BulletVelocity : MonoBehaviour {
    [SerializeField]private float speed;

	void Update () {
        transform.position += transform.forward * speed;
    }
}
