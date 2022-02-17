using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    private bool beingHandled = true;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(beingHandled )
        {
            StartCoroutine( HandleIt() );
        }
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity , 25);
    }

    private IEnumerator HandleIt()
    {

        while (beingHandled) 
            {
                beingHandled = true;
                // wait 2 seconds
                yield return new WaitForSeconds( 2.0f );
                // movement
                Vector3 targetPos= GameObject.Find("Player").transform.position;
                Vector3 thisPos= gameObject.transform.position;
                Vector3 deltaPos= (targetPos-thisPos);

                //m_Rigidbody = GetComponent<Rigidbody>();
                gameObject.GetComponent<Rigidbody>().AddForce(deltaPos);

                float diceRoll = Random.Range(1f,6f);

                if (diceRoll == 1){
                    gameObject.GetComponent<Rigidbody>().AddForce(targetPos);
                }
                if (diceRoll == 2){
                    gameObject.GetComponent<Rigidbody>().AddForce(thisPos);
                }
            }
            beingHandled = false;
        }
}
