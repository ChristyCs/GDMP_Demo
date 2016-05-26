using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

    int roundDuration;
    int durationRemaining;
    int duration;
    int seconds;
    int mins;
    string durationString;

    int bodyGuardScore;
    int assassinScore;


    // Use this for initialization
    void Start () {
        roundDuration = 240;
        updateDuration();
        bodyGuardScore = 0;
        assassinScore = 0;
    }
	
	// Update is called once per frame
	void Update () {
        updateDuration();

        print(durationString);
    }

    void updateDuration(){
        duration = (int)Time.time;
        durationRemaining = roundDuration - duration;

        seconds = durationRemaining % 60;
        mins = (durationRemaining - mins) / 60;
        durationString = mins.ToString("00") + ":" + seconds.ToString("00");
    }

    public void addTobodyGuardScore(int points){
        bodyGuardScore += points;
    }

    public void addToAssassinScore(int points){
        assassinScore += points;
    }
}
