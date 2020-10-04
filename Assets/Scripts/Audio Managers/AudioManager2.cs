using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager2 : MonoBehaviour
{
    private GameObject player;
    private GameObject door;
    private GameObject door2;
    public AudioMixerSnapshot carryObj;
    public AudioMixerSnapshot layer1;
    public AudioMixerSnapshot layer2;
    public AudioMixerSnapshot layer3;
    public AudioMixerSnapshot layer4;
    public AudioMixerSnapshot layer5;
    public AudioMixerSnapshot layer6;
    public AudioMixerSnapshot layer7;
    public AudioMixerSnapshot layer8;
    public bool carryObject;
    public int doorOpen;
    public int doorOpen2;
    public AudioMixerSnapshot currentLayer;
    public AudioMixer LowpassMaster;
    private float lerpLP;

    private void Awake()
    {
        LowpassMaster.SetFloat("lowpassMaster", 22000.00f);
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("Door");
        door2 = GameObject.FindGameObjectWithTag("Door2");

    }
    // Start is called before the first frame update
    void Start()
    {
        layer1.TransitionTo(1f);
        currentLayer = layer1;
    }

    // Update is called once per frame
    void Update()
    {

     


        //door 
        doorOpen = door.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen == 0)
        {
            layer5.TransitionTo(0.2f);
            currentLayer = layer5;
         }

        //door2
        doorOpen2 = door2.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen2 == 0)
        {
            layer8.TransitionTo(0.2f);
            currentLayer = layer8;
        }



        //carry object
        carryObject = player.GetComponent<MovePlayer>()._gotObject;

        if (carryObject == true)
        {
                carryObj.TransitionTo(0.2f);
          //  lerpLP = Mathf.Lerp(22000f, 400f, 5f);
         //   LowpassMaster.SetFloat("lowpassMaster", lerpLP);
        }
        else
        {
               currentLayer.TransitionTo(0.5f);
         //   lerpLP = Mathf.Lerp(400f, 22000f, 5f);
          //  LowpassMaster.SetFloat("lowpassMaster", lerpLP);
        }

    }
}
