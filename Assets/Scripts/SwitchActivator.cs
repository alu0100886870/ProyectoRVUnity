using UnityEngine;
using System.Collections;

/**
 * Esta clase controla los interruptores que activan (desbloquean) cosas.
 * Llamará a la función "unlock" del objeto asociado a desbloquear.
**/
public class SwitchActivator : SelectableObject
{
    public string descriptionMessage = "";	// Mensaje a mostrar cuando se pulse
	public GameObject objectToUnlock;		// El objeto que se desbloqueará
    public AudioClip pushSound;				// El sonido de pulsación del interruptor
    public float soundVolume = 1.0f;		// Volumen del sonido

    private float volLowRange = 1.0f;
    private float volHighRange = 1.0f;
    private AudioSource source;
	public new bool enabled = true;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
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
		if (enabled){
			uiTextControl.setUIMessage(descriptionMessage);
			get();
			transform.position += transform.forward * (-0.3f);
			enabled = !enabled;
			// Llamar al evento "Unlock" del objeto asociado
			UnlockableDoorController other = (UnlockableDoorController) objectToUnlock.GetComponent(typeof(UnlockableDoorController));
			other.Unlock();
		}
    }

    private void get()
    {
        uiSoundControl.playSound(pushSound, soundVolume);
    }
}
