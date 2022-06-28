using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordsPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI maxTime;
    [SerializeField] TextMeshProUGUI maxKills;
    [SerializeField] TextMeshProUGUI totalKills;

    private void OnEnable()
    {
        maxTime.text = "������������ �����: " + PlayerPrefs.GetInt(RecordsKeys.maxTimeKey) + " ���";
        maxKills.text = "�������� �������� �����: " + PlayerPrefs.GetInt(RecordsKeys.maxKillsKey);
        totalKills.text = "����� �������� �����: " + PlayerPrefs.GetInt(RecordsKeys.totalKillsKey);
    }
}
