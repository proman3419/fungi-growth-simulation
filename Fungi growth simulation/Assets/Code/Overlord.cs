using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    private Grid _grid;
    bool paused = false;
    public static int Frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        Statistics.Init();
        Config.Init();
        _grid = new Grid();
        Debug.Log("START");
    }
    
    public bool IsPaused()
    {
        return paused;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.P))
            paused = !paused;

        if (!paused)
        {
            GridCell._maxNutritionLevelCurr = 0;
            _grid.Update();
            Statistics.IncreaseTime();
            GridCell._maxNutritionLevelPrev = GridCell._maxNutritionLevelCurr;
            Debug.Log("FRAME " + Frame);
            Frame++;
        }
    }
}
