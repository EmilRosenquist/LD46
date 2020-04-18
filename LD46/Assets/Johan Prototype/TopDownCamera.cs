using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField] private GameObject dudeToFollow;
    [SerializeField] private float deadZone = 5.0f;
    [SerializeField] private float rotAngle = 45.0f;
    private Vector3 ofset;

    // Start is called before the first frame update
    void Start()
    {
        ofset = gameObject.transform.position - dudeToFollow.transform.position;
        if (deadZone < 0) ofset *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        FollowDude();
    }
    
    void FollowDude()
    {
    /*
     * Follows character with the camera
     * center stays within ofset from the dude
     */
        Vector3 centerPos = gameObject.transform.position - ofset;
        Vector3 deltaPos = centerPos - dudeToFollow.transform.position;
        if (deltaPos.magnitude > deadZone)
        {
            Vector3 newDPos = deltaPos.normalized * deadZone;
            gameObject.transform.position = dudeToFollow.transform.position + newDPos + ofset;
        }
    }
}
