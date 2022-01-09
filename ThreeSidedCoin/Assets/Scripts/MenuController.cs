using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private TMP_InputField _inputFieldMass;
    private TMP_InputField _inputFieldIlv;
    private TMP_InputField _inputFieldIav;
    private TMP_InputField _inputFieldFriction;
    private TMP_InputField _inputFieldAngle;
    private TMP_InputField _inputFieldBounciness;

    private void Start()
    {
        transform.Find("ExitButton").GetComponent<Button>().onClick.AddListener(OnExitClicked);
        transform.Find("RunButton").GetComponent<Button>().onClick.AddListener(OnRunClicked);

        _inputFieldMass = transform.Find("InputField_Mass").GetComponent<TMP_InputField>();
        _inputFieldIlv = transform.Find("InputField_ILV").GetComponent<TMP_InputField>();
        _inputFieldIav = transform.Find("InputField_IAV").GetComponent<TMP_InputField>();
        _inputFieldFriction = transform.Find("InputField_Friction").GetComponent<TMP_InputField>();
        _inputFieldAngle = transform.Find("InputField_Angle").GetComponent<TMP_InputField>();
        _inputFieldBounciness = transform.Find("InputField_Bounciness").GetComponent<TMP_InputField>();

        _inputFieldMass.text = SaveLoadManager.LoadMass().ToString();
        _inputFieldIlv.text = SaveLoadManager.LoadILV().ToString();
        _inputFieldIav.text = SaveLoadManager.LoadIAV().ToString();
        _inputFieldFriction.text = SaveLoadManager.LoadFriction().ToString();
        _inputFieldAngle.text = SaveLoadManager.LoadAngle().ToString();
        _inputFieldBounciness.text = SaveLoadManager.LoadBounciness().ToString();
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }

    private void OnRunClicked()
    {
        SaveLoadManager.SaveMass(float.Parse(_inputFieldMass.text));
        SaveLoadManager.SaveILV(float.Parse(_inputFieldIlv.text));
        SaveLoadManager.SaveIAV(float.Parse(_inputFieldIav.text));
        SaveLoadManager.SaveFriction(float.Parse(_inputFieldFriction.text));
        SaveLoadManager.SaveAngle(float.Parse(_inputFieldAngle.text));
        SaveLoadManager.SaveBounciness(float.Parse(_inputFieldBounciness.text));

        SceneManager.LoadScene("SimScene");
    }
}
