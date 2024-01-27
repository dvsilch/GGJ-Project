using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mainCamera;
    public float mapWidth;
    public int mapNums;
    private float totalWidth;
    // Vector3 initPos;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mapWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        totalWidth = mapWidth * mapNums;
        // initPos = transform.position;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void LateUpdate()
    {
        Vector3 tempPosition = transform.position;
        if (mainCamera.transform.position.x > transform.position.x + totalWidth / 2)
        {
            tempPosition.x += totalWidth;
            transform.position = tempPosition;
        }
        else if (mainCamera.transform.position.x < transform.position.x - totalWidth / 2)
        {
            tempPosition.x -= totalWidth;
            transform.position = tempPosition;
        }
        // Debug.Log("player");
        //Debug.Log(transform);
        // Debug.Log("maincinema");
        // Debug.Log(mainCamera.transform.position.x);
        // float totalWidth = mapWidth*2f;// * backGroundNum;
        // float distZ = player.position.z - initPos.z;//实时计算玩家与插入点的距理
        // int n = Mathf.RoundToInt(distZ / totalWidth);//四舍五入一下 

        // var pos = initPos;   
        // pos.z += n * totalWidth;
        // transform.position = pos;
    }
}
