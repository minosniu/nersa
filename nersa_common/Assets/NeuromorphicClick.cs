using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeuromorphicClick : MonoBehaviour
{
    public static bool enter_neuromorphic = false;

	public Texture2D texture2D;

    //public Button button;

    //void Start()
    //{
    //	ColorBlock cb = new ColorBlock();
    //	cb.normalColor = Color.red;
    //	cb.highlightedColor = Color.green;
    //	cb.pressedColor = Color.blue;
    //	cb.disabledColor = Color.black;
    //	button.colors = cb;
    //}



    public void Click()
    {

        enter_neuromorphic = !enter_neuromorphic;


    }

    private void OnGUI()
    {

		if (enter_neuromorphic)   
        {

            GUIStyle aa = new GUIStyle();
            aa.normal.background = texture2D;
            aa.normal.textColor = Color.red;   //设置字体颜色的
            aa.fontSize = 100;       //这是字体大小
            aa.alignment = TextAnchor.MiddleCenter;
            GUI.Button(new Rect(Screen.width * 0.34f, Screen.height * 0.4f, 500, 600), "Neuromorphic ON", aa);


        }


    }


}





