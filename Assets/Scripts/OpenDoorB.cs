using UnityEngine;
using System.Collections;

public class OpenDoorB : MonoBehaviour {

	public bool opened = false;
	public bool locked = false;
	public float targetAngle = 90f;
	public bool clockWise = false;
	Quaternion newRotation;

	[HideInInspector]
	public GameObject sceneController;
	private UITextController uiTextControl;
	private PlayerStatus playerStatus;

	// Use this for initialization
	void Start()
	{
		sceneController = GameObject.Find("SceneController");
		uiTextControl = (UITextController)sceneController.GetComponent(typeof(UITextController));
		playerStatus = (PlayerStatus)sceneController.GetComponent(typeof(PlayerStatus));
		Debug.Log("Actualmente está en: " + transform.rotation.eulerAngles.y);
		if (!clockWise)
		{
			targetAngle = -targetAngle;
			Debug.Log("Opening degrees ahora es: " + targetAngle);
			//openingDegrees += 360;
		}
		Debug.Log("El angulo nuevo será: " + (transform.rotation.eulerAngles.y + targetAngle));
		newRotation = Quaternion.AngleAxis((transform.rotation.eulerAngles.y + targetAngle), Vector3.down);
		Debug.Log("El nuevo quaternion: " + newRotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (opened == true)
		{
				//openingDegrees -= Time.deltaTime * 100;
				//transform.Rotate(Vector3.down * Time.deltaTime * 100);
				
				transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);
				//Debug.Log("OpeningD: " + targetAngle + " Ahora es: " + transform.rotation.eulerAngles.y);
		}
	}

	public void onClick()
	{
		// Si está cerrada con cerradura, mirar que tengamos una llave.
		if (locked)
		{
			if (playerStatus.getCurrentKeys() == 0)
			{
				uiTextControl.setUIMessage("Hace falta una llave para abrir esta puerta");
				return;
			}
				
			playerStatus.setCurrentKeys(playerStatus.getCurrentKeys() - 1);
			locked = false;
		}

		if (!locked)
			opened = true;
	}
}
