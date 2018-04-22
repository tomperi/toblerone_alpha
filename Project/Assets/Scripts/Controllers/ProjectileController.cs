﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed;
    public ProjectileManager projectileManager;
    private Direction direction;
    private Vector3 directionVector;

    // Use this for initialization
    void Start () {
        direction = Direction.Right;
        directionVector = Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        transform.position += directionVector * speed * Time.deltaTime;
    }

    public void ChangeDirectionOnRotate()
    {
        switch (direction)
        {
            case Direction.Right:
                direction = Direction.Down;
                directionVector = Vector3.back;
                break;
            case Direction.Down:
                direction = Direction.Left;
                directionVector = Vector3.left;
                break;
            case Direction.Left:
                direction = Direction.Up;
                directionVector = Vector3.forward;
                break;
            case Direction.Up:
                direction = Direction.Right;
                directionVector = Vector3.right;
                break;
        }
    }


    private void OnDestroy()
    {
        projectileManager.spawnNewProjectileOnDeath();
    }
}
