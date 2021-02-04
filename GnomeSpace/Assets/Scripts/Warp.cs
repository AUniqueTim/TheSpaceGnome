using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] Vector3 originalPos;
    [SerializeField] GameObject player;
    private void Awake()
    {
        originalPos = player.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (player != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                player.transform.position = originalPos;
            }
        }
        
    }
}
