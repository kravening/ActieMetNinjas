using UnityEngine;
using System.Collections;

public class CorridorCheck : MonoBehaviour {
    public bool isInCorridor = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("fuck");
        if(other.gameObject.tag == "Corridor")
        {
            Debug.Log("ayy");
            isInCorridor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Corridor")
        {
            isInCorridor = false;
        }
    }
}
