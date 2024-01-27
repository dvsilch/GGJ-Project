using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhycicsCheck phycicsCheck;
    private PlayerController playerController;
     /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public void Awake()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        phycicsCheck=GetComponent<PhycicsCheck>();
        playerController=GetComponent<PlayerController>();
    }

    public /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        setAnamition();
    }

    public void setAnamition(){
        // Debug.Log("Animatior");
        anim.SetFloat("velocityX",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY",rb.velocity.y);
        anim.SetBool("isGround",phycicsCheck.isGround);
        anim.SetBool("isChange",playerController.Change);
    }

}
