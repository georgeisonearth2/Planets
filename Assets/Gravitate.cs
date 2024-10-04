using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitate : MonoBehaviour
{
    public float timeSpeed = 5f, radiusDistance, startAngle, elapsedTime;
    public bool ready = false;
    public Vector2 sunPos = Vector2.zero;
    private float angle, progress, planetX, planetY;
    private void Update()
    {
        if (ready)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / timeSpeed;
            angle = Mathf.Lerp(startAngle, startAngle + 2 * Mathf.PI, progress);
            planetX = sunPos.x - radiusDistance * Mathf.Cos(angle);
            planetY = sunPos.y - radiusDistance * Mathf.Sin(angle);
            transform.position = new Vector2(planetX, planetY);
            if (elapsedTime >= timeSpeed)
                elapsedTime = 0;
            
        }
    }
}
