using UnityEngine;
using System.Collections;

public class onGVRMode : MonoBehaviour {

	private bool enabledGVR;
	public GameObject gvrViewer;
	public GameObject[] affectedObjects;

	// Use this for initialization
	void Start () {
		GvrViewer g = (GvrViewer) gvrViewer.gameObject.GetComponent(typeof(GvrViewer));
		enabledGVR = g.VRModeEnabled;

		if (enabledGVR)
		{
			Debug.Log("La posicion original era: " + affectedObjects[0].transform.position);
			affectedObjects[0].transform.localPosition = Vector3.zero;
			affectedObjects[0].transform.localPosition = new Vector3(-360f, -360f, affectedObjects[0].transform.localPosition.z);	// UIDisplayText
			affectedObjects[1].transform.localPosition = new Vector3(-439.19f, 277.6f, affectedObjects[1].transform.localPosition.z);	// LifeContainer
			affectedObjects[2].transform.localPosition = new Vector3(401.59f, 293.9f, affectedObjects[2].transform.localPosition.z); // KeyContainer
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
