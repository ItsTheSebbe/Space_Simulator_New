using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
    public float siderealPeriod;
    public float radius;
    float deltaRotation;
    int framerate = 60;
    Vector3 rotationVector;


	// Use this for initialization
	void Start () {
        siderealPeriod = 5;
        radius = 5;
    }
	
	// Update is called once per frame
	void Update () {
        Rotate();
        transform.localScale = new Vector3(radius, radius, radius);
    }
    void Rotate()
    {
        if (siderealPeriod==0)
        {
            deltaRotation = 0;
        }
        else
        {
            deltaRotation = 360 / (siderealPeriod * framerate);
        }
        rotationVector = new Vector3(0, -deltaRotation, 0);
        gameObject.transform.Rotate(rotationVector);
    }
}
