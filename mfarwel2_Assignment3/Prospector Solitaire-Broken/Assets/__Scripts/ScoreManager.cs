using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum to handle all the possible scoring events
public enum eScoreEvent {
	draw,
	mine,
	mineGold,
	gameWin,
	gameLoss
}

// ScoreManager handles all of the scoring
public class ScoreManager : MonoBehaviour {                 // a
	static private ScoreManager S;                            // b

	static public int   SCORE_FROM_PREV_ROUND = 0;
	static public int   HIGH_SCORE = 0;

	[Header("Set Dynamically")]
	// Fields to track score info
    // Error 2: make each of these variables static to ensure functionality of Singleton
	 public int            chain = 0;
	 public int            scoreRun = 0;
	 public int            score = 0;

	void Awake() {
		if (S == null) {                                        // c
			S = this; // Set the private singleton 
		} else {
			Debug.LogError("ERROR: ScoreManager.Awake(): S is already set!");
		}

		// Check for a high score in PlayerPrefs
		if (PlayerPrefs.HasKey ("ProspectorHighScore")) {
			HIGH_SCORE = PlayerPrefs.GetInt("ProspectorHighScore");
		}
		// Add the score from last round, which will be >0 if it was a win
		score += SCORE_FROM_PREV_ROUND;
		// And reset the SCORE_FROM_PREV_ROUND
		SCORE_FROM_PREV_ROUND = 0;
	}

	static public void EVENT( eScoreEvent evt) {                  // d
		try { // try-catch stops an error from breaking your program 
            // Error 2: fix to function w singleton as cannot call on instance object.
			Event(evt);
		}  catch (System .NullReferenceException nre) {
			Debug.LogError ("ScoreManager:EVENT() called while S=null.\n"+nre );
		}
	}
    // Errror 2: add static keyword to ensure functionality of Singelton
	static public void Event(eScoreEvent evt) {
		switch (evt) {
		// Same things need to happen whether it's a draw, a win, or a loss
		case eScoreEvent.draw:     // Drawing a card
		case eScoreEvent.gameWin:  // Won the round
		case eScoreEvent.gameLoss: // Lost the round
            // Error 2: call all chain, score and scoreRun variables on S, singleton
			S.chain = 0;             // resets the score chain
			S.score += S.scoreRun;     // add scoreRun to total score
			S.scoreRun = 0;          // reset scoreRun
			break;

		case eScoreEvent.mine:    // Remove a mine card
			S.chain++;              // increase the score chain
			S.scoreRun += S.chain;    // add score for this card to run
			break;
		}

		// This second switch statement handles round wins and losses
		switch (evt) {
		case eScoreEvent.gameWin:
			// If it's a win, add the score to the next round
			// static fields are NOT reset by SceneManager.LoadScene()
			SCORE_FROM_PREV_ROUND = S.score;
			print ("You won this round! Round score: "+S.score);
			break;

		case eScoreEvent.gameLoss:
			// If it's a loss, check against the high score
			if (HIGH_SCORE <= S.score) {
				print("You got the high score! High score: "+S.score);
				HIGH_SCORE = S.score;
				PlayerPrefs.SetInt("ProspectorHighScore", S.score);
			} else {
				print ("Your final score for the game was: "+S.score);
			}
			break;

		default:
			print ("score: "+S.score+" scoreRun:"+S.scoreRun+" chain:"+S.chain);
			break;
		}
	}

    // Error 2: fix to function with Singleton as cannot call on the instance object
	static public int CHAIN { get { return S.chain; } }             // e
	static public int SCORE { get { return S.score; } }
	static public int SCORE_RUN { get { return S.scoreRun; } }
    //static public int CHAIN { get { return chain; } }             // e
    //static public int SCORE { get { return score; } }
    //static public int SCORE_RUN { get { return scoreRun; } }
} 