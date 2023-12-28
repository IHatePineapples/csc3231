using UnityEngine;

public class RotateSoldier : MonoBehaviour
{
    [SerializeField]
    float OrbitRadius;

    float _Direction;

    private readonly float tau = 2 * Mathf.PI;

    void Rotate()
    {
        float _Time = _Direction * Time.realtimeSinceStartup / tau * 2;
        transform.localPosition = new Vector3(transform.localPosition.x, OrbitRadius * Mathf.Sin(_Time), OrbitRadius * Mathf.Cos(_Time));
    }

    /*
     * Instantiate `_Direction`
     * Random/bogus numbers to make the rotation different at each start/restart
     * Calculated through: `{-1,1} * ]1,2[`
     *  where `{-1,1}` is either `-1` or `1`; `]1,2[` is a float in that (exclusive) interval.
     */
    void SetupDirection() => _Direction = (Random.value <= 0.5f ? -1.0f : 1.0f) * (Random.value + 1);

    void Start() => SetupDirection();

    void FixedUpdate() => Rotate();

}
