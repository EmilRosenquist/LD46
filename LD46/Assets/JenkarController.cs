﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JenkarController : MonoBehaviour, IMouseInteractable, IEnemy
{
    [SerializeField] private GameObject interestingRegion;
    [SerializeField] private float walkSpeed = 7;
    [SerializeField] private bool roaming = true;
    [SerializeField] private float interactRange = 4;
    private float reachLim = 0.5f;
    private CharacterController cc;
    private float timeStuck = 1.0f;
    private float stuckTimer = 1.0f;
    Vector3 stuckPos;

    [SerializeField] private List<string> racistSlurs;

    [SerializeField] private int happyness = 10;

    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        stuckPos = transform.position;
        cc = GetComponent<CharacterController>();
        if(roaming) target = GenerateTarget();
    }

    // Update is called once per frame
    void Update()
    {

        if (roaming)
        {
            stuckTimer -= Time.deltaTime;
            if (stuckTimer < 0)
            {
                stuckTimer = 1.0f;
                if (checkIfStuck()) target = GenerateTarget();
            }
            if (Vector3.Distance(transform.position, target) < reachLim)
            {
                target = GenerateTarget();
            }
            Vector3 moveDir = (target - transform.position).normalized;
            transform.forward = moveDir;
            cc.Move(moveDir * walkSpeed * Time.deltaTime);
        }
        
    }

    Vector3 GenerateTarget()
    {
        //BoxCollider regionCol = interestingRegion.GetComponent<BoxCollider>();
        Vector3 centerOfRegion = interestingRegion.transform.position;
        float xPos = centerOfRegion.x + Random.Range(-(interestingRegion.transform.localScale.x / 2), interestingRegion.transform.localScale.x / 2);
        float yPos = centerOfRegion.y + interestingRegion.transform.localScale.y / 2;
        float zPos = centerOfRegion.z + Random.Range(-(interestingRegion.transform.localScale.z / 2), interestingRegion.transform.localScale.z / 2);

        int layerMask = 1 << 9;
        Vector3 newTarget = new Vector3(xPos, yPos, zPos);
        RaycastHit hit;
        if (Physics.Raycast(newTarget, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            newTarget = hit.point;
        }

        return newTarget;
    }

    bool checkIfStuck()
    {
        if(Vector3.Distance(stuckPos, transform.position) < timeStuck)
        {
            return true;
        }
        stuckPos = transform.position;
        return false;
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if (Vector3.Distance(transform.position, position) < interactRange)
        {
            int index = Random.Range(0, racistSlurs.Count);
            happyness -= 1;
            if(happyness>0)
                ToolTipHandler.instance.SetText(racistSlurs[index]);
            else
            {
                ToolTipHandler.instance.SetText("UUUURHGH, Im going back to McDonalds!");
                Destroy(gameObject);
            }
        }
    }

    public string GetText()
    {
        return "God damn natives!";
    }

    public void SetRegion(GameObject region)
    {
        interestingRegion = region;
    }
}
