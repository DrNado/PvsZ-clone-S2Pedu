using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public int index;
    public SetTower setTowr;
    // Start is called before the first frame update
    public void SelectTower()
    {
        setTowr.selectedTower = index;
    }
}
