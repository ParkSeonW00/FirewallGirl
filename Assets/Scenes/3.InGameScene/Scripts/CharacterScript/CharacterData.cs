using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CharacterStats
{
    public int attackPower = 10;    // ���ݷ�
    public int defensePower = 5;    // ����
    public TextMeshPro Cost;          // �ڽ�Ʈ
    public TextMeshPro HP;          // �����
}

public class CharacterData : MonoBehaviour
{
    public CharacterStats stats;

    private void OnValidate()
    {   
        // ���̾��Ű���� ���� ����Ǹ� �ڵ����� ������Ʈ
        stats.attackPower = Mathf.Max(0, stats.attackPower);
        stats.defensePower = Mathf.Max(0, stats.defensePower);
    }
}