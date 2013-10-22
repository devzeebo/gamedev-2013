using UnityEngine;
using System.Collections;

public class InteractionGrid : MonoBehaviour
{
    private GameObject[,] gameObjects;

    public int GridSize;

    public GameObject Menu;

    public void Start()
    {
        Bounds bounds = GameObject.Find("Terrain").GetComponent<MeshRenderer>().bounds;
        gameObjects = new GameObject[getGridCell(bounds.size.x), getGridCell(bounds.size.y)];
    }

    public void OpenMenuAt(Vector3 position)
    {
        GameObject obj = gameObjects[getGridCell(position.x), getGridCell(position.z)];
        if (obj != null)
        {
            obj.GetComponent<OnTouchObject>().OnTouch();
        }
        else
        {
            GameObject temp = (GameObject)Instantiate(Menu, position, Quaternion.identity);
            temp.AddComponent<Menu>();
            temp.GetComponent<Menu>().Reference = gameObject;

            CameraController.createdMenu = temp.GetComponent<Menu>();
        }
    }

    int getGridCell(float value)
    {
        return (int)(value / GridSize);
    }
}
