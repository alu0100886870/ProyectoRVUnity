using UnityEngine;
using System.Collections;

public class SoundEmitter : MonoBehaviour {

	private AudioSource source;

	public void playSound(AudioClip audio, float volume)
	{
		source.PlayOneShot(audio, volume);
	}

	// Use this for initialization
	void Start()
	{
		source = gameObject.AddComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
