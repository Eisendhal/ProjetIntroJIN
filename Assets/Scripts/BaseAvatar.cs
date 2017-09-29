using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseAvatar : MonoBehaviour {

    [SerializeField]
    private float maxSpeed;
    private float health;
    [SerializeField]
    private float maxHealth;
    
    public enum type { Player, Enemy }
    [SerializeField]
    private type _type;

    public delegate void DeathEvent(type _type);
    public static event DeathEvent OnDeathEvent;

    public float MaxSpeed
    {
        get
        {
            return this.maxSpeed;
        }
        
        private set
        {
            this.maxSpeed = value;
        }
    }

    public float Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }
    }

    public float MaxHealth
    {
        get
        {
            return this.maxHealth;
        }
        set
        {
            this.maxHealth = value;
        }
    }

    public virtual void Start()
    {
        Health = MaxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        if(Health - damage > 0)
        {
            Health -= damage;
        }
        else
        {
            Die();
        }
        
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
        OnDeathEvent(_type);
    }



}
