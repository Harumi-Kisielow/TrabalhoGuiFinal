using System;
using UnityEngine;

public class GroundEnemyWrapper : EnemyUnityWrapper
{
    private float walkDistance = 3f;
    private Vector3 targetPosition;
    private bool movingRight = true;

    void Start()
    {
        InitializeLogic();
        targetPosition = transform.position + Vector3.right * walkDistance;
    }

    protected override void InitializeLogic()
    {
        logicEnemy = new GroundEnemyPure(baseHealth, baseSpeed);
    }
    public class GroundEnemyPure : EnemyPure
    {
        public GroundEnemyPure(int h, float s) : base(h, s) { }

        public override void Move()
        {

        }

        public override void Die()
        {
        
        }
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, baseSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movingRight = !movingRight;
            if (movingRight)
            {
                targetPosition = transform.position + Vector3.right * walkDistance;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                targetPosition = transform.position + Vector3.left * walkDistance;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
}