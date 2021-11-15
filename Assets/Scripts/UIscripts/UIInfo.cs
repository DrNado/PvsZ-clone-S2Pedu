using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInfo : MonoBehaviour
{
    public float initMoney;
    public Text moneyText;
    public bool lost;

    private Money mney;
    private Spawner spner;

    void Start()
    {
        mney = GameObject.Find("GameManeger").GetComponent<Money>();
        spner = GameObject.Find("GameManeger").GetComponent<Spawner>();
        initMoney = mney.money;
    }
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money:" + mney.money.ToString();
        RestartGame();
    }
    public void RestartGame()
    {
        if (lost)
        {
            lost = false;
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
            GameObject[] Projs = GameObject.FindGameObjectsWithTag("Projectile");

            for (int i = 0; i < towers.Length; i++)
            {
                Destroy(towers[i]);
            }
            for (int j = 0; j < enemys.Length; j++)
            {
                Destroy(enemys[j]);
            }
            for (int n = 0; n < tiles.Length; n++)
            {
                TileTaken tk = tiles[n].GetComponent<TileTaken>();
                tk.hasTower = false;
                if (tk.tower != null)
                {
                    Destroy(tk.tower);
                    tk.tower = null;
                }
            }
            for (int k = 0; k < Projs.Length; k++)
            {
                Destroy(Projs[k]);
            }
            mney.money = initMoney;
            spner.ResetCd();
        }
        
    }
}
