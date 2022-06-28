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
        maxTime.text = "Максимальное время: " + PlayerPrefs.GetInt(RecordsKeys.maxTimeKey) + " сек";
        maxKills.text = "Максимум монстров убито: " + PlayerPrefs.GetInt(RecordsKeys.maxKillsKey);
        totalKills.text = "Всего монстров убито: " + PlayerPrefs.GetInt(RecordsKeys.totalKillsKey);
    }
}
