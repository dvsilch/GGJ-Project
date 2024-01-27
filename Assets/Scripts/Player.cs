using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    public bool isLaugh;

    static List<Player> m_Players = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        m_Players.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > .1f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") < -.1f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Tab))
        {
            
        }
    }
}
