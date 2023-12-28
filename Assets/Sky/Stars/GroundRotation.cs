using UnityEngine;

public class GroundRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update() { RenderSettings.skybox.SetFloat("_Rotation", Time.timeSinceLevelLoad * (1.0f/5.0f)); }
}
