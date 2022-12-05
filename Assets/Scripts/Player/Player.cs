using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Alive
{
    private int weapon;
    private int g_amo, a_amo;
    public PlayerAnimations animator;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        weapon=0;
        g_amo = 0;
        a_amo=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            ChangeWeapon(-1);
        }
        if(Input.GetKeyDown("e")){
            ChangeWeapon(1);
        }
    }

    void ChangeWeapon(int changer){
        weapon = weapon+changer;
        if(weapon==3){
            weapon=0;
        }
        if(weapon==-1){
            weapon=2;
        }
        animator.ChangeWeapon(weapon);
    }
}
