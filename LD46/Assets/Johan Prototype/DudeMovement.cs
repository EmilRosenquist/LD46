using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeMovement : MonoBehaviour
{
    [SerializeField] private float maxVel = 2.0f;
    private CharacterController cc; 
    private Vector3 heightPoint = new Vector3(0, 3, 0);


    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = GetMoveDirection();
        RotateDude(moveDir);
        GetMovePos(moveDir);
        FallDown();
    }

    Vector3 GetMoveDirection()
    {
        // Returns a normalized direction of movement
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        return dir;
    }

    void RotateDude(Vector3 moveDir)
    {
        gameObject.transform.forward = moveDir;
    }
    
    void GetMovePos(Vector3 moveDir)
    {
        cc.Move(moveDir * maxVel * Time.deltaTime);
    }

    void FallDown()
    {
        
    }
}
