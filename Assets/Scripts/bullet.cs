using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bullet : MonoBehaviour {

    void Update() {
        if(gameObject.transform.position.y > 50) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("target")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
