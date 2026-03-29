using System.Collections;
using UnityEngine;

public class SpawnBridge : MonoBehaviour
{
    public PressurePlate pressurePlateA;
    public PressurePlate pressurePlateB;
    public GameObject bridge;

    void Start()
    {
        bridge.SetActive(true);
    }
    void Update()
    {
        // Spawn bridge in first level when either pressure plate is activated
        if (pressurePlateA.IsPressed || pressurePlateB.IsPressed)
        {
            bridge.SetActive(false);
        }
        else
        {
            bridge.SetActive(true);
        }
    }
}
