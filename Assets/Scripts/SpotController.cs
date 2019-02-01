using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour, OnRightClick, OnLeftClick
{
    [SerializeField] Pollution pollutionReference;

    public GameObject trees;
    public GameObject Factory;
    public GameObject Fire;
    public GameObject Windmill;
    public List<GameObject> Trash;
    public List<GameObject> Apartments;
    public GameObject CurrentlyEnabled;
    public bool ShrunkTrees = false;
    public GameObject ParticleSystemObject;

    public void Awake()
    {
        pollutionReference = FindObjectOfType<Pollution>();
    }

    void StopParticles()
    {
        ParticleSystemObject.SetActive(false);
    }

    void PlayParticles()
    {
        if (ParticleSystemObject.activeSelf)
            ParticleSystemObject.SetActive(false);

        ParticleSystemObject.SetActive(true);
    }

    public void RightClick()
    {
        if (CurrentlyEnabled != null)
        {
            if (CurrentlyEnabled.GetComponent<OnRightClick>() != null)
            {
                CurrentlyEnabled.GetComponent<OnRightClick>().RightClick();
            }
            PlayParticles();
        }
    }

    public void ClearCurrentlyEnabled()
    {
        CurrentlyEnabled = null;
    }

    public void LeftClick()
    {
        if (CurrentlyEnabled != null)
        {
            foreach (OnLeftClick clk in CurrentlyEnabled.GetComponents<OnLeftClick>())
            {
                clk.LeftClick();
            }

            if (this.GetComponent<SpawnAnimation>() != null)
            {
                switch (GameController.CurrentlySelectedStichija)
                {
                    case Stichija.Zaibas:
                        this.GetComponent<SpawnAnimation>().setLightning();
                        break;
                    case Stichija.Audra:
                        this.GetComponent<SpawnAnimation>().setRain();
                        break;
                    case Stichija.Viesulas:
                        this.GetComponent<SpawnAnimation>().setTornado();
                        break;
                    default:
                        break;
                }
            }
            PlayParticles();
        }
    }

    public void EnableTrees()
    {
        if (CurrentlyEnabled == null)
        {
            trees.gameObject.SetActive(true);
            CurrentlyEnabled = trees;
            ShrunkTrees = false;
        }
        else if (CurrentlyEnabled == trees)
        {
            if (ShrunkTrees)
            {
                trees.GetComponentInChildren<Animator>().SetTrigger("Grow");
                pollutionReference.ReducePollution();
                ShrunkTrees = false;
            }
        }
    }

    public void EnableWindmill(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Windmill.SetActive(value);
            CurrentlyEnabled = Windmill;
        }
    }

    public void DisableTrees()
    {
        if (CurrentlyEnabled == trees)
        {
            trees.GetComponentInChildren<Animator>().SetTrigger("Shrink");
            pollutionReference.IncreasePollution();
            ShrunkTrees = true;
        }
    }

    public void EnableFactory(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Factory.gameObject.SetActive(value);
            CurrentlyEnabled = Factory;
        }
    }

    public void EnableFire(bool value)
    {
        Fire.gameObject.SetActive(value);
    }

    public void EnableApartments(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            int r = Random.Range(0, Apartments.Count);
            Apartments[r].gameObject.SetActive(value);
            CurrentlyEnabled = Apartments[r];
        }
    }

    public void EnableTrash(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            int r = Random.Range(0, Apartments.Count);
            Trash[r].gameObject.SetActive(value);
            CurrentlyEnabled = Trash[r];
        }
    }
}