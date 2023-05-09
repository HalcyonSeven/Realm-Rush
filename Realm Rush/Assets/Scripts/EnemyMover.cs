using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new();
    [SerializeField] private float waitTime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PrintWaypointName()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
