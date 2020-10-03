using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKeys : MonoBehaviour
{
    [HideInInspector]
    public bool condition=false;
    public bool playOnce =true;
    public void Start(){;
    }
    public void OnTriggerStay2D(Collider2D other){
        if(other.tag !="Player" && playOnce){
            for(int i=0; i<GetComponentInParent<DoorManager>().keys.Count; i++){
                if(other.name == GetComponentInParent<DoorManager>().keys[i]){
                    GetComponentInParent<DoorManager>().index = i;
                    other.gameObject.transform.position = gameObject.transform.position;
                    condition=true;
                    GetComponentInParent<DoorManager>().TestCondition();
                }
            }
            playOnce = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.tag !="Player" && !playOnce){
            for(int i=0; i<GetComponentInParent<DoorManager>().keys.Count; i++){
                if(other.name == GetComponentInParent<DoorManager>().keys[i]){
                    condition=false;
                    GetComponentInParent<DoorManager>().TestCondition();
                }
            } 
            playOnce = true;  
        }

    }
}
