using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    //[SerializeField]
    //Vector2 parallaxmultiplier;
    //[SerializeField]
    //private Transform cameratranform;
    //private Vector3 lastcameraposition;
    //private float textureunitsizex;
    //private float textureunitsizey;
    //private void start()
    //{
    //   // cameratranform = Camera.main.transform;
    //    lastcameraposition = cameratranform.position;
    //    if (transform.childCount == 0)
    //    {
    //        Sprite spritex = GetComponent<SpriteRenderer>().sprite;
    //        Texture2D texturex = spritex.texture;
    //        textureunitsizex = texturex.width / spritex.pixelsPerUnit;
    //        textureunitsizey = texturex.width / spritex.pixelsPerUnit;
    //    }
    //    else
    //    {
    //        Sprite spritex = GetComponent<SpriteRenderer>().sprite;
    //        Texture2D texturex = spritex.texture;
    //        textureunitsizex = texturex.width / spritex.pixelsPerUnit;
    //        textureunitsizey = texturex.width / spritex.pixelsPerUnit;
    //    }

    //}
    //private void LateUpdate()
    //{
    //    Vector3 deltamovement = cameratranform.position - lastcameraposition;
    //    transform.position = new Vector3(deltamovement.x * parallaxmultiplier.x, deltamovement.y * parallaxmultiplier.y);
    //    lastcameraposition = cameratranform.position;
    //    if (Mathf.Abs(cameratranform.position.x - transform.position.x) >= textureunitsizex)
    //    {
    //        float offesetpsotionx = (cameratranform.position.x - transform.position.x) % textureunitsizex;
    //        transform.position = new Vector3(cameratranform.position.x + offesetpsotionx, transform.position.y);

    //    }
    //    if (Mathf.Abs(cameratranform.position.y - transform.position.y) >= textureunitsizey)
    //    {
    //        float offesetpsotiony = (cameratranform.position.y - transform.position.y) % textureunitsizey;
    //        transform.position = new Vector3(cameratranform.position.y + offesetpsotiony, transform.position.y);


    //    }
    //}
    private float startingPosition;
    private float size;
    private float sizey;
    public GameObject camera;
    public float speed;
    public bool horizontal;
    public bool vertical;
    private void Start()
    {

        size = GetComponent<SpriteRenderer>().bounds.size.x;
        // size = transform.localScale.x;

        sizey = GetComponent<SpriteRenderer>().bounds.size.y;

        startingPosition = transform.position.x;
    }

    private void FixedUpdate()
    {
        var tempSpeed = camera.transform.position.x * (1 - speed);
        var distance = camera.transform.position.x * speed;
        var tempSpeedy = camera.transform.position.y * (1 - speed);
        var distancey = camera.transform.position.y * speed;
        transform.position = new Vector3(startingPosition + distance, transform.position.y, transform.position.z);
        if (horizontal)
      {
            if (tempSpeed > startingPosition + size / 2)
            {
                startingPosition += size;
            }
            else if (tempSpeed < startingPosition - size / 2)
            {
                startingPosition -= size;
            }
      }
        if (vertical)
        {
            transform.position = new Vector3(transform.position.x, camera.transform.position.y, transform.position.z);
        }

    }



}
