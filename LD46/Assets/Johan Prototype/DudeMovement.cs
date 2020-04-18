using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeMovement : MonoBehaviour
{
    [SerializeField] private float maxVel = 2.0f;
    private CharacterController cc; 
    private Vector3 heightPoint = new Vector3(0, 10, 0);

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = GetMoveDirection();
        if(moveDir.sqrMagnitude > 0)
        {
            RotateDude(moveDir);
            GetMovePos(moveDir);
            FallDown();
        }
    }

    Vector3 GetMoveDirection()
    {
        // Returns a normalized direction of movement
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        return dir;
    }

    void RotateDude(Vector3 moveDir)
    {
        transform.forward = moveDir;
    }
    
    void GetMovePos(Vector3 moveDir)
    {
        cc.Move(moveDir * maxVel * Time.deltaTime);
    }

    void FallDown()
    {
        int layerMask = 1 << 9;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + heightPoint, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point;
        }
        else
        {
            Debug.LogWarning("No ground under Dude");
        }
    }
}
