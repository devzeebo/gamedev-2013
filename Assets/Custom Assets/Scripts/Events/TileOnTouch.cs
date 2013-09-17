using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TileOnTouch : OnTouchObject
{
    public GameObject MenuTemplate;

    public override void OnTouch()
    {
        base.OnTouch();

        GameObject temp = (GameObject)Instantiate(MenuTemplate, transform.position, transform.rotation);
        temp.AddComponent<Menu>();
        temp.GetComponent<Menu>().Reference = gameObject;

        CameraController.ActiveMenu = temp.GetComponent<Menu>();
    }
}