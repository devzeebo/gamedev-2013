using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Menu : MonoBehaviour
{
    public static float ANGLE_OFFSET = Mathf.PI / 2;
    public static Vector3 HIDDEN = Vector3.up * 1000;

    public GameObject[] Items;
    float angle;

    public float DeadZone = 2f;

    [HideInInspector]
    public Vector2 initialPosition;
    [HideInInspector]
    public Vector3 worldPosition;
    [HideInInspector]
    public Vector2 gridPosition;

    void Start()
    {
        angle = (float)(2 * Mathf.PI / Items.Length);
        for (int i = 0; i < Items.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(Items[i], 5 * new Vector3(Mathf.Cos(angle * i + ANGLE_OFFSET), 0, Mathf.Sin(angle * i + ANGLE_OFFSET)), Items[i].transform.localRotation);

            obj.transform.parent = transform;
        }

        Reset();
    }

    public void Reset()
    {
        transform.Translate(HIDDEN - transform.localPosition, Space.World);
    }

    public Menu ShowMenuAt(Vector3 position)
    {
        transform.Translate(position - transform.localPosition, Space.World);

        return this;
    }

    public GameObject GetIcon(Vector2 position)
    {
        float calcAngle = (getAngle(initialPosition, position) - ANGLE_OFFSET + angle / 2);
        if (calcAngle < 0)
        {
            calcAngle += Mathf.PI * 2;
        }
        int idx = (int)(calcAngle / angle);

        return Items[idx];
    }

    public float getAngle(Vector2 one, Vector2 two)
    {
        float angle = Mathf.Atan2(two.y - one.y, two.x - one.x);
        if (angle < 0)
        {
            angle += Mathf.PI * 2;
        }
        return angle;
    }
}