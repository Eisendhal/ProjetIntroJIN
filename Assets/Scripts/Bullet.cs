using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private Vector2 speed;
    private Vector2 position;
    private int side;

    private int bulletSpeed = 10;

    [SerializeField]
    private float damage;

    public enum BulletType { Player, EnemyBullet };
    [SerializeField]
    public BulletType mybullettype;

    public Vector2 Speed
    {
        get
        {
            return this.speed;
        }
        protected set
        {
            this.speed = value;
        }
    }

    public Vector2 Position
    {
        get
        {
            return this.position;
        }
        protected set
        {
            this.position = value;
        }
    }

    public float Damage
    {
        get
        {
            return this.damage;
        }
        protected set
        {
            this.damage = value;
        }
    }

    public virtual void Init(float initDamage, Vector2 initPosition, Vector2 initSpeed)
    {
        this.Damage = initDamage;
        this.Position = initPosition;
        this.Speed = initSpeed;
    }

    protected virtual void UpdatePosition()
    {
        Position += bulletSpeed * Time.deltaTime * Speed;
        this.transform.position = Position;
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerAvatar>() && this.mybullettype == BulletType.EnemyBullet)
        {
            other.gameObject.GetComponent<PlayerAvatar>().TakeDamage(this.damage);
            Destroy(this.gameObject);
        }

        if(other.gameObject.GetComponent<EnemyAvatar>() && this.mybullettype == BulletType.Player)
        {
            other.gameObject.GetComponent<EnemyAvatar>().TakeDamage(this.damage);
            Destroy(this.gameObject);
        }
        
    }




	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
