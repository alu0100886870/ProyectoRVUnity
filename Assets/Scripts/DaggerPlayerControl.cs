using UnityEngine;
using System.Collections;

public class DaggerPlayerControl : MonoBehaviour
{
	public GameObject Weapon;           // The weapon holder (we need it to keep the relative axis of the inner-real gameObject model)
	private GameObject currentWeapon;   // The real model (gameObject)
	private Animator WeaponAnimation;   // The animation from the real model
	public AudioClip[] sounds;          // The sounds the weapon may emit.
	private SoundEmitter sound;         // The sound emitter system
	private GameObject FirstPersonCharacter;    // The FirstP

	private int currentStatus = 0;		// 0 = Idle

	// Use this for initialization
	void Start()
	{
		FirstPersonCharacter = transform.Find("FirstPersonCharacter").gameObject;
		WeaponAnimation = Weapon.transform.Find("DagaAnimada").gameObject.GetComponent<Animator>();
		sound = (SoundEmitter)GetComponent(typeof(SoundEmitter));
	}

	// Update is called once per frame
	void Update()
	{
		//Weapon.transform.position = gameObject.transform.position;
		//Weapon.transform.rotation = gameObject.transform.rotation;
		/*
		// We have to build the rotation for the weapon from the X,Z rotation from ther FirstPersonCharacter and the "Y" from the camera (yeah, it's that weird).
		Quaternion rotation = Quaternion.Euler(FirstPersonCharacter.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, FirstPersonCharacter.transform.rotation.eulerAngles.z);
		Weapon.transform.parent.transform.position = gameObject.transform.position;
		Weapon.transform.parent.transform.rotation = rotation;*/
	}

	public void onClick()
	{
		Debug.Log("Espadazo!");
		attack();
	}

	public void attack()
	{
		if (WeaponAnimation.GetCurrentAnimatorStateInfo(0).IsName("idle"))
		{
			currentStatus = 1;
			WeaponAnimation.CrossFade("slashDagger", 0f);
			sound.playSound(sounds[0], 1f);
		}
	}

}
