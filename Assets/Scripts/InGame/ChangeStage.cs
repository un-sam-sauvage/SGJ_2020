using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStage : MonoBehaviour
{
    public int indexLevel;
    public Sprite newFrame;
    void Start(){
        indexLevel = SceneManager.GetActiveScene().buildIndex;
        indexLevel++;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            GetComponent<SpriteRenderer>().sprite = newFrame;
            SceneManager.LoadScene(indexLevel++);
        }
    }
}
