using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterClick : MonoBehaviour {
	public static bool verify = false;
	public static bool verify_flag = false;

	public void Click(){
		verify = true;
		verify_flag = true;
	}
}
