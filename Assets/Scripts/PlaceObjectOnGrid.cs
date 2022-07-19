using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{

    public Transform gridCellPrefab;
    public Transform cube;
    public Vector3 smoothMousePosition;
    public Transform onMousePrefabe;

   [SerializeField] private int height;
    [SerializeField] int width;
    private Node[,] nodes;
    private Plane plane;
    private Vector3 mousePosition;
    void Start()
    {
        CreateGrid();
        plane = new Plane(inNormal: Vector3.up, inPoint: transform.position);
    }


    void GetMousePositionOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(plane.Raycast(ray, out var enter))
        {
            mousePosition = ray.GetPoint(enter);

            smoothMousePosition = mousePosition;
            mousePosition.y = 0;
            mousePosition = Vector3Int.RoundToInt(mousePosition);

        }    

    }    

    public void onMouseClickOnUI()
    {
        if(onMousePrefabe==null)
        {
            onMousePrefabe = Instantiate(cube, mousePosition, Quaternion.identity);
        }    


    }    
    private void CreateGrid()
    {
        nodes = new Node[width, height];
        var name = 0;


        for(int i=0; i<width;i++)
        {
            for(int j=0;j<height;j++)
            {
                Vector3 worldPosition = new Vector3(x:i, y:0,z: j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell" + name;
                nodes[i, j] = new Node(isPlacable: true, worldPosition, obj);
                name++;



            }
        }    

    }

    // Update is called once per frame
    void Update()
    {
        GetMousePositionOnGrid();
    }


    public class Node
    {
        public bool isPlacable;
        public Vector3 cellPosition;
        public Transform obj;


        public Node (bool isPlacable, Vector3 cellPosition, Transform obj)
        {
            this.isPlacable = isPlacable;
            this.cellPosition = cellPosition;
            this.obj = obj;

        }

    }

}
