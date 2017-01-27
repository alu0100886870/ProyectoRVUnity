using UnityEngine;
using System.Collections;

// Esta clase detecta las colisiones del arma con otros objetos.
public class CollisionWeapon : MonoBehaviour
{
	private DaggerPlayerControl DPC;
	private bool damageEnabled;

	// Use this for initialization
	void Start()
	{
		damageEnabled = false;
		//DPC = (DaggerPlayerControl)GetComponent(typeof(DaggerPlayerControl));
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerStay(Collider other)
	{
		if (damageEnabled) { 
			// First, verify we are hitting something responsive to weapon hits.
			WeaponHitProperties whp = (WeaponHitProperties)other.gameObject.GetComponent(typeof(WeaponHitProperties));
			if (whp == null)
				return;

			// If it passes, send them the attack effect.
			whp.onHit();
			
			Debug.Log("AAAAAAAAA");
		}

	}

	void canDamage()
	{
		damageEnabled = true;
	}

	void inactive()
	{
		damageEnabled = false;
	}
}
