using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;
    public int score;
    public bool gameOver;
    public bool restart;
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = " ";
        gameOverText.text = " ";

        score=0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update(){
        if(restart){
            if(Input.GetKeyDown(KeyCode.R)){
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator SpawnWaves(){
        yield return new WaitForSeconds(startWait);
        while(true){
            for(int i=0;i<hazardCount;i++){
                Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		        Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard,spawnPosition,spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver){
                restartText.text = "Press 'R' for the Restart";
                restart = true;
                break;
            }
        }
        
    }
    
    public void AddScore(int ScoreValue){
        score +=ScoreValue;
        UpdateScore();
    }
    void UpdateScore(){
       scoreText.text = "Score "+ score;
    }
    public void GameOver(){
        gameOverText.text = "Game Over ! ";
        gameOver = true;
    }
}
