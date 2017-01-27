using UnityEngine;
using System.Collections;

public class FloatingItem : MonoBehaviour {
	float accel = 0.2f;
	float speed = 0;
	Vector3 startPosition;
	float maxDisplacement = 0.3f;	//Maximo 30 centimetros.
	float currentDisplacement = 0;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("startPosition es: " + startPosition);
		speed = accel;
		currentDisplacement += speed * Time.deltaTime;
		
		// Si llegamos al maximo, invertir aceleracion
		if (Mathf.Abs(currentDisplacement) >= maxDisplacement){
			accel = -accel;
		}
		transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
	}
}
