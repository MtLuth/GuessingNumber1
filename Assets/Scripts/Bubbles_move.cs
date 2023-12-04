using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bubbles_move : MonoBehaviour
{
    public float force = 10f; // Độ lớn của lực được áp dụng
    private Rigidbody2D rb;
    private float maxHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Áp dụng lực ngay khi đối tượng bắt đầu
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        maxHeight = UnityEngine.Random.Range(280, 330);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= maxHeight)
        {
            Destroy(this.gameObject);
        }
    }
}
