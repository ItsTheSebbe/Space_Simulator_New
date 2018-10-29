using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

    int framerate = 60;

    public float siderealPeriod;
    float deltaRotation;
    Vector3 rotationVector;

    public float orbitalRadius;
    public float radius;
    public float orbitalPeriod;
    float orbitalAngle;
    public Vector3 positionVector;

    // Use this for initialization
    void Start()
    {
        orbitalAngle = 0;
        orbitalRadius = 5; 
        rotationVector = new Vector3(0, 0, 0);
        siderealPeriod = 1;
        radius = 1;
        transform.localScale = new Vector3(radius, radius, radius);
        orbitalPeriod = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Position();
        Rotation();
        transform.localScale = new Vector3(radius, radius, radius);
    }

    void Position()
    {
        orbitalAngle = orbitalAngle + 360/(orbitalPeriod*framerate);
        positionVector = new Vector3(orbitalRadius*Mathf.Sin(orbitalAngle*(2*Mathf.PI)/360),0, orbitalRadius * Mathf.Cos(orbitalAngle*(2 * Mathf.PI) / 360));
        transform.position = positionVector;
    }

    void Rotation()
    {
        if (siderealPeriod == 0)
        {
            deltaRotation = 0;
        }
        else
        {
            deltaRotation = 360 / (siderealPeriod * framerate);
        }
        rotationVector = rotationVector + new Vector3(0, +deltaRotation, 0);
        transform.eulerAngles = rotationVector;
    }
}
