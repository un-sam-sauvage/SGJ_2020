using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;

    private float _h;
    private float _v;
    private Rigidbody2D rb;
    private bool _gotObject;
    private GameObject objectgrabbed;
    private bool _startTimer=false;
    public float timer = 3f;
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

        if(Input.GetButton("Use") && _gotObject){
            _gotObject = false;
            objectgrabbed.GetComponent<BoxCollider2D>().enabled = true;
            objectgrabbed.transform.parent = null;
            objectgrabbed.transform.position += new Vector3 (_h*5 , _v*5,0);
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.GetComponent<BoxCollider2D>() && Input.GetButton("Use") && !_gotObject){
            other.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            other.transform.SetParent(gameObject.transform);
            other.transform.position = gameObject.transform.position + new Vector3(0,0,1);
            _gotObject=true;
            objectgrabbed=other.gameObject;
        }
    }
}
