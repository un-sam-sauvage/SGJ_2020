using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseStage : MonoBehaviour
{
    public GameObject panelChooseStage;

public void ShowPanelStage(){
    panelChooseStage.SetActive(true);
}
public void Quit(){
    Application.Quit();
}
public void Back(){
    panelChooseStage.SetActive (false);
}

public void Stage1(){
    SceneManager.LoadScene(1);
}
public void Stage2(){
    SceneManager.LoadScene(2);
}
public void Stage3(){
    SceneManager.LoadScene(3);
}
public void Stage4(){
    SceneManager.LoadScene(4);
}
public void Stage5(){
    SceneManager.LoadScene(5);
}

public void Stage6(){
    SceneManager.LoadScene(6);
}
public void Stage7(){
    SceneManager.LoadScene(7);
}
public void Stage8(){
    SceneManager.LoadScene(8);
}
public void Stage9(){
    SceneManager.LoadScene(9);
}
public void Stage10(){
    SceneManager.LoadScene(10);
}
public void Stage11(){
    SceneManager.LoadScene(11);
}
public void Stage12(){
    SceneManager.LoadScene(12);
}
public void Stage13(){
    SceneManager.LoadScene(13);
}
public void Stage14(){
    SceneManager.LoadScene(14);
}
public void Stage15(){
    SceneManager.LoadScene(15);
}
public void Stage16(){
    SceneManager.LoadScene(16);
}
}
