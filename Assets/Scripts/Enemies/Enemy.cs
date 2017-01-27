using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	public float maxVisionRange = 10f;	// The max distance to "see" someone.
	public GameObject target;           // The target for the enemy (the player)
	[Tooltip("Movement speed for the enemy")]
	public float speed;					// Enemy movement speed
	RaycastHit hit;                     // The raycast used to know if he's watching him or not.
	protected float distanceFromTarget = -1;
	private SoundEmitter sound;         // The sound emitter system
	private AudioClip lastSound;

	// Use this for initialization
	protected void Start () {
		sound = (SoundEmitter)GetComponent(typeof(SoundEmitter));
		Debug.Log("El sound emitter es: " + sound);
		if (gameObject.transform.localScale.x > 1)
			maxVisionRange = maxVisionRange * gameObject.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkDistance()
	{
		// If he's able to see target (not too far). So we don't have to trace raycast all the time
		distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
		//Debug.Log("La distancia desde esta araña: " + gameObject.name + " es: " + distanceFromTarget);
		if (distanceFromTarget < maxVisionRange)
		{
			Debug.DrawLine(gameObject.transform.position, target.transform.position, Color.red);
			// Trace raycast to check if we hit the target (there could be objects in between).
			if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit, maxVisionRange))
			{
				//Debug.Log("La araña hitea a: " + hit.collider + " y nuestro target tiene de collider: " + target.GetComponent<Collider>());
				if (hit.collider == target.GetComponent<Collider>())
				{
					onSight();
				}
			}
			else
			{
				distanceFromTarget = -1;
			}
		}
		else
		{
			notOnSight();
		}
	}

	protected void playSound(AudioClip a, float v)
	{
		sound.playSound(a, v);
		setLastSound(a);
	}

	public AudioClip getLastSound()
	{
		return lastSound;
	}

	public void setLastSound(AudioClip a)
	{
		lastSound = a;
	}

	abstract public void onSight();
	abstract public void notOnSight();
}
