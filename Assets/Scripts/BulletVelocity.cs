using UnityEngine;
using System.Collections;

public class BulletVelocity : MonoBehaviour {
    [SerializeField]private float speed;

	void FixedUpdate () {
        transform.position += transform.right * speed;
    }
}
