using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    [Header("對話")]
    public string sayStart = "你好啊旅行者，請蒐集完整金幣以及殺死那個土著!!!";
    public string sayNotComplete = "你還沒有完成?!";
    public string sayComplete = "不愧是旅行者啊!";
    [Range(0.001f, 1.5f)]
    public float speed = 1.5f;
    public AudioClip soundSay;
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    public Image img;
    public GameObject CANNNN;
    public enum state
    {
        start, notComplete, complete
    }
    public state _state;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           Say();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SayClose();
            this.transform.position = new Vector3(27.62f, -3.36f, 0);

        }
    }

    public void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;


        // 判斷式(狀態)
        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(sayStart));           // 開始對話
                _state = state.notComplete;
                
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));     // 開始對話未完成
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));        // 開始對話完成
                CANNNN.SetActive(true);
                break;
        }
    }
    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                              // 清空文字

        for (int i = 0; i < say.Length; i++)            // 迴圈跑對話.長度
        {
            textSay.text += say[i].ToString();          // 累加每個文字
            yield return new WaitForSeconds(speed);     // 等待
        }
    }
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }
     public void PlayerGet()
    {
        countPlayer++;
    }

}


