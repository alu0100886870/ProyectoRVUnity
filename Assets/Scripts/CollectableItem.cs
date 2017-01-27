using UnityEngine;
using System.Collections;

public class CollectableItem : SelectableObject
{
    public string descriptionMessage = "Has conseguido un objeto";
    public AudioClip collectionSound;
    public float soundVolume = 1.0f;

    //private float volLowRange = 1.0f;
    //private float volHighRange = 1.0f;
    private AudioSource source;

	public int itemType = 0;	// 0 - Nothing, 1 - Key

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    public void Start()
    {
        initProperties();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override
    public void onClick()
    {
        uiTextControl.setUIMessage(descriptionMessage);
        get();
        Destroy(gameObject);
    }

    public void get()
    {
        uiSoundControl.playSound(collectionSound, soundVolume);
		if (itemType == 1)
		{
			playerStatus.setCurrentKeys(playerStatus.getCurrentKeys() + 1);
		}
        //Key++;
    }
}
