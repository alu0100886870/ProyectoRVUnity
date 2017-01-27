using UnityEngine;
using System.Collections;

public class UISoundController : MonoBehaviour {

    private AudioSource source;

    public void playSound(AudioClip audio, float volume)
    {
        source.PlayOneShot(audio, volume);
    }

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
