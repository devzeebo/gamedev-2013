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

	private Bounds Bounds;

	private Description desc;

    public void Start()
    {
        Bounds = Terrain.GetComponent<Collider>().bounds;
		gameObjects = new GameObject[getGridCell(Bounds.size.x), getGridCell(Bounds.size.z)];

		Debug.Log("Size: " + getGridCell(Bounds.size.x) + " : " + getGridCell(Bounds.size.z));

        menu = Menu.GetComponent<Menu>();
    }

    public Menu OpenMenuAt(Vector2 screenPosition)
    {
        RaycastHit hitInfo;
        Terrain.collider.Raycast(Camera.main.ScreenPointToRay(new Vector3(screenPosition.x, screenPosition.y, 0)),
            out hitInfo, 1000);
        Vector3 position = hitInfo.point;

        Debug.Log("Hit: " + position);

		int x = getGridCell(position.x + Bounds.size.x / 2);
		int y = getGridCell(position.z + Bounds.size.z / 2);

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
		desc = null;
        if (Vector2.Distance(position, activeMenu.initialPosition) > activeMenu.DeadZone)
        {
            int x = (int)(activeMenu.gridPosition.x);
            int y = (int)(activeMenu.gridPosition.y);

            GameObject obj = gameObjects[x, y];

            GameObject spawn = activeMenu.GetIcon(position).GetComponent<Icon>().SpawnObject;

            if (obj != null)
            {
                obj.GetComponent<BaseProperties>().SpawnModule(spawn);
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
        Vector3 worldPos = new Vector3(grid.x * GridSize + GridSize / 2 - Bounds.size.x / 2, 0, grid.y * GridSize + GridSize / 2 - Bounds.size.z / 2);
        worldPos += Terrain.transform.position;

        return worldPos;
    }

    int getGridCell(float value)
    {
        return (int)(value / GridSize);
    }

	public void displayToolTip(Vector2 position)
	{
		if (Vector2.Distance(position, activeMenu.initialPosition) > activeMenu.DeadZone)
		{
			desc = activeMenu.GetIcon(position).GetComponent<Icon>().SpawnObject.GetComponent<Description>();

		}
	}

	void OnGUI(){
		if(desc !=null)
		{
			GUI.Box (new Rect (0 ,0, Screen.width,25), desc.description);
		}
	}
}
