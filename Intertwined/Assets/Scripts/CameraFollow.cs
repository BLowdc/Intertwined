using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float lerpSpeed = 1.0f; // linear interpolation speed

    private Vector3 offset = new Vector3(0, 0, -10);

    private Vector3 targetPos;

    private void Start()
    {
        // checks if target exists

        if (target == null) return;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        // uses linear interpolation to make camera follow player smoothly

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }

}
