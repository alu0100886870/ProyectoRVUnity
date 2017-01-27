using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GlobalInputHandler : MonoBehaviour {
	public GameObject character;
	public GameObject GvrReticle;
	private GvrReticle gvrReticleScript;
	[HideInInspector]
	public GameObject sceneController;
	[HideInInspector]
	public UITextController uiTextControl;

	// Use this for initialization
	void Start () {
		sceneController = GameObject.Find("SceneController");
		uiTextControl = (UITextController)sceneController.GetComponent(typeof(UITextController));
		gvrReticleScript = (GvrReticle)GvrReticle.GetComponent(typeof(GvrReticle));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
		{
			uiTextControl.setUIMessage("Se ha pulsado Fire1!");
		}
		if (Input.GetButton("Prueba"))
		{
			uiTextControl.setUIMessage("Se ha pulsado Prueba!");
		}

	}

	// Global onClick. Llamado cuando la retícula no estaba expandida (puede usarse para armas y otros eventos).
	public void onClick()
	{
		// Si existe la daga animada (arma del personaje), hacer el ataque.
		if (GameObject.Find("DagaAnimada") != null)
		{
			DaggerPlayerControl other = (DaggerPlayerControl)character.GetComponent(typeof(DaggerPlayerControl));
			other.onClick();
		}
	}
}
