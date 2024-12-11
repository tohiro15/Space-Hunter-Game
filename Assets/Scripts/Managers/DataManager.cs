using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private EnemyData _enemyData;

    private void Start()
    {
        if(_playerData.StagePassed <= 1) _enemyData.Health = 1;
    }
    public void AddWallet(int value)
    {
        _playerData.Collected�oinsAmount++;

        PlayerPrefs.SetInt(PlayerData.WalletAmountKey, _playerData.WalletAmount += value);
    }

    public void SaveDataAfterDeath()
    {
        _playerData.Collected�oinsAmount = 0;
        _enemyData.Health = 0;

        if (_playerData != null)
        {
            if (_playerData.StagePassed > _playerData.RecordStage)
            {
                _playerData.RecordStage = _playerData.StagePassed - 1;
                PlayerPrefs.SetInt(PlayerData.RecordStageKey, _playerData.RecordStage);
            }

            _playerData.StagePassed = 1;

            PlayerPrefs.SetInt(PlayerData.WalletAmountKey, _playerData.WalletAmount);
            PlayerPrefs.SetInt(PlayerData.StagePassedKey, 1);

            PlayerPrefs.Save();
            Debug.Log("������ ������ ��������� � PlayerPrefs.");
        }
        else
        {
            Debug.LogError("PlayerData �� ���������������.");
        }
    }
    public void SaveDataAfterVictory()
    {
        _playerData.Collected�oinsAmount = 0;

        if (_playerData != null)
        {
            PlayerPrefs.SetInt(PlayerData.WalletAmountKey, _playerData.WalletAmount);

            PlayerPrefs.Save();
            Debug.Log("������ ������ ��������� � PlayerPrefs.");
        }
        else
        {
            Debug.LogError("PlayerData �� ���������������.");
        }
    }

    public void SaveDataAfterShop()
    {
        if (_playerData != null)
        {
            PlayerPrefs.SetInt(PlayerData.WalletAmountKey, _playerData.WalletAmount);
            PlayerPrefs.SetFloat(PlayerData.FireRateKey, _playerData.FireRate);

            PlayerPrefs.Save();
            Debug.Log("������ ������ ��������� � PlayerPrefs.");
        }
        else
        {
            Debug.LogError("PlayerData �� ���������������.");
        }
    }
}
