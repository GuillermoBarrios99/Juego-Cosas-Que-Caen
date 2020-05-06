using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public GameObject GC;
    public AudioSource AS;
    public AudioClip GoodSound;
    public AudioClip BadSound;
    public Animator AR;
    public SpriteRenderer SR;

    public float AnimationOverride;
    // Start is called before the first frame update
    void Start()
    {
        AnimationOverride = 0;
        AS = GetComponent<AudioSource>();
        AR = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float Move = Input.GetAxis("Horizontal")*Speed;
        transform.position += new Vector3(Move,0,0);
        if (transform.position.x > 10) transform.position = new Vector3(10, -3.5f, 0);
        if (transform.position.x < -10) transform.position = new Vector3(-10, -3.5f, 0);

        if (AnimationOverride<0){
            if (Input.GetAxis("Horizontal") == 0){
                AR.Play("AnimacionIdle", 0, float.NegativeInfinity);
            } else
            if (Input.GetAxis("Horizontal") > 0.5){
                AR.Play("AnimacionDeCaminata", 0, float.NegativeInfinity);
                SR.flipX=true;
            } else
            if (Input.GetAxis("Horizontal") < -0.5){
                AR.Play("AnimacionDeCaminata", 0, float.NegativeInfinity);
                SR.flipX=false;
            }
        }
        AnimationOverride--;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag.Equals("Box")){
            GC.GetComponent<GameController>().Points++;
            Destroy(col.gameObject);
            AS.clip = BadSound;
            AnimationOverride = 30;
            AR.Play("AnimacionGanar", 0, float.NegativeInfinity);
        }
        if (col.gameObject.tag.Equals("BadBox")){
            GC.GetComponent<GameController>().Points--;
            Destroy(col.gameObject);
            AS.clip = GoodSound;
            AnimationOverride = 30;
            AR.Play("AnimacionDeError", 0, float.NegativeInfinity);
        }
        AS.Play();
    }
}
