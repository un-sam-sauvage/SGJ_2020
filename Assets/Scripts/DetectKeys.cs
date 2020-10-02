using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKeys : MonoBehaviour
{
    public string key;
    public void OnTriggerStay2D(Collider2D other){
        if(other.name == key){
            Debug.Log("youpi");
        }
    }
}
