using UnityEngine;
using System.Collections;

public class SpiderBehaviour : Enemy {

	/**
	 * The current status the Spider has
	 * 0 = idle
	 * 1 = walking
	*/
	public int currentStatus = 0;
	public AudioClip[] sounds;      // Sound 0 -> Chasing, Sound 1 -> Attacking, Sound 2 -> Dying.
	public GameObject explosion;

	public float minDistanceToChase;
	public float minDistanceToAttack;

	private Animator animator;
	private TimerScript distanceCheckTimer;
	private GameObject timerPrefab;

	// Use this for initialization
	void Start () {
		base.Start();
		animator = gameObject.GetComponent<Animator>();

		// Get the distance timer ready.
		timerPrefab = Instantiate(Resources.Load("CustomPrefabs/TimerPrefab")) as GameObject;
		distanceCheckTimer = timerPrefab.GetComponent<TimerScript>();
		distanceCheckTimer.setTimer(1f, true);
		distanceCheckTimer.funcionDelegada = checkDistance;
		distanceCheckTimer.startTimer();
		if (gameObject.transform.localScale.x > 1)
			minDistanceToChase = minDistanceToChase * gameObject.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		checkDistance();
		switch (currentStatus)
		{
			case 0:
				animator.CrossFade("idle", 0f);
				break;
			case 1:
				animator.CrossFade("walk", 0f);
				break;
			case 2:
				animator.CrossFade("attack", 0f);
				break;
		}
	}

	/**
	 * What should the Spider do when he sees his target
	*/
	override
	public void onSight()
	{
		// Go towards character, he's too far for the little spider to attack him.
		if (distanceFromTarget > minDistanceToAttack && distanceFromTarget < minDistanceToChase)
		{
			if (getLastSound() != sounds[0])
			{
				playSound(sounds[0], 1f);
			}
			currentStatus = 1;
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
			transform.LookAt(target.transform);
		}
		else if (distanceFromTarget <= minDistanceToAttack)
		{
			// Character is now close. Attack
			currentStatus = 2;
			//Debug.Log("Te ataco");
		}
		//Debug.Log("TE VEO!");
	}

	override
	public void notOnSight()
	{
		setLastSound(null);
		currentStatus = 0;
	}

	public void onHit()
	{
		//GameObject go;
		//go = Instantiate(m_pPrefab, spawnpos, Quaternion.identity) as GameObject;
		//go.transform.parent = transform;
		GameObject go = (GameObject)Instantiate(explosion);
		go.transform.position = gameObject.transform.position;


		Destroy(gameObject);
	}

	void OnDestroy()
	{
		// Eliminar el temporizador de comprobar distancias.
		Destroy(timerPrefab);
	}

}
