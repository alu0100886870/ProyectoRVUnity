using UnityEngine;
using System.Collections;

public class ActivateExteriorLight : GenericCharacterCollisionTrigger
{
	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void Activate(GameObject a)
	{
		if (!isCallForUs(a))
			return;

		if (objectToWatch != null)
		{
			objectToWatch.SetActive(true);
			Vector3 tmp = transform.eulerAngles;
			tmp.x = 132;
			tmp.y = 150;
			tmp.z = 0;
			objectToWatch.transform.eulerAngles = tmp;
		}
	}
}
