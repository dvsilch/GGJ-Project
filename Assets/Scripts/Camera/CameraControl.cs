using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    private CinemachineConfiner2D confiner2D;
    public Transform target;
    public Transform backGround,middleGround;
    private Vector2 lastpos;

    private void Awake(){
        confiner2D=GetComponent<CinemachineConfiner2D>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
   private  void Start()
    {
        lastpos=transform.position;
        GetNewCameraBound();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position=new Vector3(target.position.x,target.position.y,transform.position.z);
        Vector2 amountToMove=new Vector2(transform.position.x-lastpos.x,transform.position.y-lastpos.y);
        backGround.position+=new Vector3(amountToMove.x,amountToMove.y,0);
        middleGround.position+=new Vector3(amountToMove.x*0.5f,amountToMove.y*0.5f,0);
        lastpos=transform.position;

    }

    private void GetNewCameraBound(){
        var obj=GameObject.FindGameObjectWithTag("Bound");
        if(obj==null)
        {return;}
        confiner2D.m_BoundingShape2D=obj.GetComponent<Collider2D>();
        confiner2D.InvalidateCache();
    }
}
