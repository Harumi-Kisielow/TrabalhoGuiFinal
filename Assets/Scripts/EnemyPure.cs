using System;

public class EnemyPure
{
    protected int health;
    protected float moveSpeed;

    public int Health
    {
        get { return health; }
    }

    public EnemyPure(int baseHealth, float baseSpeed)
    {
        health = baseHealth;
        moveSpeed = baseSpeed;
    }

    public virtual void Move()
    {
   
    }

    public void TakeDamage(int damageAmount)
    {
        if (damageAmount <= 0)
        {
            return;
        }

        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
 
    }
}