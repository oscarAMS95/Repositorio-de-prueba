using UnityEngine;
using System.Collections;
 
public class Item_Anim : MonoBehaviour
{
	float speed = 5f;
	float height = 0.005f;

    void Update()
    {
        float newY = (Mathf.Sin(Time.time * speed) % height + transform.position.y);
        transform.position = new Vector3(transform.position.x, newY , transform.position.z) ;
	}
}