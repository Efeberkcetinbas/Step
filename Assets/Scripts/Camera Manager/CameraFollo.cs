
using UnityEngine;

public class CameraFollo : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Vector3 distance;

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime);
    }
}
