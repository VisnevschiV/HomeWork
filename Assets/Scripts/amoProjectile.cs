using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amoProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 enemy;

    void Start()
    {
        enemy = GameObject.Find("focus").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemy, 18 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
            if(collision.gameObject.tag=="enemy"){
                collision.gameObject.GetComponent<MoveTo>().health-=50;
            }
            Destroy(gameObject);
    }
}
