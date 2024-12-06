using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour {
    [SerializeField] GameObject player; 
    [SerializeField] GameObject pinPrefab;
    private Rigidbody2D rb;
    private const float SPEED = 40;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            var pin = Instantiate(pinPrefab, player.transform.position, Quaternion.identity);
            rb = pin.GetComponent<Rigidbody2D>();
            rb.velocity = player.transform.up * SPEED;
            pin.transform.Rotate(0, 0, 90);
        }
    }

    
}
