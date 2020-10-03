using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door;
    int nbConditionGood;
    public List<string> keys;
    public List<string> keys2;


void Update(){

}
public void TestCondition(){
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
}