using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour
{
    public int hp=100;
    // Start is called before the first frame update
   
    void GetDmg(int dmg){
        hp=hp-dmg;
    }
}
