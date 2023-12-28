using UnityEngine;

public class Orbit : MonoBehaviour
{
    private readonly float SlowDown = 1.0f/10.0f; // SlowDown day/time cycle for viewing pleasure.
    private float _Time;
    [SerializeField]
    private Light Sun;

    void FixedUpdate()
    {
        _Time = Time.realtimeSinceStartup * SlowDown;

        Sun.intensity = Mathf.Sin(_Time); // Rotation period 
        transform.position = new Vector3(Mathf.Cos(_Time), Mathf.Sin(_Time)); // Basically make it orbit around (0,0,0).
        transform.LookAt(Vector3.zero); // Simulate the sun, which is a sphere, not a hand-held torch.
    }
}
