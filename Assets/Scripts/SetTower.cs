using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTower : MonoBehaviour
{
    public int selectedTower;
    public List<GameObject> towers;
    public float[] prices;
    public LayerMask mask;

    GameObject tile;
    public GameObject carriedTower;

    Money mony;
    // Start is called before the first frame update
    void Start()
    {
        mony = GameObject.Find("GameManeger").GetComponent<Money>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTower();
        BuildTower();
    }
    void BuildTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20,mask))
        {
            if (hit.transform.tag == "Tile")
            {
                tile = hit.transform.gameObject;
            }
            if (Input.GetMouseButtonDown(0) && tile != null)
            {
                PlaceTower();
            }
        }
    }
    void PlaceTower()
    {
        TileTaken tk = tile.GetComponent<TileTaken>();
        Vector3 pos = new Vector3(tile.transform.position.x, 1.05f, tile.transform.position.z);
        if (!tk.hasTower && mony.money >= prices[selectedTower] && carriedTower == null && !tk.hasZombie)
        {
            mony.money -= prices[selectedTower];
            tk.tower = (GameObject)Instantiate(towers[selectedTower], pos, Quaternion.identity);
            tk.hasTower = true;
        }
        else if (tk.hasTower && tk.tower != null)
        {
            if (carriedTower != null)
            {
                return;
            }
            carriedTower = tk.tower;
            carriedTower.transform.position += new Vector3(0, 1, 0);
            var temp = carriedTower.GetComponent<Shoot>();
            if (temp)
            {
                temp.canShoot = false;
            }
            tk.hasTower = false;
        }
        else if (!tk.hasTower && carriedTower != null && !tk.hasZombie)
        {
            var temp = carriedTower.GetComponent<Shoot>();
            if (temp)
            {
                temp.canShoot = true;
            }
            tk.tower = (GameObject)Instantiate(carriedTower, pos, Quaternion.identity);
            tk.hasTower = true;
            Destroy(carriedTower);
            carriedTower = null;
        }
        
    }
    void MoveTower()
    {
        if (carriedTower == null)
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Vector3 mousepos = new Vector3(raycastHit.point.x, carriedTower.transform.position.y, raycastHit.point.z);
            carriedTower.transform.position = mousepos;
        }
    }
}
