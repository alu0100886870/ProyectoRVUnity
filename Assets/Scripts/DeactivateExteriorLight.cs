using UnityEngine;
using System.Collections;

public class DeactivateExteriorLight : GenericCharacterCollisionTrigger
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
			objectToWatch.SetActive(false);
			Vector3 tmp = transform.eulerAngles;
			tmp.x = 250;
			objectToWatch.transform.eulerAngles = tmp;
		}
	}
}
