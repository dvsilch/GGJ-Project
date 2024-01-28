using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public PlayerInputControl inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    private PhycicsCheck physicsCheck;


    [Header("基本参数")]
    public float speed;
    public float changedSpeed = 4;
    public float notChangeSpeed = 5.2f;

    public float jumpForce;
    public bool Change;
    public bool isChooseplayer;
    public new CinemachineVirtualCamera camera;
    public CinemachineVirtualCamera camera_up;
    public CinemachineVirtualCamera camera_down;

    private void Awake()
    {
        inputControl = new PlayerInputControl();
        physicsCheck=GetComponent<PhycicsCheck>();
        inputControl.Gameplay.Jump.started += Jump;
        inputControl.Gameplay.Change.started += PlayerStateChange;
        inputControl.Gameplay.isChoose.started += PlayerChoose;
        camera_up.enabled=false;
        camera_down.enabled=true;
    }


    private void OnEnable() {
        inputControl.Enable();
    }
    
    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        inputControl.Disable();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (isChooseplayer)
            inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        if(isChooseplayer){
            camera.enabled=true;
            Move();
        }
    }

    public void Move(){
        
        transform.localPosition=new Vector3(transform.localPosition.x + inputDirection.x * speed * Time.deltaTime, transform.localPosition.y);
        int faceDir=(int)transform.localScale.x;
        if(inputDirection.x>0){
            faceDir=1;
        }
        if(inputDirection.x<0){
            faceDir=-1;
        }
        transform.localScale=new Vector3(faceDir,1,1);
        
        
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        //Debug.Log("JUMP");
        if(isChooseplayer && physicsCheck.isGround){
            rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
        }
        
    }

    private void PlayerStateChange(InputAction.CallbackContext context)
    {
        // Debug.Log("Change");
        Change=!Change;
        if(Change){
            speed=changedSpeed;
            rb.gravityScale=4;
        }
        else{
            speed=notChangeSpeed;
            rb.gravityScale=6;
        }
        
    }

    private void PlayerChoose(InputAction.CallbackContext context)
    {
        // Debug.Log("Choose");
        isChooseplayer=!isChooseplayer;
        if(!isChooseplayer){
            rb.velocity=new Vector2(0,0);
            camera.enabled=false;
        }
    }
}
