using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKeys : MonoBehaviour
{
    public string key;
    public bool condition=false;
    public GameObject door;

    public void Start(){
        
    }
    public void OnTriggerStay2D(Collider2D other){
        if(other.name == key){
            condition=true;
            GetComponentInParent<DoorManager>().TestCondition();
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        if(other.name == key){
            condition = false;
            GetComponentInParent<DoorManager>().TestCondition();
        }
    }
}
