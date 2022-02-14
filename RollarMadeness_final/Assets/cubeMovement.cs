using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMovement : MonoBehaviour
{
    private float speed = 30f;
    private float time = 0f;
    private Vector3 moveDir = Vector3.zero;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame  Horizontal
    void Update()
    {
        CharacterController Controller = gameObject.GetComponent<CharacterController>();
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
       // moveDir = transform.TransformDirection(moveDir);
        moveDir *= speed;
        transform.Translate(moveDir * Time.deltaTime);
        time += Time.deltaTime;
        if (time >= 10)
        {
            speed += 1;
            time = 0;
        }
        // Controller.Move(moveDir * Time.deltaTime);
    }
    //private int movePower = 0;
    //private float updatePower;
   
    //private float h, v;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    movePower = 1;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    h = Input.GetAxisRaw("Horizontal");
    //    v = Input.GetAxisRaw("Vertical");
    //    transform.Translate(movePower * h, 0f, movePower * v);
    //    
    //    
    //}
}