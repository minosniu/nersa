using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prohibited_area : MonoBehaviour {

	public static float collision2 = 0;   // bool false-0
    public Texture2D texture2D;
    public GameObject obj;
    public Renderer rend;

    private void Start()
     {
	    obj = GameObject.Find("Prohibited_area");
	    rend = obj.GetComponent<Renderer>();
     }

   // Update is called once per frame
   void Update () {

    }

   private void OnCollisionEnter2D(Collision2D collision)
    {

	    if(collision.gameObject.name=="MoveRacket_force")
	    {
			collision2 = 1;   //true-1
	
		  StartCoroutine(Delay.run(() =>{
		   collision2 = 0;     //false-0
			}, 10));
	    }

    }


   private void OnGUI()
   {
	//Debug.Log("time_flag"+time_flag);
		if (collision2 == 1)                  //if (collision2)   collision=true  
	   {

		GUIStyle bb = new GUIStyle();
		bb.normal.background = texture2D;
		bb.normal.textColor = Color.yellow;   //设置字体颜色的
		bb.fontSize = 60;       //当然，这是字体大小
		bb.alignment = TextAnchor.MiddleCenter;
		GUI.Button(new Rect(Screen.width * 0.3f, Screen.height*0.1f , 500, 500), "Game Over", bb);

	   }
	//if (ishint)
	//{
	//    GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.75f, 200, 30), "请上移木条");
	//}

   }
		
}
