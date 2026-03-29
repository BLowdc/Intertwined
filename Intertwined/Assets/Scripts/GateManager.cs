using UnityEngine;

public class GateManager : MonoBehaviour
{
    public PressurePlate plate1;
    public PressurePlate plate2;
    public PressurePlate plate3;
    public GameObject gate;

    void Start()
    {
        gate.SetActive(true);
    }

    // Opens gate if all 3 pressure plates are activated
    void Update()
    {
        if (plate1.IsPressed && plate2.IsPressed && plate3.IsPressed)
        {
            gate.SetActive(false);
        }
    }
}