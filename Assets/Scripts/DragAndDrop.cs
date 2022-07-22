using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 objectDragStartPosition;

    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    [SerializeField]
    private float mouseDragPhysicsSpeed = 10f;

    [SerializeField]
    private float mouseDragSpeed = 0.1f;
    private Vector3 veleocity = Vector3.zero;

    private Rigidbody rb;
    private bool used = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        isDragged = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && (hit.collider.gameObject.CompareTag("Draggable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") || hit.collider.gameObject.GetComponent<IDrag>() != null))
            {
                Debug.Log("pls");
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }

        }

           
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        if (isDragged)
        {
                clickedObject.TryGetComponent<Rigidbody>(out var rb);
            clickedObject.TryGetComponent<IDrag>(out var iDragComponent);
            iDragComponent?.onStartDrag();

            float initialDistance = Vector3.Distance(clickedObject.transform.position, Camera.main.transform.position);

            while (Input.mousePosition !=null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (rb != null)
                {
                    Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                    rb.velocity = direction * mouseDragPhysicsSpeed;
                    yield return waitForFixedUpdate;

                }    
                else
                {
                    clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint(initialDistance), ref veleocity, mouseDragSpeed);
                    yield return null;

                }


            }
            iDragComponent?.onEndDrag();

        }
    }

    private void OnMouseUp()
    {
      
        rb.useGravity = true;
        // rb.velocity = Vector3.zero;
        isDragged = false;
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
