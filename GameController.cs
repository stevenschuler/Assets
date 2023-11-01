using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera mainCam;

    public bool viewWholeMap = true;

    public Transform followMario;

    public float camYPos = 2.4f;
    public float camFollowSpeed = 5f;
    public float camOffset = 2.0f;

    public float score = 0.0f;

    public float jumpingFactor = 1.0f;
    public float victoryFactor = 1.0f;
    public float disRightFactor = 1.0f;
    public float scoreFactor = 1.0f;
    public float timeFactor = 1.0f;

    public float episodeTimeLimit = 10f;

    public int rangeBehind = 5;
    public int rangeAbove = 8;
    //public int rangeBelow = 5;
    public int rangeAhead = 10;

    public GameObject marioVision;
    public int marioVisionGroundLevel = -2;

    private Camera startingCam;

    private void Start()
    {
        startingCam = mainCam;
        //Time.timeScale = 1.0f;
    }

    public void ResetScore()
    {
        score = 0.0f;
    }

    private void Update()
    {
        // If following a specific mario
        if (!viewWholeMap)
        {
            mainCam.orthographicSize = 6.0f;
            marioVision.SetActive(true);
            float newX = Mathf.Lerp(mainCam.transform.position.x, followMario.position.x + camOffset, camFollowSpeed * Time.deltaTime);
            mainCam.transform.position = new Vector3(newX, camYPos, -10f);

            // Update position of marioVision if following a specific mario
            Transform mvt = marioVision.GetComponent<Transform>();
            mvt.localPosition = new Vector3(followMario.GetComponent<Transform>().position.x + ((rangeBehind + rangeAhead) / 2f) - rangeBehind - 0.5f,
                (float)marioVisionGroundLevel + (rangeAbove/2f), 0f);
        }
        // Otherwise set cam to the default camera that sees the entire map
        else
        {
            marioVision.SetActive(false);
            mainCam = startingCam;
        }
        

    }
}
