using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    Rect p1PortraitRect = new Rect(0,0, 200, 200);
    Texture p1PortraitTexture = Resources.Load<Texture2D>("Portraits/player1.jpg");
	void OnGUI()
    {
        GUI.DrawTexture(p1PortraitRect, p1PortraitTexture);
    }
}
