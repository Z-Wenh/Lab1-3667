using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class targetMovement : MonoBehaviour {
    [SerializeField] AudioSource sound;
    [SerializeField] ScoreController scoreController; 
    private float xPosition = 40;
    private const float MAXX = 51;
    private const float MINX = -42;
    [SerializeField] private int direction = 1;
    private Vector3 movement;
    private const int POINTAMT = 10;

    void Start() {
        InvokeRepeating("GrowInSize", 1.2f, 0.8f);
        sound = GetComponent<AudioSource>();
    }

    void Update() {
        if(transform.localScale.x > 5 && transform.localScale.y > 5) {
            scoreController.ReloadScene();
        }
    }

    void FixedUpdate() {
        movement = new Vector3(xPosition * direction, 0, 0);
        transform.position = transform.position + movement * Time.deltaTime ;

        if(transform.position.x > MAXX) {
            direction = -1;
        }
        if(transform.position.x < MINX) {
            direction = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Points awarded will be rounded to the nearest number
        if(other.gameObject.CompareTag("pin")) {
            AudioSource.PlayClipAtPoint(sound.clip, transform.position);
            scoreController.AddPoints(Mathf.Floor(POINTAMT - transform.localScale.x + 0.5f));
            scoreController.AdvanceNextLevel();
        }
    }

    public void GrowInSize() {
        transform.localScale += new Vector3(0.3f ,0.3f ,0);
    }

    
}
