using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStage : MonoBehaviour
{
    public string sceneToLoad;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
