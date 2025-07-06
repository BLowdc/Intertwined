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

