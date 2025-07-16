using UnityEngine;

public class GateManager : MonoBehaviour
{
    public PressurePlate plate1;
    public PressurePlate plate2;
    public PressurePlate plate3;
    public GameObject gate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if  (plate1.IsPressed && plate2.IsPressed && plate3.IsPressed)
        {
            gate.SetActive(false);
        }
    }
}
