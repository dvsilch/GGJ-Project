using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public bool catched;

    public GameObject player;

    [SerializeField]
    BehaviorTree behaviorTree;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        Debug.Log("Monster.OnEnable");
    }

    // Update is called once per frame
    void Update()
    {
        if (!catched)
        {
            var v = transform.position - player.transform.position;
            if (v.sqrMagnitude < 5)
            {
                Debug.Log("catched");
                catched = true;
            }
            else
            {
                int x = v.x > 0 ? -1 : 1;
                transform.position += new Vector3(x * 0.01f, 0, 0);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject == player)
    //    {
    //        Debug.Log("catched");
    //        catched = true;
    //    }
    //}
}
