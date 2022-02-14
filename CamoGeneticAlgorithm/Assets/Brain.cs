using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
    public int dnaLength = 1;
    public float timeAlive;
    public Vector3 startingPos;
    public float totalDistance;
    public DNA dna;

    private ThirdPersonCharacter mCharacter;
    private Vector3 m_Move;
    private bool m_jump;
    bool alive = true;

    private void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void getInitialPos(Vector3 sp)
    {
        startingPos = sp;
    }

    public void Init()
    {
        //initialize dna
        //0 forward
        //1 back
        //2 left
        //3 right
        //4 jump
        //5 crouch

        dna = new DNA(dnaLength, 6);
        mCharacter = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        totalDistance = 0;
        alive = true;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float h = 0;
        float v = 0;
        bool crouch = false;
        if (dna.GetGenes(0) == 0) v = 1;
        else if (dna.GetGenes(0) == 1) v = -1;
        else if (dna.GetGenes(0) == 2) h = -1;
        else if (dna.GetGenes(0) == 3) h = 1;
        else if (dna.GetGenes(0) == 4) m_jump = true;
        else if (dna.GetGenes(0) == 5) crouch = true;

        m_Move = v * Vector3.forward + h * Vector3.right;
        mCharacter.Move(m_Move, crouch, m_jump);
        m_jump = false;
        if (alive)
        {
            timeAlive += Time.deltaTime;
            totalDistance = Vector3.Distance(this.transform.position, startingPos);
        }
    }

}
