using UnityEngine;

public abstract class EnemyUnityWrapper : MonoBehaviour
{
    protected EnemyPure logicEnemy;

    [SerializeField]
    protected int baseHealth = 50;

    [SerializeField]
    protected float baseSpeed = 2f;

    protected abstract void InitializeLogic();

    public void ReceiveDamage(int damageAmount)
    {
        if (logicEnemy != null)
        {
            
            logicEnemy.TakeDamage(damageAmount);

            
            if (logicEnemy.Health <= 0)
            {
                Destroy(gameObject); 
            }
        }
    }
}