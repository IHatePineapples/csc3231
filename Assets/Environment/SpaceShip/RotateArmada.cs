using Unity.Collections;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class RotateArmada : MonoBehaviour
{
    float _Time;
    [SerializeField]
    float OrbitRadius;
    [SerializeField]
    Vector3 Center;

    private readonly float tau = 2*Mathf.PI;

    void FixedUpdate()
    {
        _Time = Time.realtimeSinceStartup / tau;
        transform.position = new Vector3(Center.x + OrbitRadius * Mathf.Cos(_Time), Center.y , Center.z + OrbitRadius * Mathf.Sin(_Time));
        transform.LookAt(Center);
    }
}
