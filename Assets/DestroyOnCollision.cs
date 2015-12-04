using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
