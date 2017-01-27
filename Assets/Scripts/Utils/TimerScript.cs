using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour{

	public delegate void delegado();
	public delegado funcionDelegada;

	protected float timeAmount, originalTimeAmount;
	protected bool started, finished, repeat;

	public void setTimer(float timeAmount)
	{
		this.timeAmount = timeAmount;
		this.originalTimeAmount = timeAmount;
		repeat = false;
	}

	public void setTimer(float timeAmount, bool repeat)
	{
		setTimer(timeAmount);
		this.repeat = repeat;
	}

	// Use this for initialization
	void Start()
	{
		finished = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (started && !finished)
		{
			timeAmount -= Time.deltaTime;
			if (timeAmount <= 0)
			{
				execute();
				finished = true;
				if (repeat)
				{
					finished = false;
					timeAmount = originalTimeAmount;
				}
			}
		}
	}

	public void startTimer()
	{
		started = true;
	}

	void execute()
	{
		funcionDelegada();
	}
}
