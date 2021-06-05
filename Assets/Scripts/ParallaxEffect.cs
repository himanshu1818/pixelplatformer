using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    //[SerializeField]
    //Vector2 parallaxMultiplier;
    //private Transform cameraTranform;
    //private Vector3 lastCameraPosition;
    //private float textureUnitSizex;
    //private float textureUnitSizeY;
    //private void Start()
    //{
    //    cameraTranform = Camera.main.transform;
    //    lastCameraPosition = cameraTranform.position;
    //    if (transform.childCount == 0)
    //    {
    //        Sprite spritex = GetComponent<SpriteRenderer>().sprite;
    //        Texture2D texturex = spritex.texture;
    //        textureUnitSizex = texturex.width / spritex.pixelsPerUnit;
    //        textureUnitSizeY = texturex.width / spritex.pixelsPerUnit;
    //    }
    //    else
    //    {
    //        Sprite sprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    //        Texture2D texture = sprite.texture;
    //        textureUnitSizex = texture.width / sprite.pixelsPerUnit;
    //        textureUnitSizeY = texture.width / sprite.pixelsPerUnit;
    //    }

    //}
    //private void LateUpdate()
    //{
    //    Vector3 deltaMovement = cameraTranform.position - lastCameraPosition;
    //    transform.position = new Vector3(deltaMovement.x * parallaxMultiplier.x, deltaMovement.y * parallaxMultiplier.y);
    //    lastCameraPosition = cameraTranform.position;
    //    if (Mathf.Abs(cameraTranform.position.x - transform.position.x) >= textureUnitSizex)
    //    {
    //        float offesetPsotionX = (cameraTranform.position.x - transform.position.x) % textureUnitSizex;
    //        transform.position = new Vector3(cameraTranform.position.x + offesetPsotionX, transform.position.y);

    //    }
    //    if (Mathf.Abs(cameraTranform.position.y - transform.position.y) >= textureUnitSizeY)
    //    {
    //        float offesetPsotionY = (cameraTranform.position.y - transform.position.y) % textureUnitSizeY;
    //        transform.position = new Vector3(cameraTranform.position.y + offesetPsotionY, transform.position.y);


    //    }
    //}
    private float startingPosition;
    private float size;
    public GameObject camera;
    public float speed;
    private void Start()
    {
       
            size = GetComponent<SpriteRenderer>().bounds.size.x;
           // size = transform.localScale.x;
       
       
        
        startingPosition = transform.position.x;
    }

    private void FixedUpdate()
    {
        var tempSpeed = camera.transform.position.x * (1 - speed);
        var distance = camera.transform.position.x * speed;
        transform.position = new Vector3(startingPosition + distance, transform.position.y, transform.position.z);
        if (tempSpeed > startingPosition + size )
        {
            startingPosition += size;
        }
        else if (tempSpeed < startingPosition - size )
        {
            startingPosition -= size;
        }
    }



}
