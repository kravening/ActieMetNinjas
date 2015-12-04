using UnityEngine;
using System.Collections;

public class BulletVelocity : MonoBehaviour {
    [SerializeField]private float speed;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
	void FixedUpdate () {
        rb.AddForce(transform.right * speed, ForceMode.Force);
    }
}
