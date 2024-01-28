using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneStart : MonoBehaviour
{
    public Image xunzhang;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    // void Awake()
    // {
    //     xunzhang=GetComponent<Image>();
    // }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void NextScene(){
        Color color=xunzhang.color;
        // Debug.Log(xunzhang.color.a);
        // SceneManager.LoadScene(1);
        color.a=1;
        xunzhang.color=color;
        TimeWait();
        // SceneManager.LoadScene(2);
    }

    void TimeWait(){
        StartCoroutine(ChangeScene(2f));
    }

    IEnumerator ChangeScene(float i){
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(2);
    }
    

}
