using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController Controller;
    public Transform Camera ;

    // Also, known as "speed"
    private const float _StepSize = 20.0f;
    private Vector3 _Step;

    private void FixedUpdate()
    {
        _Step.Set(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        _Step = Camera.TransformDirection(_Step);
        Controller.SimpleMove(_Step*_StepSize);    
    }
}
