using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    public GameObject _target;

    private float _moveSpeed = 2;
    private float _minDistance = 1;

    void Update()
    {
        //build in function to look at (the target)
        transform.LookAt(_target.transform.position);

        //when distance between this and target is bigger or equal to
        if (Vector3.Distance(transform.position, _target.transform.position) >= _minDistance)
        {
            //move to target
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        }
    }
}
