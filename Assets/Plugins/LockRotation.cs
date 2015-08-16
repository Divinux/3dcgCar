using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

	Vector3 def = new Vector3(0,0,0);
	
	// Update is called once per frame
	void Update () {
	transform.eulerAngles = def;
	}
}
