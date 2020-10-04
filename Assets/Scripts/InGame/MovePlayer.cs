using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    private Vector2 screenBounds;
    private float _h;
    private float _v;
    float objectWidth, objectHeight;
    private Rigidbody2D rb;
    public bool _gotObject;
    public GameObject objectgrabbed;
    public AudioSource pick;
    public AudioSource drop;
    public GameObject objectGrabbedPos;

public string scene;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        scene = SceneManager.GetActiveScene().name;
            }

    // Update is called once per frame
    void Update()
    {
        _h=Input.GetAxis("Horizontal");
        _v=Input.GetAxis("Vertical");
        rb.velocity = new Vector2 (_h,_v) * speed;
        Vector3 viewPos = transform.position;
        viewPos.x= Mathf.Clamp(viewPos.x, screenBounds.x*-1+ objectWidth, screenBounds.x- objectWidth);
        viewPos.y= Mathf.Clamp(viewPos.y, screenBounds.y*-1+ objectHeight, screenBounds.y- objectHeight);
        transform.position= viewPos;
        if(_v <0){
            transform.rotation = Quaternion.Euler(0,0,-90);
        }
        if(_v >0){
            transform.rotation = Quaternion.Euler(0,0,90);
        }
        if(_h >0){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(_h <0){
            transform.rotation = Quaternion.Euler(0,0,-180);
        }

        if(Input.GetButtonDown("Restart")){
            SceneManager.LoadScene(scene);
        }
//pick n drop
        //pick
        if (Input.GetButtonDown("Use") && !_gotObject && objectgrabbed!=null){
            pick.Play();
            objectgrabbed.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            objectgrabbed.transform.SetParent(objectGrabbedPos.transform);
            objectgrabbed.transform.position = objectGrabbedPos.transform.position;
            _gotObject=true;
        }
        //drop
        else if(Input.GetButtonDown("Use") && _gotObject){
            drop.Play();
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
