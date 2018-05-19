using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System;
using System.Linq;
using System.Text;
using System.Net;


public class TargetRacket_force : MonoBehaviour
{
    private int sum;
    private float[,] trial = new float[100, 10];
    private int count = 0;
    private bool collision = false;
    private int flag = 0;

	public static float ID = 0;

    //List<float> listToHoldID;
    //List<float> listToHoldTime;

    // Use this for initialization

    public GameObject obj;
    public Renderer rend;
    void Start()
    {

        //listToHoldID = new List<float>();
        //listToHoldTime = new List<float>();

        CSVHelper.Instance().ReadCSVFile("config", (table) => {
            sum = int.Parse(table["0"]["Count"]);
            //Debug.Log(sum);
            for (int i = 0; i <= sum; i++)
            {
                trial[i, 0] = float.Parse((table[i.ToString()])["id"]);
                trial[i, 1] = float.Parse((table[i.ToString()])["Distance"]);
                trial[i, 2] = float.Parse((table[i.ToString()])["Width"]);
            }
        });

        obj = GameObject.Find("TargetRacket_force");
        rend = obj.GetComponent<Renderer>();
        
    }

    // Update is called once per frame
	void FixedUpdate()
    {
		if (TestClick.flag) {
		
			obj.transform.localPosition = new Vector3(-8, trial[count, 1], 0);  //x轴方向position
			obj.transform.localScale = new Vector3(26, trial[count, 2], 0);     //x轴方向宽度

			ID = trial[count, 0];

            if (collision)
			{
				flag++;

			}
			else
			{
				flag = 0;
			}
			if(flag>180)     //默认帧数60
			{
				count++;
				flag = 0;
			}

           // listToHoldTime.Add(Time.time);
          //  listToHoldID.Add(ID);

        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        rend.material.color = Color.red;
        collision = true;

    }
    void OnCollisionExit2D(Collision2D col)
    {
        rend.material.color = Color.green;
        collision = false;
    }
		


    //private void OnApplicationQuit()
    //{

    //    string data = "";
    //    StreamWriter writer = new StreamWriter("ID_test.csv", false, Encoding.UTF8);

    //    writer.WriteLine(string.Format("{0},{1}", "Time", "ID"));


    //    using (var e1 = listToHoldTime.GetEnumerator())
    //    using (var e2 = listToHoldID.GetEnumerator())
    //    {
    //        while (e1.MoveNext() && e2.MoveNext())
    //        {
    //            var item1 = e1.Current;
    //            var item2 = e2.Current;

    //            data += item1.ToString();
    //            data += ",";
    //            data += item2.ToString();
    //            data += "\n";
    //            // use item1 and item2
    //        }
    //    }

    //    writer.Write(data);

    //    writer.Close();
    //}


}