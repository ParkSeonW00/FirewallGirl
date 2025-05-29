using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UpDownMgr : MonoBehaviour
{
    [Header("ī�� UI")]
    public GameObject[] Card;

    [Header("ī�� ���")]
    public TextMeshProUGUI[] SkillText;
    public TextMeshProUGUI[] UpDownText;
    public Image[] SkillIcons;

    [Header("ī�� Sprite")]
    public Sprite swordSprite; //���ݷ� = ����
    public Sprite shieldSprite; //���� = Į 
    public Sprite costUpSprite; //�ڽ�Ʈ = ��� �׷���
    public Sprite costDownSprite; //�ڽ�Ʈ = ��� �׷���
    public Sprite hpSprite; //ü�� = ���� 
    public Sprite avoidanceSprite; //ȸ���� = �ٶ�

    [Header("ī�� Reload ��ư")]
    public Button ReloadBtn; //ī�� ���ε� ��ư

    //ī�� ��� 
    private List<int> recentValues = new List<int>();
    private const int RECENT_HISTORY_LIMIT = 10; // ����� �ֱ� ���� ��

    void Start()
    {
        foreach (GameObject card in Card)
        {
            card.SetActive(false);
        }
        UpDownSystem(); //ó���� ���ε� �����ϸ鼭 ����
        //���ε� ��ư ����
        ReloadBtn.onClick.AddListener(ReloadBtnClick);
    }

    Sprite GetSprite(string description, int value)
    {
        switch (description)
        {
            case "���ݷ�": return swordSprite;
            case "����": return shieldSprite;
            case "�ڽ�Ʈ":
                return value > 0 ? costUpSprite : costDownSprite;
            case "ü��": return hpSprite;
            case "ȸ����": return avoidanceSprite;
            default: return null;
        }
    }

    public struct UpDown
    {
        public int value;
        public string description;

        public UpDown(int value, string description)
        {
            this.value = value;
            this.description = description;
        }

        public override string ToString()
        {
            return $"{(value > 0 ? "+" : "")}{value}";
        }
    }

    UpDown GenerateRandomAugment()
    {
        int value = 0;
        int attempt = 0;

        //0 ������
        while (value == 0 && attempt < 100)
        {
            int candidate = Random.Range(-10, 10);
            attempt++;

            // �ֱٿ� ���� ���� �ƴϰų�, ���� Ȯ��(30%)�� ���� ���
            if (candidate != 0 &&
                (!recentValues.Contains(candidate) || Random.value < 0.3f))
            {
                value = candidate;
                break;
            }
        }

        // value�� ������ 0�̸� ������ 0�� ������ �ٸ� ���� ����
        if (value == 0)
        {
            do
            {
                value = Random.Range(-10, 10);
            } while (value == 0);
        }

        // �ֱٰ� ����Ʈ�� ����
        recentValues.Add(value);
        if (recentValues.Count > RECENT_HISTORY_LIMIT)
        {
            recentValues.RemoveAt(0); 
        }

        string[] descriptions = { "���ݷ�", "����", "�ڽ�Ʈ", "ü��", "ȸ����" };
        string selected = descriptions[Random.Range(0, descriptions.Length)];

        return new UpDown(value, selected);
    }

    public void UpDownSystem()
    {   
        for (int i=0; i<3; i++)
        {
            UpDown randomAugment = GenerateRandomAugment();
            SkillText[i].text = randomAugment.description;
            UpDownText[i].text = randomAugment.ToString();

            Sprite icon = GetSprite(randomAugment.description, randomAugment.value);
            SkillIcons[i].sprite = icon;
        }
    }

    //ī�� ���ε�
    public void ReloadBtnClick()
    {
        foreach (GameObject card in Card)
        {
            card.SetActive(true);
        }
        UpDownSystem();
    }
}
