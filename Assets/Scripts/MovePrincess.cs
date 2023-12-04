using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePrincess : MonoBehaviour
{
    private int velocity = 100;
    public float totalDistance = 0f;
    public float v_move;
    public string current_lives;
    public Rigidbody2D rb;
    public GameObject burning;

    public Text NumberOfLives;

    // Update is called once per frame
    private void Start()
    {
        totalDistance = 0f;
        current_lives = NumberOfLives.text;
        v_move = 0;
    }
    void Update()
    {
        if (current_lives != NumberOfLives.text)
        {
            bool kt = checkMove(int.Parse(NumberOfLives.text));
            if (kt == true)
                {
                    setV_move(-1);
                    current_lives = NumberOfLives.text;
                }
        }
        moveDown();
        if (NumberOfLives.text == "0" && v_move == 0)
        {
            burning.SetActive(true);
        }
    }
    private void moveDown()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, velocity * v_move);
        }
        totalDistance += Math.Abs(velocity * v_move);
        if (totalDistance >= 29900f)
        {
            v_move = 0;
            totalDistance = 0f;
        }
    }
    private void setV_move(float axisVertical)
    {
        if (axisVertical!=0)
        {
            v_move = axisVertical;
        }
    } 
    
    private bool checkMove(int live)
    {
        if (live<10 && live%2 == 0 && live!=0)
        {
            return true;
        }
        return false;
    }
}
