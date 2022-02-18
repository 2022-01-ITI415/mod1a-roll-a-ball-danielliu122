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
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity , 19);

        if(beingHandled )
        {
            StartCoroutine( HandleIt() );
        }
    }

    private IEnumerator HandleIt()
    {

        while (beingHandled) 
            {
                beingHandled = true;
                // wait 1 second
                yield return new WaitForSeconds( 1.0f );
                // movement
                Vector3 targetPos= GameObject.Find("Player").transform.position;
                Vector3 thisPos= gameObject.transform.position;
                Vector3 deltaPos= (targetPos-thisPos);

                //m_Rigidbody = GetComponent<Rigidbody>();
                

                float diceRoll = Random.Range(1f,6f);

                gameObject.GetComponent<Rigidbody>().AddForce(deltaPos);
                if (diceRoll >3.0f){
                    gameObject.GetComponent<Rigidbody>().AddForce(deltaPos);
                }
                yield return new WaitForSeconds( 1.0f );

                if (diceRoll == 1.0f){
                    gameObject.GetComponent<Rigidbody>().AddForce(targetPos);
                }

                yield return new WaitForSeconds( 1.0f );

                if (diceRoll == 3.0f){
                    gameObject.GetComponent<Rigidbody>().AddForce(thisPos);
                }
               
                //
            }
         beingHandled = false;
        }
}
