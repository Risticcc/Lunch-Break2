using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragRigidBody : MonoBehaviour{
// {
//     private bool isDragged = false;
//     private Vector3 mouseDragStartPosition;
//     private Vector3 objectDragStartPosition;
//     private Vector3 veleocity = Vector3.zero;

//     private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
//     private Rigidbody rb;
//     private bool used = false;

//     [SerializeField] private float mouseDragPhysicsSpeed = 10f;

//     [SerializeField] private float mouseDragSpeed = 0.1f;



//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     private void OnMouseDown()
//     {
//          Debug.Log("DRAG");
//         isDragged = true;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit))
//         {
//             if (hit.collider != null && ( hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") || hit.collider.gameObject.GetComponent<IDrag>() != null))
//             {
//                 if(CanDrag(hit.collider.gameObject))
//                     StartCoroutine(DragUpdate(hit.collider.gameObject));
//                 else 
//                 {
//                     //animation you dont have enough money
//                     Debug.Log("Nemas para");
//                     return;
//                 }
//             }
//         }       
//     }

//     private IEnumerator DragUpdate(GameObject clickedObject)
//     {
//         if (isDragged)
//         {
//             clickedObject.TryGetComponent<Rigidbody>(out var rb);
//             clickedObject.TryGetComponent<IDrag>(out var iDragComponent);
//             iDragComponent?.onStartDrag();

//             float initialDistance = Vector3.Distance(clickedObject.transform.position, Camera.main.transform.position);

//             while (Input.mousePosition !=null)
//             {
//                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//                 if (rb != null)
//                 {
//                     Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
//                     rb.velocity = direction * mouseDragPhysicsSpeed;
//                     yield return waitForFixedUpdate;

//                 }    
//                 else
//                 {
//                     clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint(initialDistance), ref veleocity, mouseDragSpeed);
//                     yield return null;

//                 }
//             }

//             iDragComponent?.onEndDrag();
//         }
//     }

//     private void OnMouseUp()
//     {
      
//         rb.useGravity = true;
//         // rb.velocity = Vector3.zero;
//         isDragged = false;
//     }

 

//     public void onStartDrag()
//     {
//         rb.useGravity = false;
//         if (!used)
//         {
//             used = true;
//             transform.position = transform.position - new Vector3(1.2f, 0, 0);
//         }
//     }



       
            
//     }
// }

    public float forceAmount = 500;

    Rigidbody selectedRigidbody;
    Camera targetCamera;
    Vector3 originalScreenTargetPosition;
    Vector3 originalRigidbodyPos;
    float selectionDistance;

    private bool used = false;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!targetCamera)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            //Check if we are hovering over Rigidbody, if so, select it
            selectedRigidbody = GetRigidbodyFromMouseClick();
        }
        if (Input.GetMouseButtonUp(0) && selectedRigidbody)
        {
            //Release selected Rigidbody if there any
            selectedRigidbody.useGravity = true;
            selectedRigidbody = null;
         
        }
    }

    void FixedUpdate()
    {
        if (selectedRigidbody)
        {
            selectedRigidbody.useGravity = false;
            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;
            selectedRigidbody.velocity = (originalRigidbodyPos + mousePositionOffset - selectedRigidbody.transform.position) * forceAmount * Time.deltaTime;
        }
    }

    Rigidbody GetRigidbodyFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if (hit)
        {
                
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            {
                 Debug.Log(hitInfo.collider.gameObject);
                if(!CanDrag(hitInfo.collider.gameObject))
                {
                    Debug.Log("Nemas para");
                    //animation you dont have enough money
                    return null;
                }

                selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
                originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));

                  
                originalRigidbodyPos = hitInfo.collider.transform.position - new Vector3(0.9f, 0, 0);
              

                return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
            }
        }

        return null;
    }

    //Get the price and check if player have enough money on bank account
    //Function returns true or false, depends on can player buy item
    private bool CanDrag(GameObject item)
    {
        Item ic = item.GetComponent<ItemController>().item;
        

         //Debug.Log($"PRICE {price} AMOUNT {ScoreManager.Instance.Score.score}");
       return ScoreManager.Instance.MoneySpent(ic.price, ic.boost);
       //return false;
    }
   

}
