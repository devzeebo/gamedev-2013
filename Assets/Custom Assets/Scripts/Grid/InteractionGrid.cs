using UnityEngine;
using System.Collections;

public class InteractionGrid : MonoBehaviour
{
    private GameObject[,] gameObjects;

    public int GridSize;

    public GameObject Menu;
    Menu menu;

    Menu activeMenu;

    public GameObject Terrain;

    public void Start()
    {
        Bounds bounds = Terrain.GetComponent<TerrainCollider>().bounds;
        gameObjects = new GameObject[getGridCell(bounds.size.x), getGridCell(bounds.size.z)];

        Debug.Log("Size: " + getGridCell(bounds.size.x) + " : " + getGridCell(bounds.size.z));

        menu = Menu.GetComponent<Menu>();
    }

    public Menu OpenMenuAt(Vector2 screenPosition)
    {
        RaycastHit hitInfo;
        Terrain.collider.Raycast(Camera.main.ScreenPointToRay(new Vector3(screenPosition.x, screenPosition.y, 0)),
            out hitInfo, 1000);
        Vector3 position = hitInfo.point;

        int x = getGridCell(position.x - Terrain.transform.position.x);
        int y = getGridCell(position.z - Terrain.transform.position.z);

        GameObject obj = gameObjects[x, y];

        if (obj != null)
        {
            activeMenu = obj.GetComponentInChildren<Menu>().ShowMenuAt(position);
        }
        else
        {
            activeMenu = menu.ShowMenuAt(position);
        }

        activeMenu.gridPosition = new Vector2(x, y);
        activeMenu.initialPosition = screenPosition;
        activeMenu.worldPosition = position;

        return activeMenu;
    }

    public void CreateObject(Vector2 position)
    {
        if (Vector2.Distance(position, activeMenu.initialPosition) > activeMenu.DeadZone)
        {
            int x = (int)(activeMenu.gridPosition.x);
            int y = (int)(activeMenu.gridPosition.y);

            GameObject obj = gameObjects[x, y];

            GameObject spawn = activeMenu.GetIcon(position).GetComponent<Icon>().SpawnObject;

            if (obj != null)
            {
                BaseProperties props = obj.GetComponent<BaseProperties>();
                props.Module = (GameObject)Instantiate(spawn,
                    obj.transform.position + props.SpawnPosition,
                    Quaternion.identity);
            }
            else
            {
                gameObjects[x, y] =
                    (GameObject)Instantiate(spawn,
                    getGridPosition(activeMenu.gridPosition),
                    Quaternion.identity);
            }
        }

        activeMenu.Reset();
        activeMenu = null;
    }

    Vector3 getGridPosition(Vector2 grid)
    {
        Vector3 worldPos = new Vector3(grid.x * GridSize + GridSize / 2, 0, grid.y * GridSize + GridSize / 2);
        worldPos += Terrain.transform.position;

        return worldPos;
    }

    int getGridCell(float value)
    {
        return (int)(value / GridSize);
    }
}
