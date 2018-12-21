﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllList : MonoBehaviour {
    public  List<float> listToHoldData=new List<float>();
    public  List<float> listToHoldTime = new List<float>();
    public  List<float> listToHoldID = new List<float>();
    public  List<float> listToHoldBarHeight = new List<float>();
	public  List<float> listToHoldcollision1 = new List<float>();
	public  List<float> listToHoldcollision2 = new List<float>();
	public List<int> listToHoldtimeflag = new List<int>();   //运行每个ID需要的总的帧数


	public void allList( float time, float barForceInMilliNewton, float IDrecord, float barHeight, float collisionrecord1, float collisionrecord2, int timeflag)
    {   
		listToHoldTime.Add(time);
		listToHoldData.Add(barForceInMilliNewton / 1000);
        listToHoldID.Add(IDrecord);
        listToHoldBarHeight.Add(barHeight); 
		listToHoldcollision1.Add(collisionrecord1);
        listToHoldcollision2.Add(collisionrecord2);      
        listToHoldtimeflag.Add(timeflag);
    }
}
