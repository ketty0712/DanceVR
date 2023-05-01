using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using StageInfo;

public class StartSceneManager : MonoBehaviour
{
    private StageList stageList = new StageList();
    private Lighting lighting = new Lighting();
    private Music musicList = new Music();
    private EventMode eventMode = new EventMode();

    [Header("Bullets")]
    [SerializeField] public GameObject bulletLight;
    [SerializeField] public GameObject bulletStage;
    [SerializeField] public GameObject bulletMusic;
    [SerializeField] public GameObject bulletEvent;
    [SerializeField] public GameObject bulletSystem;

    [Header("Select Areas")]
    [SerializeField] public GameObject lightSelectPanel;
    [SerializeField] public GameObject stageSelectPanel;
    [SerializeField] public GameObject musicSelectPanel;
    [SerializeField] public GameObject eventSelectPanel;
    [SerializeField] public GameObject systemSettingPanel;

    [Header("Footer TextAreas")]
    [SerializeField] public GameObject information;
    [SerializeField] public GameObject instruction;

    private GameObject []bullets = new GameObject[5];
    private GameObject []panels = new GameObject[5];

    public string[] informationText = new string[4] {
        "Light", "Stage", "Music", "EventMode"
    };

    [Header("Layouts")]
    public GameObject []Layouts = new GameObject[4];
    public GameObject []Contents = new GameObject[4];

    // [Header("Information Texts")]
    // [SerializeField] public string[] informationText = new string[5];

    private TextMeshProUGUI informationTextMesh;
    private TextMeshProUGUI instructionTextMesh;
    
    void Awake()
    {
        bullets[0] = bulletLight;
        bullets[1] = bulletStage;
        bullets[2] = bulletMusic;
        bullets[3] = bulletEvent;
        bullets[4] = bulletSystem;

        panels[0] = lightSelectPanel;
        panels[1] = stageSelectPanel;
        panels[2] = musicSelectPanel;
        panels[3] = eventSelectPanel;
        panels[4] = systemSettingPanel;

        informationTextMesh = information.GetComponent<TextMeshProUGUI>();
        instructionTextMesh = instruction.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currentIndex", 0);
        InitiatePanel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeText()
    {
        informationTextMesh.text = "當前設置：" + stageList.Name[Player.StageIndex] + "/" + lighting.Name[Player.LightingIndex] + "/" + musicList.Name[Player.MusicIndex] + "/" + eventMode.Name[Player.ModeIndex];
    }

    

    void InitiatePanel()
    {
        // Light
        for(int i = 0; i < lighting.GetLength(); i++)
        {
            GameObject option = Instantiate(Layouts[0], Contents[0].transform);

            TextMeshProUGUI title = FindComponentInChildWithTag<TextMeshProUGUI>(option, "title");
            title.text = lighting.Name[i];

            RawImage image = FindComponentInChildWithTag<RawImage>(option, "thumbnail");
            if(lighting.rawImage[i] != null)
                image.texture = lighting.rawImage[i].texture;

            if(i == Player.LightingIndex)
                option.GetComponent<Button>().Select();
            

            Button button = option.GetComponent<Button>();
            button.onClick.AddListener(() => {
                Player.LightingIndex = button.transform.GetSiblingIndex();
                Debug.Log("LightingIndex: " + Player.LightingIndex);
                ChangeText();
            });
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(Contents[0].GetComponent<RectTransform>());

        // StageList
        for(int i = 0; i < stageList.GetLength(); i++)
        {
            GameObject option = Instantiate(Layouts[1], Contents[1].transform);

            TextMeshProUGUI title = FindComponentInChildWithTag<TextMeshProUGUI>(option, "title");
            title.text = stageList.Name[i];

            RawImage image = FindComponentInChildWithTag<RawImage>(option, "thumbnail");
            if(stageList.rawImage[i] != null)
                image.texture = stageList.rawImage[i].texture;

            if(i == Player.StageIndex)
                option.GetComponent<Button>().Select();

            Button button = option.GetComponent<Button>();
            button.onClick.AddListener(() => {
                Player.StageIndex = button.transform.GetSiblingIndex();
                Debug.Log("StageIndex: " + Player.StageIndex);
                ChangeText();
            });
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(Contents[1].GetComponent<RectTransform>());
    
        // Music
        for(int i = 0; i < musicList.GetLength(); i++)
        {
            GameObject option = Instantiate(Layouts[2], Contents[2].transform);

            TextMeshProUGUI title = FindComponentInChildWithTag<TextMeshProUGUI>(option, "title");
            title.text = musicList.Name[i];

            RawImage image = FindComponentInChildWithTag<RawImage>(option, "thumbnail");
            if(musicList.rawImage[i] != null)
                image.texture = musicList.rawImage[i].texture;

            TextMeshProUGUI length = FindComponentInChildWithName<TextMeshProUGUI>(option, "Length");
            string timeString = string.Format("{0:D2}:{1:D2}", musicList.TimeInSeconds[i] / 60, musicList.TimeInSeconds[i] % 60);
            length.text = timeString;

            TextMeshProUGUI times = FindComponentInChildWithName<TextMeshProUGUI>(option, "TimesPractice");
            times.text = musicList.TimesPractice[i].ToString();

            if(i == Player.MusicIndex)
                option.GetComponent<Button>().Select();
                

            Button button = option.GetComponent<Button>();
            button.onClick.AddListener(() => {
                Player.MusicIndex = button.transform.GetSiblingIndex();
                Debug.Log("MusicIndex: " + Player.MusicIndex);
                ChangeText();
            });
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(Contents[2].GetComponent<RectTransform>());

        // Event
        for(int i = 0; i < eventMode.GetLength(); i++)
        {
            GameObject option = Instantiate(Layouts[3], Contents[3].transform);

            TextMeshProUGUI title = FindComponentInChildWithTag<TextMeshProUGUI>(option, "title");
            title.text = eventMode.Name[i];

            if(i == Player.ModeIndex)
                option.GetComponent<Button>().Select();

            Button button = option.GetComponent<Button>();
            
            button.onClick.AddListener(() => {
                Player.ModeIndex = button.transform.GetSiblingIndex();
                Debug.Log("ModeIndex: " + Player.ModeIndex);
                ChangeText();
            });
        }

        panels[0].SetActive(true);
        for(int i = 1; i < 5; i++)
        {
            panels[i].SetActive(false);
        }

        Contents[0].transform.GetChild(Player.LightingIndex).GetComponent<Button>().Select();
    
        ChangeText();
    }

    public void ChangePanel(int index)
    {
        int currentIndex = PlayerPrefs.GetInt("currentIndex");
        if (currentIndex != index)
        {
            PlayerPrefs.SetInt("currentIndex", index);
            Debug.Log("currentIndex: " + currentIndex);
            Debug.Log("index: " + index);
            if (currentIndex < 5)
            {
                panels[currentIndex].SetActive(false);
                panels[index].SetActive(true);
            }
            if(index < 4)
            {
                Contents[index].transform.GetChild(Player.GetIndex(index)).GetComponent<Button>().Select();
            }
        }
    }

    public static T FindComponentInChildWithTag<T>(GameObject parent, string tag) where T : Component
    {
        Transform t = parent.transform;
        foreach(Transform tr in t)
        {
            if(tr.tag == tag)
            {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }

    public static T FindComponentInChildWithName<T>(GameObject parent, string name) where T : Component
    {
        Transform t = parent.transform;
        foreach(Transform tr in t)
        {
            if(tr.name == name)
            {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }
}
