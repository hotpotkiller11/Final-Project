using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;//引入命名空间  利用

/// <summary>
/// 语音识别（主要是别关键字）
/// </summary>
public class speechKey : MonoBehaviour
{
    // 短语识别器
    private PhraseRecognizer m_PhraseRecognizer;
    // 关键字
    public string[] keywords = { "hello", "start","bye" };
    // 可信度
    public ConfidenceLevel m_confidenceLevel = ConfidenceLevel.Medium;
    /// 显示的文字
    private Text ShowText;

    public string content;
    //public GameObject man;
    public Animator animator_man;
    //public GameObject flower;
    public Animator animator_flower;
    //public GameObject Dog;
    public Animator animator_dog;

    public GameObject startpanal;
    public GameObject quitpanal;

    public GameObject Particle;
    void Start()
    {
        //ShowText = GameObject.Find("ShowText").GetComponent<Text>();
        if (m_PhraseRecognizer == null)
        {
            //创建一个识别器
            m_PhraseRecognizer = new KeywordRecognizer(keywords, m_confidenceLevel);
            //通过注册监听的方法
            m_PhraseRecognizer.OnPhraseRecognized += M_PhraseRecognizer_OnPhraseRecognized;
            //开启识别器
            //m_PhraseRecognizer.Start();
            Debug.Log("succesfully created recorgnizer");
            //StartPhraseRecognize();
        }
        //startpanal.SetActive(true);
        //animator_man = flower.GetComponent<Animator>();
        //animator_flower = man.GetComponent<Animator>();
    }

    public void StartPhraseRecognize()
    {
        //开启识别器
        m_PhraseRecognizer.Start();

        Debug.Log("start listening");

    }

    ///  当识别到关键字时，自动调用这个方法
    /// <param name="args"></param>
    private void M_PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        SpeechRecognition();
        //ShowText.text = "recognized：" + args.text;
        Debug.Log("listening"+ args.text);
        print(args.text);
        content = args.text;
        if (content == "hello")
        //{ animator_man.SetInteger("super_ID", 5); }
        {
            Debug.Log("find hello");
            //startpanal.SetActive(true);
            animator_man.SetInteger("super_ID", 13);
            animator_flower.SetInteger("ActionID", 13);
            animator_dog.SetInteger("DogControl", 13);
            Invoke("backidle", 2);
        }
        if (content == "start")
        {
            startpanal.SetActive(true);
        }
        if(content == "bye")
        {
            quitpanal.SetActive(true);
        }
        //print(ShowText.text);
    }

    /// 点击按钮释放
    public void StopPhraseRecognize()
    {
        m_PhraseRecognizer.Stop();

        Debug.Log("stop listening");

    }
    /// <summary>
    /// 关闭程序的时候进行释放
    /// </summary>
    private void OnDestroy()
    {
        //判断场景中是否存在语音识别器，如果有，释放
        if (m_PhraseRecognizer != null)
        {
            //用完应该释放，否则会带来额外的开销
            m_PhraseRecognizer.Dispose();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 识别到语音的操作
    /// </summary>
    void SpeechRecognition()
    {
        //if (content == "hello")
        //{ animator_man.Play("0"); }
        //animator_flower.Play("hi");}
    }
    public void backidle()
    {
        animator_man.SetInteger("super_ID", 0);
        animator_flower.SetInteger("ActionID", 0);
        animator_dog.SetInteger("DogControl", 0);
        Particle.SetActive(false);
        Debug.Log("now audio anim is  back to idle");

    }
}