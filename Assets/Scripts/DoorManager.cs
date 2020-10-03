using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door;
    public GameObject door2;
    int nbConditionGood;
    public List<string> keys;
    public List<string> keys2;
    public bool conditionAnd,conditionOrExclusive,conditionNot;
    //true = door1 false = door2
    bool doorToOpen = true;


void Update(){

}
public void TestCondition(){
    if(conditionAnd){
        ConditionAnd();
    }
    else if(conditionOrExclusive){
        ConditionOrExclusive();
    }
    else if (conditionNot){

    }
}
public void ConditionAnd(){
        nbConditionGood = 0;
        for (int i = 0; i <gameObject.transform.childCount ; i++)
        {
            if(gameObject.transform.GetChild(i).GetComponent<DetectKeys>()){
                bool condition;
                condition = gameObject.transform.GetChild(i).GetComponent<DetectKeys>().condition;
                if(condition){
                    nbConditionGood++;
                }
            }
            if(nbConditionGood == gameObject.transform.childCount){
                door.SetActive(false);
            }
            else{
                door.SetActive(true);
            }
        }
}
public void ConditionOrExclusive(){
    
    nbConditionGood=0;
    bool playOnce=true;
    for(int i=0; i<gameObject.transform.childCount;i++){
        if(gameObject.transform.GetChild(i).GetComponent<DetectKeys>()){
            bool condition ;
            condition = gameObject.transform.GetChild(i).GetComponent<DetectKeys>().condition;
            if(condition){
                nbConditionGood++;
            }
            else{
                door.SetActive(true);
                door2.SetActive(true);
            }
        }
    }
    if(nbConditionGood == gameObject.transform.childCount){
        if(doorToOpen && playOnce){
            Debug.Log("porte1");
            door.SetActive(false);
            door2.SetActive(true);
            doorToOpen= !doorToOpen;
            playOnce = false;
            
        }
        else if (playOnce){
            Debug.Log("porte2");
            door.SetActive(true);
            door2.SetActive(false);
            doorToOpen= !doorToOpen;
            playOnce =false;
        }
    }
    else{
        door.SetActive(true);
        door2.SetActive(true);
    }
}
}