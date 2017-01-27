using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public int currentHearts = 3;
	public int currentKeys = 1;

	public Text keyAmounts;

	// Use this for initialization
	void Start () {
		keyAmounts = GameObject.Find("UIKeyAmount").GetComponent<Text>();
		setCurrentKeys(currentKeys);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getCurrentKeys()
	{
		return currentKeys;
	}

	public void setCurrentKeys(int n)
	{
		currentKeys = n;
		keyAmounts.text = currentKeys.ToString() + "x";
	}

	public int getCurrentHearts()
	{
		return currentHearts;
	}

	public void setCurrentHearts(int n)
	{
		currentHearts = n;
	}

	public void finishGame()
	{

	}

}
