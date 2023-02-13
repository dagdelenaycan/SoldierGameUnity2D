using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, damping) + offset;
    }
}
