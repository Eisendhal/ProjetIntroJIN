using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour {

    [SerializeField]
    private GameObject playerBulletPrefab;
    [SerializeField]
    private GameObject enemyBulletPrefab;

    private List<GameObject> playerBulletsList;
    private List<GameObject> enemyBulletsList;

    public static BulletFactory Instance
    {
        get; private set;
    }

    private void Awake()
    {
        Debug.Assert(BulletFactory.Instance == null);
        BulletFactory.Instance = this;
        playerBulletsList = new List<GameObject>();
        enemyBulletsList = new List<GameObject>();
    }

	public Bullet GetBullet(Bullet.BulletType type)
    {
        GameObject gameObject = null;
        switch (type)
        {
            case Bullet.BulletType.Player:
                if(this.playerBulletsList.Count > 0)
                {
                    gameObject = playerBulletsList[playerBulletsList.Count -1];
                    this.playerBulletsList.RemoveAt(this.playerBulletsList.Count - 1);
                }
                else
                {
                    gameObject = Instantiate<GameObject>(playerBulletPrefab);
                }
                break;
            case Bullet.BulletType.EnemyBullet:
                if(this.enemyBulletsList.Count > 0)
                {
                    gameObject = enemyBulletsList[enemyBulletsList.Count - 1];
                    this.enemyBulletsList.RemoveAt(this.enemyBulletsList.Count - 1);
                }
                else
                {
                    gameObject = Instantiate<GameObject>(enemyBulletPrefab);
                }
                break;
        }
        return gameObject.GetComponent<Bullet>();
    }

    public void Release(Bullet bullet)
    {
        bullet.GetComponent<SpriteRenderer>().enabled = false;
        if(bullet.mybullettype == Bullet.BulletType.Player)
        {
            playerBulletsList.Add(bullet.gameObject);
        }
        if(bullet.mybullettype == Bullet.BulletType.EnemyBullet)
        {
            enemyBulletsList.Add(bullet.gameObject);
        }
    }
}
