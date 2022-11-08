using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{

    public Camera MainCamera;
    public KartController Kart;

    public GameObject checkpointContainer;
    private int currentCheckpoint = -1;

    public Text TimeText;
    public Text BestTimeText;

    private float gameTimer;
    private float bestTime = 999.0f;
    private bool finishedLap;

    // Start is called before the first frame update
    void Start()
    {
        foreach (CheckpointController checkpoint in checkpointContainer.GetComponentsInChildren<CheckpointController>())
        {
            checkpoint.OnHitByPlayer = (int checkpointID) =>
            {
                OnReachCheckpoint(checkpointID);
            };
        }
    }

    void OnReachCheckpoint(int checkpointID)
    {
        Debug.Log("Checkpoint: " + checkpointID);

        if (checkpointID == currentCheckpoint + 1)
        {
            currentCheckpoint++;
        }
        if (checkpointID == 0 && currentCheckpoint == 2)
        {
            Debug.Log("Finished Lap!");
            finishedLap = true;
            currentCheckpoint = 0;
            Debug.Log("Best Time: " + bestTime);
            Debug.Log("Lap Time: " + gameTimer);
            if (gameTimer < bestTime)
            {
                bestTime = gameTimer;
            }
            gameTimer = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.transform.position = new Vector3(
            Kart.transform.position.x - Kart.transform.forward.x * 5,
            3,
            Kart.transform.position.z - Kart.transform.forward.z * 5
        );
        MainCamera.transform.LookAt(Kart.transform);

        gameTimer += Time.deltaTime;
        TimeText.text = "Time: " + Mathf.Floor(gameTimer);

        if (finishedLap)
        {
            Debug.Log("Updating Best Time Text");
            BestTimeText.text = "Best Time: " + Mathf.Floor(bestTime);
            finishedLap = false;
        }
    }
}
