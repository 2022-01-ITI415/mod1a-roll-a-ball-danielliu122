using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public GameObject mob;
    int count= 0;
    bool inProgress = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnMob", 2.0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (count>10){
            CancelInvoke() ;
        }
    }

    Vector3 randomPosition()
    {
        int x,y,z;
        x = Random.Range(-20,20);
        y = Random.Range(0,0);
        z = Random.Range(-20,20);

        if (x> -2 && x<0) {
            x += Random.Range(-20,-2);
        }
        else if (x> 0 && x<2) {
            x += Random.Range(2,20);
        }

        if (z> -2 && z<0) {
            z += Random.Range(-20,-2);
        }
        else if (z> 0 && z<2) {
            z += Random.Range(2,20);
        }

        return new Vector3(x,y+1,z);
    }

    void spawnMob(){
            Instantiate(mob, randomPosition(), Quaternion.identity);
            count+=1;
        }   
}
