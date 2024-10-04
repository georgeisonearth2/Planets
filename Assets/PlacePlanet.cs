using UnityEngine;

public class PlacePlanet : MonoBehaviour
{
    public GameObject planet;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newPlanet = Instantiate(planet, mousePosition, Quaternion.identity);
            int randomColorR = Random.Range(0, 256);
            int randomColorG = Random.Range(0, 256);
            int randomColorB = Random.Range(0, 256);
            newPlanet.GetComponent<SpriteRenderer>().color = new Color(randomColorR / 255f, randomColorG / 255f, randomColorB / 255f);
            Gravitate gravitate = newPlanet.GetComponent<Gravitate>();
            gravitate.sunPos = gameObject.transform.position;
            gravitate.radiusDistance = Vector2.Distance(gravitate.sunPos, newPlanet.transform.position);
            float planetX = newPlanet.transform.position.x;
            float planetY = newPlanet.transform.position.y;
            gravitate.startAngle = Mathf.Atan2((transform.position.y - planetY), (transform.position.x - planetX));
            int randomTimeSpeed = Random.Range(3, 16);
            gravitate.timeSpeed = randomTimeSpeed;
            float randomScale = Random.Range(1, 2);
            newPlanet.transform.localScale = new Vector2(randomScale, randomScale);
            gravitate.elapsedTime = 0;
            gravitate.ready = true;
        }
    }

}
