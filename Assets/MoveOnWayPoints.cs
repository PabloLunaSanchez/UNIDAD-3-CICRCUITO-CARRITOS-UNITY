using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWayPoints : MonoBehaviour
{
    [SerializeField]
    Transform poInicio;

    public List<GameObject> waypoints;
    public float speed = 2;

    public int index = 0;
    void Start()
    {       
        transform.position = poInicio.position;
        transform.rotation = poInicio.rotation;
    }

    private void Update()
    {
        Vector3 destination = waypoints[index].transform.position;

        transform.LookAt(waypoints[index].transform);

        Vector3 newPos = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
        }
    }
}
