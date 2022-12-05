using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private string name;
    public int lvl, zombiesSpawned, zombiesWaiting, maxZombieNr;
    public GameObject player;
    public GameObject zombie;
    public GameObject lost, won, canvas;
    public List<Transform> position = new List<Transform>();
    private float myTime, lastTime;
    // Start is called before the first frame update
    void Start()
    {
        string[] lines = System.IO.File.ReadAllLines ("Assets/files/savings.txt");
        Debug.Log(lines[0]);
        name = lines[0].Split(",")[0];
        lvl=  int.Parse(lines[0].Split(",")[1]);
        UploadLVL();
        
    }

    // Update is called once per frame
    void Update()
    {
         myTime=Time.time;
        if(zombiesSpawned<lvl){
            Spawn();}
        
       if( player.GetComponent<Player>().hp<1){
            Lost();
       }
       Debug.Log(Time.time-lastTime);
       if(Time.time-lastTime>10){
            Won();
       }
    }
    void Spawn(){

        Instantiate(zombie, position[1].position,Quaternion.Euler(-0,-0,0));
        zombiesSpawned++;
    }
    void Lost(){
        Time.timeScale=0;
        Cursor.lockState = CursorLockMode.Confined;
        canvas.SetActive(true);
        lost.SetActive(true);
        won.SetActive(false);
    }
    void Won(){
        Time.timeScale=0;
        Cursor.lockState = CursorLockMode.Confined;
        canvas.SetActive(true);
        lost.SetActive(false);
        won.SetActive(true);
        lvl++;

    }
     public void UploadLVL(){
        Destroy(GameObject.Find("zombie(Clone)"));
        maxZombieNr=3*lvl;
        zombiesWaiting=4*lvl;
        canvas.SetActive(false);
        zombiesSpawned=0;
       lastTime = Time.time;
        lastTime=Time.time;
    }

}
