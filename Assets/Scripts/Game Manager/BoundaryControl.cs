using UnityEngine;

public class BoundaryControl : MonoBehaviour
{
    [SerializeField]
    private float x1, x2, y1, y2, z1, z2;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, x1, x2),
            Mathf.Clamp(transform.position.y, y1, y2),Mathf.Clamp(transform.position.z,z1,z2));
    }
}
