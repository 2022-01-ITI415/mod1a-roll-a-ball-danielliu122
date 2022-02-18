using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject projectileCube;
    Vector3 launcherCubePos;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 launcherCubePos= gameObject.transform.position;
        Vector3 targetPos= GameObject.Find("Player").transform.position;
        InvokeRepeating("spawnCube", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {        

    }

    void spawnCube()
    {
        // instantiate projectileCube
        Instantiate(projectileCube, new Vector3(37, 10, -10), Quaternion.identity);
  
        // tracking
        //Vector3 targetPos= GameObject.Find("Player").transform.position;
        Vector3 thisPos= gameObject.transform.position;
        Vector3 deltaPos= (targetPos-thisPos);

        //targetPos

        //m_Rigidbody = GetComponent<Rigidbody>();
        projectileCube.GetComponent<Rigidbody>().AddForce(3,7,0);
        projectileCube.GetComponent<Rigidbody>().AddForce(deltaPos);
        projectileCube.GetComponent<Rigidbody>().AddForce(deltaPos);
    }
}
