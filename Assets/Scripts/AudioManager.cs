using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    private GameObject player;
    private GameObject door;
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
    public AudioMixerSnapshot currentLayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("Door");
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
        carryObject = player.GetComponent<MovePlayer>()._gotObject;

        if (carryObject == true)
        {
            carryObj.TransitionTo(0.2f);
        }
        else
        {
            currentLayer.TransitionTo(0.2f);
        }


        doorOpen = door.GetComponent<BoxCollider2D>().shapeCount;

        if (doorOpen == 0)
        {
            layer8.TransitionTo(1f);
            currentLayer = layer8;
         }


    }
}
