using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEntity : HPEntity
{
    [SerializeField] protected Transform trfm;
    [SerializeField] protected Rigidbody2D rb;
    public bool isOnGround;
    protected bool facing;
    protected const bool FACING_LEFT = false, FACING_RIGHT = true;

    Vector2 vect2;
    
    protected void AddXVelocity(float amount, float max)
    {
        vect2 = rb.velocity;

        if (amount > 0)
        {
            if (vect2.x > max)
            {
                return;
            }
            else
            {
                vect2.x += amount;
                if (vect2.x > max)
                {
                    vect2.x = max;
                }
            }
        }
        else
        {
            if (vect2.x < max)
            {
                return;
            }
            else
            {
                vect2.x += amount;
                if (vect2.x < max)
                {
                    vect2.x = max;
                }
            }
        }

        rb.velocity = vect2;
    }
    protected void SetXVelocity(float value)
    {
        vect2 = rb.velocity;
        vect2.x = value;
        rb.velocity = vect2;
    }

    protected void AddYVelocity(float amount, float max)
    {
        vect2 = rb.velocity;
        vect2.y += amount;

        vect2 = rb.velocity;

        if (amount > 0)
        {
            if (vect2.y > max)
            {
                return;
            }
            else
            {
                vect2.y += amount;
                if (vect2.y > max)
                {
                    vect2.y = max;
                }
            }
        }
        else
        {
            if (vect2.y < max)
            {
                return;
            }
            else
            {
                vect2.y += amount;
                if (vect2.y < max)
                {
                    vect2.y = max;
                }
            }
        }

        rb.velocity = vect2;
    }
    protected void SetYVelocity(float value)
    {
        vect2 = rb.velocity;
        vect2.y = value;
        rb.velocity = vect2;
    }

    protected void ApplyXFriction(float amount)
    {
        vect2 = rb.velocity;

        if (vect2.x > 0)
        {
            vect2.x -= amount;
            if (vect2.x < 0)
            {
                vect2.x = 0;
            }
        } else
        {
            vect2.x += amount;
            if (vect2.x > 0)
            {
                vect2.x = 0;
            }
        }

        rb.velocity = vect2;
    }

    protected void SetVelocity(float x, float y)
    {
        vect2.x = x; vect2.y = y;
        rb.velocity = vect2;
    }

    public bool IsFacingRight()
    {
        return facing;
    }
    public bool IsFacingLeft()
    {
        return !facing;
    }
}