using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour {

    public GameObject bullet;

    public int guntype = 0;

    private Vector2 speed;

    [SerializeField]
    private float damage;
    private int cooldown = 50;

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

    public void Fire()
    {
        if (Cooldown == 0)
        {
            switch (guntype)
            {
                case 0:
                    if (this.GetComponent<PlayerAvatar>().Energy >= 10 && this.GetComponent<PlayerAvatar>().isReloading == false)
                    {
                        Bullet newBullet = BulletFactory.Instance.GetBullet(Bullet.BulletType.Player);
                        newBullet.GetComponent<SimpleBullet>().enabled = true;
                        newBullet.GetComponent<SpriteRenderer>().enabled = true;
                        newBullet.GetComponent<SimpleBullet>().Init(5, this.transform.position, new Vector2(1, 0));
                        Cooldown = 30;
                        this.GetComponent<PlayerAvatar>().Energy -= 10;
                        this.GetComponent<PlayerAvatar>().compteur = 8;
                    }
                    break;

                case 1:
                    if (this.GetComponent<PlayerAvatar>().Energy >= 15 && this.GetComponent<PlayerAvatar>().isReloading == false)
                    {
                        Bullet newBullet1 = BulletFactory.Instance.GetBullet(Bullet.BulletType.Player);
                        Bullet newBullet2 = BulletFactory.Instance.GetBullet(Bullet.BulletType.Player);
                        newBullet1.GetComponent<DiagonalBullet>().enabled = true;
                        newBullet2.GetComponent<DiagonalBullet>().enabled = true;
                        newBullet1.GetComponent<SpriteRenderer>().enabled = true;
                        newBullet2.GetComponent<SpriteRenderer>().enabled = true;
                        newBullet1.GetComponent<DiagonalBullet>().Init(5, this.transform.position, new Vector2(1, 1));
                        newBullet2.GetComponent<DiagonalBullet>().Init(5, this.transform.position, new Vector2(1, -1));
                        Cooldown = 55;
                        this.GetComponent<PlayerAvatar>().Energy -= 15;
                        this.GetComponent<PlayerAvatar>().compteur = 8;
                    }
                    break;
                case 2:
                    if (this.GetComponent<PlayerAvatar>().Energy >= 5 && this.GetComponent<PlayerAvatar>().isReloading == false)
                    {
                        Bullet newBullet3 = BulletFactory.Instance.GetBullet(Bullet.BulletType.Player);
                        newBullet3.GetComponent<SpiralBullet>().enabled = true;
                        newBullet3.GetComponent<SpriteRenderer>().enabled = true;
                        newBullet3.GetComponent<SpiralBullet>().Init(10, this.transform.position, new Vector2(0, 1));
                        Cooldown = 15;
                        this.GetComponent<PlayerAvatar>().Energy -= 5;
                        this.GetComponent<PlayerAvatar>().compteur = 8;
                    }
                    break;
            }

        }   
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.guntype = this.guntype % 3;
        if(Cooldown > 0)
        {
            Cooldown--;
        }

	}
}
