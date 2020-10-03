using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<GameObject> door;
    public List<GameObject> door2;
    int nbConditionGood;
    public List<string> keys;
    public List<string> keys2;
    public bool conditionAnd,conditionOr,conditionNot;
    [HideInInspector]
    public int index;

public void TestCondition(){
    if(conditionAnd){
        ConditionAnd();
    }
    else if (conditionOr){
        ConditionOr();
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
            for(int j = 0; j<door.Count;j++){
                DoorOpen(door[j]);
            }
        }
        else{
            for(int j = 0; j<door.Count;j++){
                DoorClose(door[j]);
            }
        }
    }
}
public void ConditionOr(){
    if(index ==0){
        for(int i=0; i<door.Count;i++){
            DoorOpen(door[i]);
        }
    }
    if(index == 1){
        for(int i=0; i<door.Count;i++){
            DoorOpen(door2[i]);
        }
    }
    if(!GetComponentInChildren<DetectKeys>().condition){
        for(int i=0; i<door.Count;i++){
            DoorClose(door2[i]);
            DoorClose(door[i]);
        }
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