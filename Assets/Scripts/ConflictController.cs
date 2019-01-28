using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConflictController : MonoBehaviour
{
    public int HP;
    private Color startColor;

    public void Start()
    {
        HP = 1;
        startColor = GetComponentInChildren<Renderer>().material.color;
    }

    public void setHP(int damage)
    {
        if (HP > 0)
        {
            HP = HP - damage;
        }
        if (HP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public int getHP()
    {
        return HP;
    }

    //private void OnMouseOver()
    //{
    //    GetComponent<Renderer>().material.color = Color.cyan;
    //    print("Entered");
    //}

    //private void OnMouseExit()
    //{
    //    GetComponent<Renderer>().material.color = startColor;
    //    print("Exited");
    //}
}
