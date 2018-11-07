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
    public float trueAnomaly;
    public Vector3 positionVector;
    public float eccentricity;
    public float semiMajorAxis;

    // Use this for initialization
    void Start()
    {
        trueAnomaly = 0;
        rotationVector = new Vector3(0, 0, 0);
        siderealPeriod = 1;
        semiMajorAxis = 10;
        radius = 1;
        transform.localScale = new Vector3(radius, radius, radius);
        orbitalPeriod = 5;
        eccentricity = 0.6f;
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
        orbitalRadius = semiMajorAxis * (1-Mathf.Pow(eccentricity,2))/ (1+eccentricity*Mathf.Cos(trueAnomaly*(2*Mathf.PI)/360));
        trueAnomaly = trueAnomaly - 360/(orbitalPeriod*framerate);
        positionVector = new Vector3(orbitalRadius*Mathf.Sin(trueAnomaly*(2*Mathf.PI)/360),0,orbitalRadius * Mathf.Cos(trueAnomaly*(2 * Mathf.PI) / 360));
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
        rotationVector = rotationVector + new Vector3(0, -deltaRotation, 0);
        transform.eulerAngles = rotationVector;
    }
}
