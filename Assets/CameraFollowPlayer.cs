using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
       
    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 offsetvalue = new Vector2(offset.x, offset.y);
       
       // transform.position = new Vector3(playerTransform.position.x+offset.x, playerTransform.position.y+offset.y, transform.position.z); ;
        
    }
}
