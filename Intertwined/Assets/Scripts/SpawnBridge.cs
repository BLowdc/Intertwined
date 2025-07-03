using System.Collections;
using UnityEngine;

public class SpawnBridge : MonoBehaviour
{
    public GameObject bridge;
    private PressurePlate pressurePlate;

    void Start()
    {
        pressurePlate = GetComponent<PressurePlate>();
        bridge.SetActive(true);
    }
    void Update()
    {
        if (pressurePlate.IsPressed)
        {
            bridge.SetActive(false);
        }
        else
        {
            bridge.SetActive(true);
        }
    }
}

