using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public DanceCombos danceCombos;
    public FallDamage fallDamageScript;
    public Timer timerScript;
    public Image boostBar;
    public float boost;
    public int hP;
    public float time;
    public int points;
    public int pointsLost;
    [SerializeField] int totalTimeCoinsCollected;
    [SerializeField] int totalPointsCoinsCollected;
    [SerializeField] int totalHPCoinsCollected;
    public int totalHealthLost;
    public int totalHealthGained;
    [SerializeField] int asteroidCollisions;
    [SerializeField] float score;
    [SerializeField] float totalTime;
    [SerializeField] int totalCoins;
    public CameraController camController;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject hUD;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI pointsCoinsText;
    [SerializeField] TextMeshProUGUI hPCoinsText;
    [SerializeField] TextMeshProUGUI timeCoinsText;
    [SerializeField] TextMeshProUGUI totalCoinsText;
    [SerializeField] TextMeshProUGUI asteroidCollisionText;
    [SerializeField] TextMeshProUGUI healthLostText;
    [SerializeField] TextMeshProUGUI healthGained;
    [SerializeField] TextMeshProUGUI totalTimeText;
    [SerializeField] TextMeshProUGUI totalPointsCoinsLost;

    [SerializeField] GameObject youDiedTextObject;
    private string scoreString;

    public AudioSource goldCoin;
    public AudioSource bronzeCoin;
    public AudioSource blueCoin;
    public AudioSource[] asteroidCollisionSounds;
    private AudioSource asteroidSound;

    private int basePointsMultiplier;


    //START SINGLETON
    public static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<PlayerMovement>();
                    singleton.name = "(Singleton) PlayerManager";
                }
            }
            return instance;
        }
    }
    //END SIngleton
    private void Awake()
    {
        points = Toolbox.Instance.pickUpScript.points;
        boost = 10000f;

        instance = this;
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            hP -= 1;
            boost -= 2000f;
            totalHealthLost += 1;
            if (hP <=0) { hP = 0; }
            Debug.Log("Collided with " + collision.gameObject.name);
            Destroy(collision.gameObject);
            asteroidSound = asteroidCollisionSounds[Random.Range(0, 2)];
            asteroidSound.Play();
            asteroidCollisions += 1;
           
        }
        if (collision.gameObject.tag == "Points")
        {
            totalCoins += 1;
            //boost += 1000f;
            points += 1 * basePointsMultiplier;

            Debug.Log("Collided with " + collision.gameObject.name);
            Destroy(collision.gameObject);
            goldCoin.Play();
            totalPointsCoinsCollected += 1;

            danceCombos.basePointsMultiplier = 1;
            danceCombos.pointsDance1Performed = false;
            danceCombos.pointsDance2Performed = false;
            danceCombos.pointsDance3Performed = false;
            danceCombos.pointsDance4Performed = false;
        }
        if (collision.gameObject.tag== "Time")
        {
            totalCoins += 1;
           // boost += 1000f;
            totalTimeCoinsCollected += 1;
            if (totalTimeCoinsCollected <= 25) { Toolbox.Instance.timerScript.startTime += 3f; }
            else if (totalTimeCoinsCollected >25 && totalTimeCoinsCollected <= 50) { Toolbox.Instance.timerScript.startTime += 2f; }
            else if (totalTimeCoinsCollected >50 && totalTimeCoinsCollected <= 100) { Toolbox.Instance.timerScript.startTime += 1f; }
            else { return; }
            
            Debug.Log("Collided with " + collision.gameObject.name);
           Destroy(collision.gameObject);
            bronzeCoin.Play();
        }
        if (collision.gameObject.tag == "HP")
        {
            totalCoins += 1;
          //  boost += 1000f;
            totalHealthGained += 1;
            totalHPCoinsCollected += 1;
            hP += 1;
            Debug.Log("Collided with " + collision.gameObject.name);
            Destroy(collision.gameObject);
            blueCoin.Play();
        }
        
    }
    public void GameOver()
    {
        

        camController.sideCamera.SetActive(true);
        scoreText.text = score.ToString(format: "f0");
        pointsCoinsText.text = totalPointsCoinsCollected.ToString();
        hPCoinsText.text = totalHPCoinsCollected.ToString();
        timeCoinsText.text = totalTimeCoinsCollected.ToString();

        totalCoinsText.text = totalCoins.ToString();
        totalTime = Time.deltaTime + timerScript.startTime;
        asteroidCollisionText.text = asteroidCollisions.ToString();
        healthLostText.text = totalHealthLost.ToString();
        healthGained.text = totalHealthGained.ToString();
        totalTimeText.text = totalTime.ToString();
        totalPointsCoinsLost.text = pointsLost.ToString();


        Debug.Log("Game Over Man!");
        gameOverPanel.SetActive(true);
        hUD.SetActive(false);
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (boost >= 10000)
        {
            boost = 10000;
        }

        basePointsMultiplier = danceCombos.basePointsMultiplier;

        score = (points + (hP / 2) * Time.time);
        if (score <= 0) { score = 0; }
        points = Toolbox.Instance.pickUpScript.points;
        time = Toolbox.Instance.timerScript.t;
        hpText.text = hP.ToString();
        pointsText.text = points.ToString();
        if (hP <= 0 )
        {
          youDiedTextObject.SetActive(true);
          GameOver();
        }
        if (boost <= 0) { boost = 0;
        if (boost >= 10000) { boost = 10000; }
        }
        if (hP >= 10) { hP = 10; }
    }
}
