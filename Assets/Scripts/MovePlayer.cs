using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;

    private float _h;
    private float _v;
    private Rigidbody2D rb;
    public bool _gotObject;
    public GameObject objectgrabbed;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _h=Input.GetAxis("Horizontal");
        _v=Input.GetAxis("Vertical");
        rb.velocity = new Vector2 (_h,_v) * speed;

//pick n drop
        if (Input.GetButtonDown("Use") && !_gotObject && objectgrabbed!=null){
            objectgrabbed.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            objectgrabbed.transform.SetParent(gameObject.transform);
            objectgrabbed.transform.position = gameObject.transform.position;
            _gotObject=true;
        }
        else if(Input.GetButtonDown("Use") && _gotObject){
            objectgrabbed.GetComponent<BoxCollider2D>().enabled = true;
            objectgrabbed.transform.parent = null;
            objectgrabbed=null;
            _gotObject = false;
        }
        if(_gotObject && objectgrabbed==null){
            _gotObject= !_gotObject;
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Obstacle" && !_gotObject){
            objectgrabbed = other.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        if(!Input.GetButtonDown("Use") && !_gotObject){
            objectgrabbed=null;
        }
    }
}
