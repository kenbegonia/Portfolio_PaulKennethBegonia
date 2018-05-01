using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public PlayerStats player;
    public Text strengthText;
    public Text intelligenceText;
    public Text vitalityText;
    public Text statPointText;
    public Text levelScreenText;
    public Text levelText;
    public Text hpText;
    public Text manaText;
    public Text attackText;
    public Text expText;
    public Text goldText;
    public Text goldStore;
    public GameObject statButtons;
    public GameObject statScreen;
    public GameObject characterSheet;
    public GameObject inventoryScreen;
    public Slider expSlider;
    public Slider hpSlider;

    private int levelValue;

    private int stregnthValue;
    private int intelligenceValue;
    private int vitalityValue;
    private int statPointValue;
    private int currentHpValue;
    private int currentMpValue;
    private int maxHpValue;
    private int maxMpValue;
    private int expValue;
    private int lvlUpValue;
    private int goldValue;
    private bool statScreenUp;
    private bool CharScreenUp;
    private bool inventoryUp;
    private bool skillUp;



    void Awake()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Start()
    {
        statScreen.SetActive(false);
        characterSheet.SetActive(false);
        inventoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        levelValue = player.level;
        stregnthValue = player.strength;
        vitalityValue = player.vitality;
		intelligenceValue = player.intelligence;
        statPointValue = player.statPoints;
		goldValue = player.gold;
        currentHpValue = player.currentHealth;
        maxHpValue = player.maxHealth;
        currentMpValue = player.currentMana;
        maxMpValue = player.maxMana;
        expValue = player.currentExperience;
        lvlUpValue = player.levelUpValue;

        SetLevelText();
        SetStrengthText();
        SetVitalityText();
        SetStatPointText();
		SetGoldText ();
        SetHpText();
        SetManaText();
        SetExperienceText();
        ShowButtons();
        UIControl();
        Screens();
        ExpBar();
        HpBar();
    }

    void SetStrengthText()
    {
        strengthText.text = "Strength:    " + stregnthValue.ToString();
    }

    void SetVitalityText()
    {
        vitalityText.text = "Vitality: " + vitalityValue.ToString();
    }

	void SetIntelligenceText()
	{
		intelligenceText.text = "Intelligence: " + intelligenceValue.ToString();
	}

    void SetStatPointText()
    {
        statPointText.text = "Statpoints: " + statPointValue.ToString();
    }

	void SetGoldText()
	{
		goldText.text = "Gold: " + goldValue.ToString();
        //goldStore.text = "Gold: " + goldValue.ToString();
    }

    void SetHpText()
    {
        hpText.text = "HP: " + currentHpValue.ToString() + "/" + maxHpValue.ToString();
    }

    void SetManaText()
    {
        manaText.text = "MP: " + currentMpValue.ToString() + "/" + maxMpValue.ToString();
    }

    void SetExperienceText()
    {
        expText.text = "Exp: " + expValue.ToString() + "/" + lvlUpValue.ToString();
    }

    void SetLevelText()
    {
        levelText.text = "Level: " + levelValue.ToString();
        levelScreenText.text = "Level: " + levelValue.ToString();
    }

    public void ExpBar()
    {
        float curExp = (float)expValue / (float)lvlUpValue;
        expSlider.value = curExp;
    }

    public void HpBar()
    {
        float curHp = (float)currentHpValue / (float)maxHpValue;
        hpSlider.value = curHp;
    }


    void ShowButtons()
    {
        if (player.statPoints > 0)
            statButtons.SetActive(true);
        else
            statButtons.SetActive(false);

    }
    void UIControl()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (statScreenUp == false)
            {
                CharScreenUp = false;
                statScreenUp = true;
            }
            else
                statScreenUp = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (CharScreenUp == false)
            {
                statScreenUp = false;
                CharScreenUp = true;
            }
            else
                CharScreenUp = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUp == false)
                inventoryUp = true;
            else
                inventoryUp = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (skillUp == false)
                skillUp = true;
            else
                skillUp = false;
        }


        //TESTING ONLY
        if (Input.GetKeyDown(KeyCode.X))
		{
			player.currentExperience += 10;
			player.DeductHealth (50);
		}
    }
    void Screens()
    {
        if (statScreenUp == true)
        {
            statScreen.SetActive(true);
        }
        else
        {
            statScreen.SetActive(false);
        }
        if (CharScreenUp == true)
        {
            characterSheet.SetActive(true);
        }
        else
            characterSheet.SetActive(false);

        if (inventoryUp == true)
            inventoryScreen.SetActive(true);
        else
            inventoryScreen.SetActive(false);
    }
}

