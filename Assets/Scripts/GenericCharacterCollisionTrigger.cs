using UnityEngine;
using System.Collections;

public abstract class GenericCharacterCollisionTrigger : MonoBehaviour {

	public GameObject objectToWatch;

	// Use this for initialization
	protected void Start()
	{
		CharacterCollisions.Instance.ActivateObject += Activate;
	}

	// Update is called once per frame
	void Update()
	{
	}

	protected bool isCallForUs(GameObject obj)
	{
		if (obj != gameObject)
		{
			return false;
		}

		return true;
	}


	protected virtual void Activate(GameObject obj)
	{
	}

}
