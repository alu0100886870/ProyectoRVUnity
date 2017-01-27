using UnityEngine;
using System.Collections;

/**
 * La colisión con el objeto conseguible DAGGER
*/
public class CollisionDagger : CollectableItem {

	public GameObject WeaponToActivate;

	new void Awake()
	{
		// Start the event listener
		base.Awake();
		CharacterCollisions.Instance.ActivateObject += Activate;
	}



	// Use this for initialization
	new void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{
	}


	void Activate(GameObject obj)
	{
		// Verificamos que la llamada del evento sea para nosotros
		if (obj == gameObject) { 
			Debug.Log("COLLISION!!!!");
			Debug.Log("Se ha colisionado con: " + obj.gameObject.name);

			// Quitar la daga
			Destroy(obj.gameObject);

			// Desuscribir el evento del colisionador de personaje
			CharacterCollisions.Instance.ActivateObject -= Activate;

			// Mandar mensaje a la pantalla
			uiTextControl.setUIMessage(descriptionMessage);

			// PlaySound
			get();

			// Make "Weapon" visible again.
			WeaponToActivate.SetActive(true);
		}


	}

}
