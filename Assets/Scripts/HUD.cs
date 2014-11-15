using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    const float PADDING     = .05f;

    const float PORTRAIT_WIDTH      = .25f - PADDING;
    const float PORTRAIT_HEIGHT     =  .8f;
    const float TEXT_HEIGHT         = .30f - PADDING;

    const float P1_X        = .10f;
    const float P1_Y        = .20f;
    const float P1_TEXT_Y   = .10f;

    const float P2_X        = .30f;
    const float P2_Y        = .20f;
    const float P2_TEXT_Y   = .10f;

    const float P3_X        = .50f;
    const float P3_Y        = .20f;
    const float P3_TEXT_Y   = .10f;

    const float P4_X        = .70f;
    const float P4_Y        = .20f;
    const float P4_TEXT_Y   = .10f;

    Rect p1PortraitRect;
    Rect p2PortraitRect;
    Rect p3PortraitRect;
    Rect p4PortraitRect;
    Rect p1TextRect;
    Rect p2TextRect;
    Rect p3TextRect;
    Rect p4TextRect;
    Texture2D p1PortraitTexture;
    Texture2D p2PortraitTexture;
    Texture2D p3PortraitTexture;
    Texture2D p4PortraitTexture;
    void Start()
    {
        p1PortraitRect = new Rect(0, 0, 0, 0);
        p2PortraitRect = new Rect(0, 0, 0, 0);
        p3PortraitRect = new Rect(0, 0, 0, 0);
        p4PortraitRect = new Rect(0, 0, 0, 0);
        p1PortraitTexture = Resources.Load<Texture2D>("Portraits/player1");
        p2PortraitTexture = Resources.Load<Texture2D>("Portraits/player2");
        p3PortraitTexture = Resources.Load<Texture2D>("Portraits/player3");
        p4PortraitTexture = Resources.Load<Texture2D>("Portraits/player4");
    }
	void OnGUI()
    {
        float guiX = 0;
        float guiY = .85f * Camera.current.pixelHeight;
        float guiWidth = Camera.current.pixelWidth;
        float guiHeight = Camera.current.pixelHeight - guiY;
        Debug.Log("Info: " + guiX + " " + guiY + " " + guiWidth + " " + guiHeight); 
        
        p1PortraitRect  = new Rect(
                            guiX + P1_X*guiWidth, 
                            guiY + P1_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            PORTRAIT_HEIGHT*guiHeight
                            );
        p1TextRect      = new Rect(
                            guiX + P1_X*guiWidth, 
                            guiY + P1_TEXT_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            TEXT_HEIGHT*guiHeight
                        );
        p2PortraitRect  = new Rect(
                            guiX + P2_X*guiWidth,
                            guiY + P2_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            PORTRAIT_HEIGHT*guiHeight
                        );
        p2TextRect      = new Rect(
                            guiX + P2_X*guiWidth, 
                            guiY + P2_TEXT_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            TEXT_HEIGHT*guiHeight
                        );
        p3PortraitRect  = new Rect(
                            guiX + P3_X*guiWidth,
                            guiY + P3_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            PORTRAIT_HEIGHT*guiHeight
                        );
        p3TextRect      = new Rect(
                            guiX + P3_X*guiWidth, 
                            guiY + P3_TEXT_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            TEXT_HEIGHT*guiHeight
                        );
        p4PortraitRect  = new Rect(
                            guiX + P4_X*guiWidth,
                            guiY + P4_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            PORTRAIT_HEIGHT*guiHeight
                        );
        p4TextRect      = new Rect(
                            guiX + P4_X*guiWidth, 
                            guiY + P4_TEXT_Y*guiHeight,
                            PORTRAIT_WIDTH*guiWidth,
                            TEXT_HEIGHT*guiHeight
                        );
        Debug.Log("Info: L: " + p1PortraitRect.xMin + " T: " + p1PortraitRect.yMin + " W: " + p1PortraitRect.width + " H: " + p1PortraitRect.height); 

        GUI.DrawTexture(p1PortraitRect, p1PortraitTexture, ScaleMode.ScaleToFit);
        GUI.DrawTexture(p2PortraitRect, p2PortraitTexture, ScaleMode.ScaleToFit);
        GUI.DrawTexture(p3PortraitRect, p3PortraitTexture, ScaleMode.ScaleToFit);
        GUI.DrawTexture(p4PortraitRect, p4PortraitTexture, ScaleMode.ScaleToFit);
        
        GUI.Label(p1TextRect, "Player 1");
        GUI.Label(p2TextRect, "Player 2");
        GUI.Label(p3TextRect, "Player 3");
        GUI.Label(p4TextRect, "Player 4");
    }
}
