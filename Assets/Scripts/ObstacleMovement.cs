using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementScript : MonoBehaviour {
    private float xPosition = 35;
    private const float MAXX = 51;
    private const float MINX = -42;
    [SerializeField] private int direction = 1;
    [SerializeField] private float _speed = 0.7f;
    private Vector3 movement;

    void FixedUpdate() {
        movement = new Vector3(xPosition * direction, 0, 0);
        transform.position = transform.position + movement * _speed * Time.deltaTime ;

        if(transform.position.x > MAXX) {
            direction = -1;
        }
        if(transform.position.x < MINX) {
            direction = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("pin")) {
            Destroy(other.gameObject);
        }
    }
}
