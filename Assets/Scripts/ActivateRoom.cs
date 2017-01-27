using UnityEngine;
using System.Collections;

public class ActivateRoom : GenericCharacterCollisionTrigger
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
		}
	}
}
