using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // スコアを表示するテキスト
    private GameObject scoreText;

    private int score = 0;

    // Use this for initialization
    void Start () {
        this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
        this.scoreText.GetComponent<Text>().text = score.ToString();
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")   // SmallStarの場合
        {
            this.score += 5;
            Debug.Log("ss");
        }
        else if (other.gameObject.tag == "LargeStarTag")  // LargeStarの場合
        {
            this.score += 10;
            Debug.Log("ls");
        }
        else if (other.gameObject.tag == "SmallCloudTag" 
                    || other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 15;
            Debug.Log("cl");
        }
    }
}
