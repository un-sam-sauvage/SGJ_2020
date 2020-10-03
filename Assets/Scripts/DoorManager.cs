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
                DoorOpen(door);
            }
            else{
                DoorClose(door);
            }
        }
}
public void ConditionOrExclusive(){
    
    nbConditionGood=0;
    bool playOnce=true;
    for(int i=0; i<gameObject.transform.childCount;i++){
        bool condition ;
        condition = gameObject.transform.GetChild(i).GetComponent<DetectKeys>().condition;
        if(condition){
            nbConditionGood++;
        }
        else{
            DoorClose(door);
            DoorClose(door2);
        }
    }
    if(nbConditionGood == gameObject.transform.childCount){
        if(doorToOpen && playOnce){
            Debug.Log("porte1");
            DoorOpen(door);
            DoorClose(door2);
            doorToOpen= !doorToOpen;
            playOnce = false;
            
        }
        else if (playOnce){
            Debug.Log("porte2");
            DoorClose(door);
            DoorOpen(door2);
            doorToOpen= !doorToOpen;
            playOnce =false;
        }
    }
    else{
        DoorClose(door);
        DoorClose(door2);
    }
}
public void DoorOpen( GameObject door){
    door.GetComponent<SpriteRenderer>().color = new Color (door.GetComponent<SpriteRenderer>().color.r,door.GetComponent<SpriteRenderer>().color.g,door.GetComponent<SpriteRenderer>().color.b,.5f);
    door.GetComponent<BoxCollider2D>().enabled = false;
}
public void DoorClose(GameObject door){
    door.GetComponent<SpriteRenderer>().color = new Color (door.GetComponent<SpriteRenderer>().color.r,door.GetComponent<SpriteRenderer>().color.g,door.GetComponent<SpriteRenderer>().color.b,1);
    door.GetComponent<BoxCollider2D>().enabled =true;
}
}