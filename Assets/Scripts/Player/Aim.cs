using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Aim : MonoBehaviour
{
    [SerializeField] private GameObject aimCamera, prefab;
    public Transform spawn;
    private bool aim;
    // Start is called before the first frame update
    void Start()
    {
        aim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            if(aim){
                aimCamera.gameObject.SetActive (false);
                aim = false;
            }else{
                aimCamera.gameObject.SetActive (true);
                aim = true;
            }
        }
        if(aim && Input.GetMouseButtonDown(0)){
            Instantiate(prefab, spawn.position ,Quaternion.Euler(-0,-0,0));
        }
    }
}
