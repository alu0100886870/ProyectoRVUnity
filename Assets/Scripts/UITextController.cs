using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextController : MonoBehaviour {
    [Tooltip("The UI text to be controlled")]
    public Text UIText;
    [Tooltip("The amount of time the message is going to last on screen.")]
    public const float messageDisplayLife = 5f;

    private float timerCountDown = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (timerCountDown > 0)
        {
            timerCountDown -= Time.deltaTime;
        }
        else
        {
            if (UIText.text.Length > 0)
                clearText();
        }
	}

    public void setUIMessage(string message)
    {
        timerCountDown = messageDisplayLife;
        UIText.text = message;
    }

    private void clearText()
    {
        UIText.text = "";
    }
}
