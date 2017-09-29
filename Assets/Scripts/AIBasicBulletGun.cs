using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : MonoBehaviour {

    public GameObject enemyBullet;
    private Vector2 speed;

    [SerializeField]
    private float damage;
    private int cooldown = 75;

    public Vector2 Speed
    {
        get
        {
            return this.speed;
        }
        private set
        {
            this.speed = value;
        }
    }

    public float Damage
    {
        get
        {
            return this.damage;
        }
        private set
        {
            this.damage = value;
        }
    }

    public int Cooldown
    {
        get
        {
            return this.cooldown;
        }
        private set
        {
            this.cooldown = value;
        }
    }

    private void Fire()
    {
        if(Cooldown == 0)
        {
            Bullet newBullet = BulletFactory.Instance.GetBullet(Bullet.BulletType.EnemyBullet);
            newBullet.GetComponent<SimpleBullet>().enabled = true;
            newBullet.GetComponent<SimpleBullet>().Init(5, this.transform.position, new Vector2(-1, 0));
            Cooldown = 75;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
        if (Cooldown > 0)
        {
            Cooldown--;
        }
    }
}
