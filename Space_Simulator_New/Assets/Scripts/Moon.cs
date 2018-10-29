using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

    int framerate = 60;

    public float siderealPeriod;
    public float orbitalPeriod;
    float deltaRotation;
    Vector3 rotationVector;

    public float orbitalRadius;
    public float radius;
    float orbitalAngle;
    Vector3 positionVector;
    Vector3 positionEarth;
    Vector3 positionEarthToMoon;

    // Use this for initialization
    void Start()
    {
        orbitalAngle = 180;
        orbitalRadius = 1f;
        rotationVector = new Vector3(0, 0, 0);
        siderealPeriod = 0;
        radius = 0.3f;
        transform.localScale = new Vector3(radius, radius, radius);
        orbitalPeriod = 1;
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
        positionEarth=GameObject.Find("Earth").GetComponent<Earth>().positionVector;
        orbitalAngle = orbitalAngle + 360 / (orbitalPeriod * framerate);
        positionEarthToMoon = new Vector3(orbitalRadius * Mathf.Sin(orbitalAngle * (2 * Mathf.PI) / 360), 0, orbitalRadius * Mathf.Cos(orbitalAngle * (2 * Mathf.PI) / 360));
        positionVector = positionEarth + positionEarthToMoon;
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
