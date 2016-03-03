using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {
    public Transform[] waypoints;
    int currentWaypoint = 0;
    public float speed = 0.3f;

    void FixedUpdate() {
        // Waypoint not reached yet? then move closer
        if (transform.position != waypoints[currentWaypoint].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[currentWaypoint].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else
        {
            if(currentWaypoint == waypoints.Length-1)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint++;
            }
        }

        // Animation
        Vector2 dir = waypoints[currentWaypoint].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        { 
            Destroy(co.gameObject);
            CurrentGameState.setPacmanAlive(false);
        }
    }

}
