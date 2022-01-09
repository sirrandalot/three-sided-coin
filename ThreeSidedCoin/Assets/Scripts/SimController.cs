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

    public GameObject CoinPrefab;
    public PhysicMaterial CoinPhysMat;
    public PhysicMaterial FloorPhysMat;

    private Transform _coinParent;

    private float _thickness;
    private float _mass;
    private float _ilv;
    private float _iav;
    private float _friction;
    private float _angle;
    private float _bounciness;

    private int _throws;
    private int _coins;

    private GameObject[] _coinObjects;

    private Vector3 _startPosition = new Vector3(0, 2f, 0);
    private float _coinDiameter = 1f;

    private void Start()
    {
        _coinParent = transform.Find("CoinParent");

        BackButton.onClick.AddListener(OnBackButtonClicked);

        _thickness = SaveLoadManager.LoadThickness();

        if (_thickness < 0.01f)
            _thickness = 0.01f;
        else if (_thickness > 2f)
            _thickness = 2f;

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

        if (_angle < 0f)
            _angle = 0f;

        _throws = SaveLoadManager.LoadThrows();

        if (_throws < 1)
            _throws = 1;

        _coins = SaveLoadManager.LoadCoins();

        if (_coins < 1)
            _coins = 1;

        ParamsText.text = string.Format(CultureInfo.InvariantCulture, 
            "{0} throws with {1} coins each -> {2} total coin tosses\nThickness: {3}\nMass: {4}\nInitial Linear Velocity: {5}\nInitial Angular Velocity: {6}\nFriction: {7}\nBounciness: {8}\nAngle: {9}",
            _throws, _coins, _throws*_coins, _thickness, _mass, _ilv, _iav, _friction, _bounciness,
            _angle == 0 ? "random" : _angle);

        _coinObjects = new GameObject[_coins];

        for (var i = 0; i < _coinObjects.Length; i++)
        {
            _coinObjects[i] = Instantiate(CoinPrefab, _coinParent);
        }

        // Changing the physics properties of both the coins and the floor for bounciness and friction
        // to keep the numbers as "pure" as possible
        CoinPhysMat.bounciness = _bounciness;
        FloorPhysMat.bounciness = _bounciness;
        CoinPhysMat.staticFriction = _friction;
        CoinPhysMat.dynamicFriction = _friction;
        FloorPhysMat.staticFriction = _friction;
        FloorPhysMat.dynamicFriction = _friction;

        ThrowCoins();
    }

    private void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void ThrowCoins()
    {
        for(var i = 0; i < _coinObjects.Length; i++)
        {
            var coin = _coinObjects[i];

            // 0.5 necessary because of cylinder default size
            var thickness = _coinDiameter * _thickness * 0.5f;

            coin.transform.position = _startPosition;
            coin.transform.rotation = Random.rotationUniform;
            coin.transform.localScale = new Vector3(_coinDiameter, thickness, _coinDiameter);

            var rb = coin.GetComponent<Rigidbody>();
            rb.mass = _mass;
            rb.velocity = _angle > 0 ? new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle)) * _ilv : Random.insideUnitSphere * _ilv;
            rb.angularVelocity = Random.insideUnitSphere * _iav;

        }
    }

}
