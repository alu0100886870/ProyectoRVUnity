using UnityEngine;
using System.Collections;

public class CharacterCollisions : MonoBehaviour {

	public delegate void OnSoftCollisionEvent(GameObject arg);
	public event OnSoftCollisionEvent ActivateObject;			// Otros objetos se sumarán a este evento

	// Singleton (solo debe haber un controlador de colisiones para el personaje)
	private static CharacterCollisions instance;

	public static CharacterCollisions Instance
	{
		get
		{
			if (instance == null)
				instance = GameObject.FindObjectOfType(typeof(CharacterCollisions)) as CharacterCollisions;
			Debug.Log("Instance vale: " + instance);
			return instance;
		}
	}

	// Cuando se produce una colisión SOFT.
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Collisionado con: " + other.gameObject.name);
		//Debug.Log("El evento tiene: " + ActivateObject);
		// Llamamos a la funcion "Activate" de los objetos que tengamos registrados
		if (ActivateObject != null)
		{
			ActivateObject(other.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
