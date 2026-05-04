using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBall : MonoBehaviour
{
    int ballIndex = 0;
    FollowRotateCam followRotateCam;

    // Start is called before the first frame update
    void Start()
    {
        followRotateCam = Camera.main.GetComponent<FollowRotateCam>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.GetChild(ballIndex).gameObject.SetActive(false);
            Vector3 pos = transform.GetChild(ballIndex).position;
            Vector3 vel = transform.GetChild(ballIndex).GetComponent<Rigidbody>().velocity;
            ballIndex++;
            if (ballIndex >= 3)
            {
                ballIndex = 0;
            }

            Transform newTrans = transform.GetChild(ballIndex);
            newTrans.gameObject.SetActive(true);
            newTrans.position = pos;
            newTrans.GetComponent<Rigidbody>().velocity = vel;

            followRotateCam.target = transform.GetChild(ballIndex);
        }
    }
}
