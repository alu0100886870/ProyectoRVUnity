using UnityEngine;
using System.Collections;

// This script, when present on a gameObject, indicates that it is subject to receive Weapon hits and show effects from it.
public class WeaponHitProperties : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onHit()
	{
		if (gameObject.tag == "Spider")
		{
			SpiderBehaviour sb = (SpiderBehaviour)GetComponent(typeof(SpiderBehaviour));
			sb.onHit();
		}
	}
}
