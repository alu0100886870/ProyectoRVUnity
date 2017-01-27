using UnityEngine;
using System.Collections;

public abstract class SelectableObject : MonoBehaviour{
    [HideInInspector] public GameObject sceneController;
    [HideInInspector] public UITextController uiTextControl;
    [HideInInspector] public UISoundController uiSoundControl;
	[HideInInspector] public PlayerStatus playerStatus;
	[HideInInspector] public ReticleProperties reticleProperties;
    [HideInInspector] public Transform character;

    public void initProperties()
    {
        sceneController = GameObject.Find("SceneController");
        uiTextControl = (UITextController)sceneController.GetComponent(typeof(UITextController));
        uiSoundControl = (UISoundController)sceneController.GetComponent(typeof(UISoundController));
        reticleProperties = (ReticleProperties)GetComponentInParent(typeof(ReticleProperties));
		playerStatus = (PlayerStatus)sceneController.GetComponent(typeof(PlayerStatus));
	}

    public abstract void onClick();
}
