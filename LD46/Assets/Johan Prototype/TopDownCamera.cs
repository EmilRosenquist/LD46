using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField] private GameObject dudeToFollow;
    [SerializeField] private float closest = 5.0f;
    [SerializeField] private float furthest = 35.0f;
    //[SerializeField] private float rotAngle = 45.0f;
    [SerializeField] private float DeadZoneDenominator = 6f;

    private float deadZone = 5.0f;
    private Vector3 ofset;

    // Start is called before the first frame update
    void Start()
    {
        ofset = gameObject.transform.position - dudeToFollow.transform.position;
        SetZoom(30);
        if (deadZone < 0) ofset *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        FollowDude();
        float scrollVal = Input.mouseScrollDelta.y;
        if (scrollVal != 0)
        {
            Zoom(-scrollVal);
        }
    }
    
    void FollowDude()
    {
        /*
         * Follows character with the camera
         * center stays within ofset from the dude
         */
        deadZone = CalculateDeadZone();
        Vector3 centerPos = gameObject.transform.position - ofset;
        Vector3 deltaPos = centerPos - dudeToFollow.transform.position;
        if (deltaPos.magnitude > deadZone)
        {
            Vector3 newDPos = deltaPos.normalized * deadZone;
            gameObject.transform.position = dudeToFollow.transform.position + newDPos + ofset;
        }
    }

    void Zoom(float zoomVal)
    {
        /*Zooms on scroll*/
        float CurrentZoom = ofset.magnitude;
        float targetZoom = Mathf.Clamp(CurrentZoom + Mathf.Clamp(zoomVal, -1, 1), closest, furthest);
        ofset = ofset.normalized * targetZoom;
    }

    void SetZoom(float dist)
    {
        /*Set Zoom level*/
        float targetZoom = Mathf.Clamp(dist, closest, furthest);
        ofset = ofset.normalized * targetZoom;
    }

    float CalculateDeadZone()
    {
        return ofset.magnitude / DeadZoneDenominator;
    }

}
