 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAsset : MonoBehaviour {
    private UILabel energyLabel;
    private UILabel goldenLabel;
    private UILabel diamondLabel;

    private int energyAmount;
    private int energy;
    private int golden;
    private int diamond;

    public UILabel EnergyLabel {
        get {
            if (energyLabel == null)
                energyLabel = transform.Find("Energy/Label").GetComponent<UILabel>();
            return energyLabel;
        }

        set {
            energyLabel = value;
        }
    }

    public UILabel GoldenLabel {
        get {
            //if (goldenLabel == null)
            //    goldenLabel = transform.Find("Golden/Label").GetComponent<UILabel>();
            return goldenLabel;
        }

        set {
            goldenLabel = value;
        }
    }

    public UILabel DiamondLabel {
        get {
            if (diamondLabel == null)
                diamondLabel = transform.Find("Diamond/Label").GetComponent<UILabel>();
            return diamondLabel;
        }

        set {
            diamondLabel = value;
        }
    }

    public int Energy {
        get {
            return energy;
        }

        set {
            energy = value;
        }
    }

    public int Golden {
        get {
            return golden;
        }

        set {
            golden = value;
        }
    }

    public int Diamond {
        get {
            return diamond;
        }

        set {
            diamond = value;
        }
    }

    public int EnergyAmount {
        get {
            return energyAmount;
        }

        set {
            energyAmount = value;
        }
    }


    // Use this for initialization
    void Start () {
        EnergyAmount = 150;
        SetPlayerAssets(10, 999, 0);

        //EnergyLabel.text = Energy.ToString() + "/" + EnergyAmount;
        //GoldenLabel.text = Golden.ToString();
        //DiamondLabel.text = Diamond.ToString();
	}

    public void SetPlayerAssets(int newEnergy, int newGolden, int newDiamond)
    {
        Energy = newEnergy;
        Golden = newGolden;
        Diamond = newDiamond;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddEnergy()
    {

    }

    public void AddGolden()
    {

    }

    public void AddDiamond()
    {

    }
}
