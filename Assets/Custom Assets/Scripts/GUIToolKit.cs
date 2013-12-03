using UnityEngine;
using System.Collections.Generic;
public static class GuiToolkit
{
    private static GUIStyle labelStyle;
    
	public static Rect Rect(float x, float y, float w, float h)
    {
        return new Rect(x, Screen.height - y, w, h);
    }
    
	public static void Label(Vector2 pos, string text)
    {
        if (labelStyle == null)
        {
            labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.clipping = TextClipping.Overflow;
            labelStyle.wordWrap = false;
            labelStyle.padding = new RectOffset(4, 0, 0, 0);
        }
        GUI.Label(new Rect(pos.x, pos.y, 3, 0), text, labelStyle);
    }
    
	public static float CenterWidth(float width)
    {
        return Screen.width / 2 - width / 2;
    }
}