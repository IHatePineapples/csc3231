using UnityEngine;

/* Used to create a permanent deformation after a certain amount of seconds since startup.
 * These deformations are common in comets, such as the one this world is taking place in.
 * Note: Unfinished
 */
public class PermanentChange : MonoBehaviour
{
    [SerializeField]
    Terrain Terrain;
    [SerializeField]
    int Seconds;
    [SerializeField]
    int MaxHeight;
    [SerializeField]
    int MinHeight;
    [SerializeField]
    int Area;
    [SerializeField]
    int HowFarFromPlayer;

    [SerializeField]
    Transform Player;

    float Height;
    bool Done = false;

    void Start() => Height = Random.Range(MinHeight, MaxHeight);

    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup < Seconds) return;
        if (Done) return;

        float[,] heights = Terrain.terrainData.GetHeights((int)Player.position.x + HowFarFromPlayer, (int)Player.position.z + HowFarFromPlayer, Area, Area);

        for (int i = 0; i < Area; i++)
            for (int j = 0; j < Area; j++)
                heights[i, j] += Height;
        Debug.Log("Done");
        Done = true;
    }
}
