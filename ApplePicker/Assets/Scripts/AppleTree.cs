using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 12;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.05f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement 
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if ( pos.x < -leftAndRightEdge )
        {
            speed = Mathf.Abs(speed); // move right
        } 
        else if ( pos.x > leftAndRightEdge ) 
        { 
            speed = -Mathf.Abs(speed); // Move left
        } 
        
    }
    void FixedUpdate()
        // Random direction changes are now time-based due to FixedUpdate()
    { 
        if ( Random.value < changeDirChance )
        {
            speed *= -1.02f; // Change direction
        }
    }
    
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position; // place that apple right on the apple tree
        Invoke( "DropApple", appleDropDelay );
    }



}
