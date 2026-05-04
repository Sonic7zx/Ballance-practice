using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotateCam : MonoBehaviour
{

    public float radius = 2;
    public float height = 2;
    int index = 0;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            index++;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            index--;
        }
        if (index > 3) index = 0;
        if (index < 0) index = 3;

    }
    void FixedUpdate()
    {
        Vector3[] poses = new Vector3[]
        {
            new Vector3(0,0,-radius),
            new Vector3(radius,0,0),
            new Vector3(0,0,radius),
            new Vector3(-radius,0,0),
        };

        //transform.position = poses[index] + target.position;
        //transform.LookAt(target.position);

        Vector3 offset = transform.position - target.position;
        offset.y = 0;
        Vector3 temp = poses[index];

        offset = Vector3.Slerp(offset, temp, 0.1f);
        transform.position = offset + target.position + new Vector3(0, height, 0);

        transform.LookAt(target.position);

    }
}
