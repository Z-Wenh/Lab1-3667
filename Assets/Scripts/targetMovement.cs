using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class targetMovement : MonoBehaviour {
    [SerializeField] ScoreController scoreController; 
    [SerializeField] private AudioClip audioClip;
    private float xPosition = 40;
    private const float MAXX = 51;
    private const float MINX = -42;
    [SerializeField] private int direction = 1;
    [SerializeField] private const int POINTAMT = 10;
    private Vector3 movement;

    void Start() {
        InvokeRepeating("GrowInSize", 1.2f, 0.8f);
    }

    void Update() {
        //Reset the current scene if the balloon scale goes over 5
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
        //Points awarded will be rounded to the nearest number with the help of +0.5f
        if(other.gameObject.CompareTag("pin")) {
            SoundManager.Instance.PlayBalloonPop(audioClip, transform, 1f);
            scoreController.AddPoints((int)Mathf.Floor(POINTAMT - transform.localScale.x + 0.5f));
            Destroy(gameObject,1f);
            scoreController.DescreaseRemainingTarget();
        }
    }

    public void GrowInSize() {
        transform.localScale += new Vector3(0.3f ,0.3f ,0);
    }
}
