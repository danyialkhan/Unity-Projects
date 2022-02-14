using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    public float orbitPreiod = 3f;
    public bool orbitActive = true;

    //use this for init
    void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        setOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    private void setOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPreiod < 0.1f)
        {
            orbitPreiod = 0.1f;
        }
        float orbitSpeed = 1f / orbitPreiod;
        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            setOrbitingObjectPosition();
            yield return null;
        }
    }
}
