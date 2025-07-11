using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1.0f;

    private Vector3 offset = new Vector3(0, 0, -10);

    private Vector3 targetPos;

    private void Start()
    {
        if (target == null) return;

        // offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }

}
