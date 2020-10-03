using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager3 : MonoBehaviour
{
    private GameObject player;
    private GameObject door;
    private GameObject door2;
    private GameObject door3;
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
    public AudioMixerSnapshot currentLayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("Door");
        door2 = GameObject.FindGameObjectWithTag("Door2");
        door3 = GameObject.FindGameObjectWithTag("Door3");

    }
    // Start is called before the first frame update
    void Start()
    {
        layer1.TransitionTo(3f);
        currentLayer = layer1;
    }

    // Update is called once per frame
    void Update()
    {

     


        //door 
        doorOpen = door.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen == 0 && doorOpen2 == 1 && doorOpen3 == 1)
        {
            layer3.TransitionTo(1f);
            currentLayer = layer3;
         }


        //door 2
        doorOpen2 = door2.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen2 == 0)
        {
            layer8.TransitionTo(1f);
            currentLayer = layer5;
        }

        //door 3 
        doorOpen3 = door3.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen3 == 0 && doorOpen2 == 1 && doorOpen == 1)
        {
            layer8.TransitionTo(1f);
            currentLayer = layer8;
        }


        //carry object
        carryObject = player.GetComponent<MovePlayer>()._gotObject;

        if (carryObject == true)
        {
            carryObj.TransitionTo(0.2f);
        }
        else
        {
            currentLayer.TransitionTo(0.5f);
        }

    }
}
