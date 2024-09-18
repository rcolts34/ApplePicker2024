using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;


    // Start is called before the first frame update
    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Get the current screen position of the mouse from Input
        // move the x position of this Basket to the x position of the mouse
        Vector3 mousePos2d = Input.mousePosition;

        // The Camer's z position sets how far to push the mouse into 3D
        mousePos2d.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2d);
        
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            // Increase the score
            scoreCounter.Score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.Score);
        }
    }
}
