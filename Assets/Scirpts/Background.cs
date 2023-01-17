using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed;
    public float moveRange;

    private Vector3 oldPosition;
    // Use this for initialization
    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * movespeed * Time.deltaTime;
        if (Vector3.Distance(oldPosition, transform.position) > moveRange)
        {
            transform.position = oldPosition;
        }
    }
}
