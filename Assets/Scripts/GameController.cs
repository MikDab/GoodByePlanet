using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stichija { Nothing = 0, Audra = 1, Zaibas = 2, Kometos = 3, Viesulas = 4 }

public class GameController : MonoBehaviour
{
    [SerializeField] Pollution pollution;
    [SerializeField] SoundController soundController;
    [SerializeField] float timeIntervalBetweenCuts = 1.5f;
    [SerializeField] float waitForSecondsBeforeStart = 8.2f;

    public GameEvent PauseGameEvent;

    public GameObject earth;
    public static GameController Instance { get; private set; }
    public SpotsInTrigger SpotsInTriggerReference;
    public float timeBeforeNextConflictSpawn = 1f;
    public float conflictSpawnSpeed;
    public float conflictWaveDuration = 2f;
    public int destroyTreesWhen = 50;
    public int treesOnStart = 120;

    private float timeBeforeNextTreeCut;
    private float conflictSpawnCounter = 0;
    private float currentWaveTime;
    private float gameTime = 0f;
    public static Stichija CurrentlySelectedStichija = Stichija.Nothing;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
            return;
        }

        PauseGame.Pause = false;

        if (earth.activeInHierarchy)
        {
            earth.SetActive(false);
        }
    }

    void Start()
    {
        AudioManager.Instance.PlaySound("Soundtrack2_start");
        StartCoroutine(LateCall());
        soundController = GetComponent<SoundController>();
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(waitForSecondsBeforeStart);
        gameTime = 0f;
        earth.SetActive(true);
        pollution = GetComponent<Pollution>();
        ResetTreeCutCounter();
        InitialSpawn();
        yield return null;
    }

    public List<SpotController> getEmptySpots()
    {
        List<SpotController> Spots = new List<SpotController>();
        foreach (SpotController ctrl in FindObjectsOfType<SpotController>())
        {
            if (!Spots.Contains(ctrl) && !ctrl.CurrentlyEnabled)
            {
                Spots.Add(ctrl);
            }
        }
        return Spots;
    }

    public List<SpotController> getPopulatedGoodSpots()
    {
        List<SpotController> populatedGoodSpotList = new List<SpotController>();
        foreach (SpotController ctrl in FindObjectsOfType<SpotController>())
        {
            if (ctrl.trees && !ctrl.ShrunkTrees && ctrl.CurrentlyEnabled == ctrl.trees)
            {
                populatedGoodSpotList.Add(ctrl);
            }
        }
        return populatedGoodSpotList;
    }

    void InitialSpawn()
    {
        List<SpotController> emptySpotList = getEmptySpots();

        for (int i = 0; i < treesOnStart; i++)
        {
            int random = Random.Range(0, emptySpotList.Count);
            if (emptySpotList[random].CurrentlyEnabled == null)
            {
                emptySpotList[random].EnableTrees(true);
                emptySpotList.RemoveAt(random);
            }
        }
    }

    public static void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, list.Count);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseTheGame();
        }

        if (PauseGame.Pause)
            return;

        IncreaseGameTime();

        conflictSpawnCounter += Time.deltaTime * conflictSpawnSpeed;
        currentWaveTime += Time.deltaTime;

        if (timeBeforeNextConflictSpawn <= conflictSpawnCounter)
        {
            spawnConflict();
            ResetConflictSpawnCounter();
        }

        if (currentWaveTime >= conflictWaveDuration)
        {
            conflictSpawnSpeed += Time.deltaTime * 25f;
            currentWaveTime = 0;
        }

        soundController.PlayDefaultMouseSound();
    }

    private void IncreaseGameTime()
    {
        gameTime += Time.deltaTime;
    }

    private void ResetConflictSpawnCounter()
    {
        conflictSpawnCounter = 0;
    }

    private void ResetTreeCutCounter()
    {
        timeBeforeNextTreeCut = timeIntervalBetweenCuts;
    }

    void cutDownTrees()
    {
        if (getEmptySpots().Count <= destroyTreesWhen)
        {
            timeBeforeNextTreeCut -= Time.deltaTime;
        }

        List<SpotController> treesEnabled = getPopulatedGoodSpots();
        if (timeBeforeNextTreeCut <= 0f && treesEnabled.Count > 0)
        {
            SpotController randomTreeSpot = treesEnabled[Random.Range(0, treesEnabled.Count)];
            randomTreeSpot.trees.GetComponent<Animator>().SetTrigger("Shrink");
            randomTreeSpot.ShrunkTrees = true;
            pollution.IncreasePollution();
            ResetTreeCutCounter();
        }
    }

    void spawnConflict()
    {
        cutDownTrees();
        ShuffleList(SpotsInTriggerReference.SpotsInRange);
        foreach (SpotController ctrl in SpotsInTriggerReference.SpotsInRange)
        {
            if (ctrl.CurrentlyEnabled == null)
            {
                int r = Random.Range(0, 3);
                switch (r)
                {
                    case 0:
                        ctrl.EnableApartments(true);
                        soundController.PlayPopSound();
                        break;
                    case 1:
                        ctrl.EnableFactory(true);
                        soundController.PlayPopSound();
                        break;
                    case 2:
                        ctrl.EnableTrash(true);
                        soundController.PlayPopSound();
                        break;
                    default:
                        ctrl.EnableFactory(true);
                        soundController.PlayPopSound();
                        break;
                }
                break;
            }
        }
    }

    public float GetGameTime()
    {
        return gameTime;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void PauseTheGame()
    {
        if (!PauseGame.Pause)
        {
            PauseGameEvent.Raise();
            PauseGame.Pause = true;
        }
    }

    public void ResumeTheGame()
    {
        PauseGame.Pause = false;
    }

}
