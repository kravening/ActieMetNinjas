using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{

    public float maximumDamage = 120f;
    public float minimumDamage = 60f;

    public float flashIntensity = 3f;
    public float fadeSpeed = 10f;

    private LineRenderer _lazerLine;
    private Light _lazerLight;
    private SphereCollider _sphereCol;
    private Transform _player;
    private bool _shooting;
    private float _scaledDamage;

    void Awake()
    {
        _lazerLine = GetComponentInChildren<LineRenderer>();
        _lazerLight = GetComponentInChildren<Light>();
        _sphereCol = GetComponent<SphereCollider>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
