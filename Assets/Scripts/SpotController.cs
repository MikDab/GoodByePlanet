using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour, OnRightClick, OnLeftClick
{
    public GameObject trees;
    public GameObject Factory;
    public GameObject Fire;
    public GameObject Windmill;
    public List<GameObject> Trash;
    public List<GameObject> Apartments;
    public GameObject CurrentlyEnabled;
    public Polution PolutionReference;
    public bool ShrunkTrees = false;
    public GameObject ParticleSystemObject;

    public void Awake()
    {
        PolutionReference = FindObjectOfType<Polution>();
        StopParticles();
    }

    void StopParticles()
    {
        foreach (ParticleSystem p in ParticleSystemObject.GetComponents<ParticleSystem>())
        {
            p.Stop();
        }
    }

    void PlayParticles()
    {
        foreach (ParticleSystem p in ParticleSystemObject.GetComponents<ParticleSystem>())
        {
            p.Play();
        }
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
            if (CurrentlyEnabled.GetComponent<OnLeftClick>() != null)
            {
                CurrentlyEnabled.GetComponent<OnLeftClick>().LeftClick();
            }
            if (this.GetComponent<SpawnAnimaton>() != null)
            {
                switch (GameController.CurrentlySelectedStichija)
                {
                    case Stichija.Zaibas:
                        this.GetComponent<SpawnAnimaton>().setLightning();
                        break;
                    case Stichija.Audra:
                        this.GetComponent<SpawnAnimaton>().setRain();
                        break;
                    case Stichija.Viesulas:
                        this.GetComponent<SpawnAnimaton>().setTornado();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void EnableTrees(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            trees.gameObject.SetActive(value);
            CurrentlyEnabled = trees;
        }
        else if (CurrentlyEnabled == trees)
        {
            if (ShrunkTrees)
            {
                this.GetComponent<Animator>().SetTrigger("Grow");
                PolutionReference.ReducePolution();
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
            trees.GetComponent<Animator>().SetTrigger("Shrink");
            PolutionReference.IncreasePolution();
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