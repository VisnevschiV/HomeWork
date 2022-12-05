using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public GameObject sword, gun, automat;
    private float attackTime=0;
    public Animator animator;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")|| Input.GetKeyDown("s")||Input.GetKeyDown("a")||Input.GetKeyDown("d")){
            animator.SetInteger("Movement",1);
        }else if(Input.GetKeyUp("w")|| Input.GetKeyUp("s")||Input.GetKeyUp("a")||Input.GetKeyUp("d")){
            animator.SetInteger("Movement",0);
        }
        if(animator.GetInteger("Movement")==1 && Input.GetKeyDown("left shift")){
            animator.SetInteger("Movement",2);
        }
        if(Input.GetMouseButtonDown(0)&& animator.GetInteger("Movement")==0){
            animator.SetBool("shoot",true);
            attackTime=Time.time;
        }
        if(Time.time - attackTime >0.5){
            animator.SetBool("shoot",false);
        }
        if(animator.GetInteger("Item")>0 && Input.GetMouseButtonDown(1) && animator.GetBool("aim")==false){
            animator.SetBool("aim",true);
        }else
        if(animator.GetInteger("Item")>0 && Input.GetMouseButtonDown(1)&& animator.GetBool("aim")==true){
            animator.SetBool("aim",false);
        }
        /*if(animator.GetCurrentAnimationStateInfo(0).IsName("TakeS") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime> 0.5){
            if(animator.GetInteger("Item")!=0){
                sword.SetActive(false);
            }else{
                sword.SetActive(true);
            }
        }
        if(animator.GetCurrentAnimationStateInfo(0).IsName("TakeG") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime> 0.5){
            if(animator.GetInteger("Item")!=1){
                gun.SetActive(false);
            }else{
                gun.SetActive(true);
            }
        }
        if(animator.GetCurrentAnimationStateInfo(0).IsName("TakeA") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime> 0.5){
            if(animator.GetInteger("Item")!=2){
                automat.SetActive(false);
            }else{
                automat.SetActive(true);
            }
        }*/
    }

    public void ChangeWeapon(int weapon){
        animator.SetInteger("Item",weapon);
        switch(weapon){
            case 0:
                sword.SetActive(true);
                gun.SetActive(false);
                automat.SetActive(false);
            break;
            case 1:
                sword.SetActive(false);
                gun.SetActive(true);
                automat.SetActive(false);
            break;
            case 2:
                sword.SetActive(false);
                gun.SetActive(false);
                automat.SetActive(true);
            break;
        }
        
    }
}
