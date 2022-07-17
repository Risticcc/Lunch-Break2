using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 _offset;

    public void Start()
    {
        _offset = transform.position - target.position;
    }


    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(target.position.x, transform.position.y, _offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 80 * Time.deltaTime);

    }
}
