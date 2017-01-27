using UnityEngine;
using System.Collections;

public class ReticleProperties : MonoBehaviour {
    public float MAX_DISTANCE = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getMaxDistance()
    {
        return MAX_DISTANCE;
    }
}
