using UnityEngine;

public class Spotlight : MonoBehaviour
{
    [SerializeField]
    Light Sun;
    [SerializeField]
    int DragFactor; // How much we want the "spotlight" to drag behind player

    private Vector3[] pastPositions;
    private int PreviousPositionIndex = 0;
    private int CurrentPositionIndex = 0;
    private bool Ready = false;

    [SerializeField]
    Light Projector;
    [SerializeField]
    Transform Player;
    [SerializeField]
    LensFlare Flare;

    void Start()
    {
        Projector.transform.LookAt(Player.transform.position);
        if (DragFactor == 0) ++DragFactor;
        pastPositions = new Vector3[DragFactor];
    }

    void FixedUpdate()
    {
        pastPositions[PreviousPositionIndex++] = Player.position;
        PreviousPositionIndex %= DragFactor;


        if (PreviousPositionIndex == (DragFactor - 1)) Ready = true;
        if (!Ready) return;

        Projector.transform.LookAt(pastPositions[CurrentPositionIndex++]);
        CurrentPositionIndex %= DragFactor;
        Projector.intensity = Mathf.Clamp(-Sun.transform.position.y, 0, 1);
        Flare.brightness = Projector.intensity;
    }
}
