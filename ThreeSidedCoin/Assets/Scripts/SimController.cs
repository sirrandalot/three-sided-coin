using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimController : MonoBehaviour
{
    public TextMeshProUGUI ParamsText;
    public Button BackButton;

    private float _mass;
    private float _ilv;
    private float _iav;
    private float _friction;
    private float _angle;
    private float _bounciness;

    private int _throws;
    private int _coins;

    private void Start()
    {
        BackButton.onClick.AddListener(OnBackButtonClicked);

        _mass = SaveLoadManager.LoadMass();

        if (_mass < 0.01f)
            _mass = 0.01f;

        _ilv = SaveLoadManager.LoadILV();

        if (_ilv < 0f)
            _ilv = 0f;

        _iav = SaveLoadManager.LoadIAV();

        if (_iav < 0f)
            _iav = 0f;

        _friction = SaveLoadManager.LoadFriction();

        if (_friction < 0f)
            _friction = 0f;
        else if (_friction > 1f)
            _friction = 1f;

        _bounciness = SaveLoadManager.LoadBounciness();

        if (_bounciness < 0f)
            _bounciness = 0f;
        else if (_bounciness > 1f)
            _bounciness = 1f;

        _angle = SaveLoadManager.LoadAngle();

        if (_angle < 0)
            _angle = -1;

        _throws = SaveLoadManager.LoadThrows();

        if (_throws < 1)
            _throws = 1;

        _coins = SaveLoadManager.LoadCoins();

        if (_coins < 1)
            _coins = 1;

        ParamsText.text = string.Format(CultureInfo.InvariantCulture, 
            "{0} throws with {1} coins each -> {2} total coin tosses\nMass: {3}\nInitial Linear Velocity: {4}\nInitial Angular Velocity: {5}\nFriction: {6}\nBounciness: {7}\nAngle: {8}",
            _throws, _coins, _throws*_coins, _mass, _ilv, _iav, _friction, _bounciness,
            _angle == -1 ? "random" : _angle);
    }

    private void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
