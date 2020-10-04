using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager5 : MonoBehaviour
{
    private GameObject player;
    private GameObject door;
    private GameObject door2;
    private GameObject door3;
    private GameObject door4;
    private GameObject door5;
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
    public int doorOpen3;
    public int doorOpen4;
    public int doorOpen5;
    public AudioMixerSnapshot currentLayer;
    public AudioMixer LowpassMaster;
    private float lerpLP;

    private void Awake()
    {
        LowpassMaster.SetFloat("lowpassMaster", 22000.00f);
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("Door");
        door2 = GameObject.FindGameObjectWithTag("Door2");
        door3 = GameObject.FindGameObjectWithTag("Door3");
        door4 = GameObject.FindGameObjectWithTag("Door4");
        door5 = GameObject.FindGameObjectWithTag("Door5");

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

        if (doorOpen == 0) // && doorOpen2 == 1 && doorOpen3 == 1)
        {
            layer2.TransitionTo(.2f);
            currentLayer = layer2;
         }


        //door 2
        doorOpen2 = door2.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen2 == 0)
        {
            layer4.TransitionTo(.2f);
            currentLayer = layer4;
        }

        //door 3 
        doorOpen3 = door3.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen3 == 0) // && doorOpen2 == 1 && doorOpen == 1)
        {
            layer5.TransitionTo(.2f);
            currentLayer = layer5;
        }

        //door 4
        doorOpen4 = door4.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen4 == 0) // && doorOpen2 == 1 && doorOpen == 1)
        {
            layer6.TransitionTo(.2f);
            currentLayer = layer6;
        }

        //door 5
        doorOpen5 = door5.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen5 == 0) // && doorOpen2 == 1 && doorOpen == 1)
        {
            layer8.TransitionTo(.2f);
            currentLayer = layer8;
        }


        //carry object
        carryObject = player.GetComponent<MovePlayer>()._gotObject;

        if (carryObject == true)
        {
             carryObj.TransitionTo(0.2f);
         //   lerpLP = Mathf.Lerp(22000f, 400f, 10000f);
         //   LowpassMaster.SetFloat("lowpassMaster", lerpLP);
        }
        else
        {
              currentLayer.TransitionTo(0.5f);
         //  lerpLP = Mathf.Lerp(400f, 22000f, 10000f);
         //   LowpassMaster.SetFloat("lowpassMaster", lerpLP);
        }

    }
}
