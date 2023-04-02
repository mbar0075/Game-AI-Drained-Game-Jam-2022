using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackShip : MonoBehaviour
{

    Image ship;
    
    Vector2 startPos;
    public Vector2 endPos;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Image>();
        startPos = ship.transform.position;
        Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, endPos, step);

        if(transform.position == (Vector3)endPos)
        {
            ship.transform.position = startPos;
        }

    }
}
