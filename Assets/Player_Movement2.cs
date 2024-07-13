using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement2 : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0.01f);
    }
}
