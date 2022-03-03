using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    //Camera should follow the player.

    public GameObject gameObject;

    private Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = gameObject.transform.position + offSet ;
    }
}
