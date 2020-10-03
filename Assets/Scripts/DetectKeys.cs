using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKeys : MonoBehaviour
{
    public bool condition=false;
    public GameObject door;

    public void Start(){;
    }
    public void OnTriggerStay2D(Collider2D other){
        for(int i=0; i<GetComponentInParent<DoorManager>().keys.Count; i++){
            if(other.name == GetComponentInParent<DoorManager>().keys[i]){
                condition=true;
                GetComponentInParent<DoorManager>().TestCondition();
            }
        }
    }
    
    public void OnTriggerExit2D(Collider2D other){
          for(int i=0; i<GetComponentInParent<DoorManager>().keys.Count; i++){
            if(other.name == GetComponentInParent<DoorManager>().keys[i]){
                condition=false;
                GetComponentInParent<DoorManager>().TestCondition();
            }
        }
    }
}
