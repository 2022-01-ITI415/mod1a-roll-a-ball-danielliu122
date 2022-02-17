using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public GameObject mob;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnMob();
    }

    // Update is called once per frame
    void Update()
    {

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

        for (int i=0; i<6; i++){
            // Instantiate a Mob
            mob = Instantiate( mob );
            //

            // Start it at Random insideSphere
            Instantiate(mob, randomPosition(), Quaternion.identity);
        }   
    }
}
