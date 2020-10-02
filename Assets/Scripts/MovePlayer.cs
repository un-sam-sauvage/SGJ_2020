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
    private GameObject objectgrabbed;
    public bool onContactObject = false;
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
        if (onContactObject && Input.GetButtonDown("Use") && !_gotObject){
            onContactObject=false;
            objectgrabbed.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            objectgrabbed.transform.SetParent(gameObject.transform);
            objectgrabbed.transform.position = gameObject.transform.position;
            _gotObject=true;
        }
        else if(!onContactObject &&Input.GetButtonDown("Use") && _gotObject){
            _gotObject = false;
            objectgrabbed.GetComponent<BoxCollider2D>().enabled = true;
            objectgrabbed.transform.parent = null;
            objectgrabbed=null;
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        onContactObject=true;
        objectgrabbed=other.gameObject;
    }
}
