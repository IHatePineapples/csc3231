using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    Transform Head;
    [SerializeField]
    Transform Body;
    private float x = 0.0f;
    private float y = 0.0f;
    void Update()
    {
        y += Input.GetAxis("Mouse X");
        if ( Math.Abs(x - Input.GetAxis("Mouse Y")) < 90 ) x -= Input.GetAxis("Mouse Y");

        Head.eulerAngles = new Vector3(x, y, 0.0f);
        Body.eulerAngles = new Vector3(0.0f, y, 0.0f);
    }
}
