using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    public float viewAngle = 110f;
    public bool playerInSight;
    public Vector3 lastSighting;

    private Vector3 previousSighting;

    private NavMeshAgent _nav;
    private SphereCollider _sphereCol;

    private GameObject _player;

    void Awake()
    {
        _nav = GetComponent<NavMeshAgent>();
        _sphereCol = GetComponent<SphereCollider>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

    }

    //works
    void OnTriggerStay(Collider other)
    {
        //in collider
        if (other.gameObject == _player)
        {
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            //in line of sight
            if (angle < viewAngle * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction.normalized, out hit, _sphereCol.radius))
                {
                    if(hit.collider.gameObject == _player)
                    {
                        playerInSight = true;
                        lastSighting = _player.transform.position;
                    }
                }
            }

            //when enemy hears the player
            /*if(_player.speed > 5 || playerInSight.IsShooting)
            {
                if (CreatePath(_player.transform.position) <= _sphereCol.radius)
                {
                    lastSighting = _player.transform.position;
                }
            }*/
        }
    }
    
    
    float CreatePath(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();

        if (_nav.enabled)
            _nav.CalculatePath(targetPosition, path);
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0f;

        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        return pathLength;
    } 
}

