using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject player;

    public BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  /*  void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            SpawnBoxCollider();
            Debug.Log("1");
        }
    }

    void SpawnBoxCollider() 
    {
        Vector2 box = new Vector2();
        Instantiate(boxCollider, box, Quaternion.identity);
    }*/
}
