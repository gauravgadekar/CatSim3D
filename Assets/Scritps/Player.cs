using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    private Touch touch;

    public float speed;

    public float posXmin;

    public float posXmax;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase==TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
            }
        }

        if (transform.position.x<posXmin)
        {
            transform.position = new Vector3(posXmin, transform.position.y, transform.position.z);
        }
        if (transform.position.x>posXmax)
        {
            transform.position = new Vector3(posXmax, transform.position.y, transform.position.z);
        }
    }
}
