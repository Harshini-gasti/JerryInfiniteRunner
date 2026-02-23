using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class JerryRunnerRBController : MonoBehaviour
{
    public static JerryRunnerRBController instance;

    // Reference for Rigidbody, Animator components
    Rigidbody rb;
    Animator animator;

    // Jerry Movement Vector
    Vector3 Movement;

    float speed = 7f;

    // Jerry X axis Position
    float jerryXaxisposition;

    // TextMeshPro ref
    [SerializeField] TextMeshProUGUI cheeseText;
    [SerializeField] TextMeshProUGUI scoreText;

    // count
    int count = 0;
    int score = 0;

    void Awake()
    {
        instance = this;
        LoadData();
        UpdateScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize data fields
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        StartCoroutine(ScoreCounter());
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
        // Calculate X axis position
        jerryXaxisposition = Mathf.Clamp(transform.position.x, -3f, 3f);
        //Debug.Log(jerryXaxisposition);

        // Get Horizontal Axis reference --> Left, Right arrows / A, D Keys
        // GetAxis() retures all values between -1..0..1
        // GetAxisRaw() retures only three values --> -1, 0, 1
        float h = Input.GetAxisRaw("Horizontal"); // -1, 0, 1

        // Calculate Movement vector
        Movement = new Vector3(h * speed, 0, 0); // 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Movement.x, rb.velocity.y, rb.velocity.z);
        rb.position = new Vector3(jerryXaxisposition, rb.position.y, rb.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cheese")
        {
            // Play Audio
            // Increase Score
            count += 1;
          // UpdateScore();
            //Debug.Log(count);
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator ScoreCounter()
    {
        while(Application.isPlaying)
        {
            yield return new WaitForSeconds(1f);
            score += 1;
            UpdateScore();
            //Debug.Log(score);

        }
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
        cheeseText.text = count.ToString();
    }

    [Serializable]
    public class JerryData
    {
        public int score;
        public int count;
    }

    
    public void SaveData()
    {
        JerryData jerryData = new JerryData();
        jerryData.score = score;
        jerryData.count = count;

        string jsonData = JsonUtility.ToJson(jerryData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JerryData jerryData = JsonUtility.FromJson<JerryData>(json);

            count = jerryData.count;
            score = jerryData.score;

            
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }



}
