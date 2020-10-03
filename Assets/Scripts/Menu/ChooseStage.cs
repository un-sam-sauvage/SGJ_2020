using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseStage : MonoBehaviour
{
    public GameObject panelChooseStage;
public void Stage1(){
    SceneManager.LoadScene("Stage1");
}
public void Stage2(){
    SceneManager.LoadScene("Stage2");
}
public void Stage3(){
    SceneManager.LoadScene("Stage3");
}
public void Stage4(){
    SceneManager.LoadScene("Stage4");
}
public void Stage5(){
    SceneManager.LoadScene("Stage5");
}
public void ShowPanelStage(){
    panelChooseStage.SetActive(true);
}
/*public void Stage(){
    SceneManager.LoadScene("Stage");
}*/

}
