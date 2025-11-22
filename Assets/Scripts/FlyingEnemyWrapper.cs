using UnityEngine;


public class FlyingEnemyWrapper : EnemyUnityWrapper
{
    private float amplitude = 1f;
    private float frequency = 1f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        InitializeLogic();
    }

    protected override void InitializeLogic()
    {
        logicEnemy = new FlyingEnemyPure(baseHealth, baseSpeed);
    }

    public class FlyingEnemyPure : EnemyPure
    {
        public FlyingEnemyPure(int h, float s) : base(h, s) { }

        public override void Move()
        {

        }
    }
    void Update()
    {
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * baseSpeed);
        transform.Translate(Vector3.left * baseSpeed * Time.deltaTime, Space.World);
    }
}