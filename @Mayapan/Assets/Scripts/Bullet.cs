﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 targetPos;
    public float speed = 10;
    public float arcHeight = 1;
    Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 nextPos;
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        nextPos = new Vector3(nextX, baseY + arc, transform.position.z);
        transform.rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;
        if(nextPos == targetPos)
        {
            Arrived();
        }
    }

    void Arrived()
    {
        Destroy(gameObject);
    }

    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
