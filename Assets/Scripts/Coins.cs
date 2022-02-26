using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioClip myVoice;
    public float rotSpeed = 15f;
        

    private void Update()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("Player")) 
        {
            other.GetComponent<AudioSource>().PlayOneShot(myVoice);
            Destroy(gameObject);
        }
    }
}
