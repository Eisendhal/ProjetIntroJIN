using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : BaseAvatar {

    private int energy;
    public int compteur;
    public bool isReloading = false;

    public int Energy
    {
        get
        {
            return this.energy;
        }
        set
        {
            this.energy = value;
        }
    }

	// Use this for initialization
	public override void Start () {
        base.Start();
        Energy = 100;
        compteur = 8;
	}
	
	// Update is called once per frame
	void Update () {
		if(Energy < 100 && isReloading == false)
        {
            if(compteur == 0)
            {
                Energy += 2;
                compteur = 8;
            }
            else
            {
                compteur--;
            }
        }
        if(Energy == 0 || isReloading == true)
        {
            if(Energy == 100)
            {
                isReloading = false;
            }
            else
            {
                isReloading = true;
                if(compteur == 0)
                {
                    Energy += 2;
                    compteur = 10;
                }
                else
                {
                    compteur--;
                }
            }

        }
	}
}
