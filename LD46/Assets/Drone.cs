using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour, IMouseInteractable, IEnemy
{
    [SerializeField] private GameObject objectOfInterest;
    [SerializeField] private float rotateSpeed = 15.0f;
    
    /* 
     * Create enum with 2 move states toPos, RotateAruond, 
     * Create healthpoints
     * Create something funny on click
     * 
     * 
     * 
     * 
     */



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetText()
    {
        throw new System.NotImplementedException();
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        throw new System.NotImplementedException();
    }

    public void SetRegion(GameObject region)
    {
        objectOfInterest = region;
    }
}
