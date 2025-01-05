using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public int attackPower = 10;  // ���ݷ�
    public int defensePower = 5; // ����
    public int cost = 100;       // �ڽ�Ʈ
}

public class CharacterData : MonoBehaviour
{
    public CharacterStats stats;

    private void OnValidate()
    {   
        // ���̾��Ű���� ���� ����Ǹ� �ڵ����� ������Ʈ
        stats.attackPower = Mathf.Max(0, stats.attackPower);
        stats.defensePower = Mathf.Max(0, stats.defensePower);
        stats.cost = Mathf.Max(0, stats.cost);
    }
}