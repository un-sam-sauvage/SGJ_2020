using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class piedestralGlow : MonoBehaviour
{
    public Color color;
    void Start(){
        GetComponent<SpriteRenderer>().DOColor(color,1f).SetLoops(2300, LoopType.Yoyo).SetSpeedBased();
    }
}
