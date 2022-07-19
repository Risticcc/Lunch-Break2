using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour, IDrag
{
    private Rigidbody rb;
    private bool used = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void onEndDrag()
    {
        rb.useGravity = true;
       // rb.velocity = Vector3.zero;
    }

    public void onStartDrag()
    {
        rb.useGravity = false;
        if (!used)
        {
            used = true;
            transform.position = transform.position - new Vector3(1.2f, 0, 0);
        }
    }

}
