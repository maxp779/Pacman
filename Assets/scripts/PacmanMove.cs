﻿using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.3f;
    Vector2 destination = Vector2.zero;
    // Use this for initialization
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    //	void Update () {
    //
    //	}

    // FixedUpdate is called at a set interval
    void FixedUpdate()
    {
        //If pacmans current position does not equal his destination
        //attempt to move him to his destination
        if ((Vector2)transform.position != destination)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, destination, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }

        //If his current position is the same as the destination pacman is ready
        //to be moved again so input is listened for. If his current position is not
        //yet at his destination he may have not reached his last destination yet so no action
        //will be taken.
        if ((Vector2)transform.position == destination)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                destination = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                destination = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                destination = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                destination = (Vector2)transform.position - Vector2.right;
        }

        //Animation Parameters
        //direction calculated using "vector maths"
        Vector2 direction = destination - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", direction.x);
        GetComponent<Animator>().SetFloat("DirY", direction.y);

    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
