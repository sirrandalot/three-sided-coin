using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager
{
    private static string _keyThickness = "KEY_THICKNESS";
    private static string _keyMass = "KEY_MASS";
    private static string _keyIlv = "KEY_ILV";
    private static string _keyIav = "KEY_IAV";
    private static string _keyFriction = "KEY_FRICTION";
    private static string _keyAngle = "KEY_ANGLE";
    private static string _keyBounciness = "KEY_BOUNCINESS";

    private static string _keyThrows = "KEY_THROWS";
    private static string _keyCoins = "KEY_COINS";

    public static void SaveThickness(float thickness)
    {
        PlayerPrefs.SetFloat(_keyThickness, thickness);
    }

    public static float LoadThickness()
    {
        return PlayerPrefs.GetFloat(_keyThickness, 1f);
    }

    public static void SaveMass(float mass)
    {
        PlayerPrefs.SetFloat(_keyMass, mass);
    }

    public static float LoadMass()
    {
        return PlayerPrefs.GetFloat(_keyMass, 1f);
    }

    public static void SaveILV(float ilv)
    {
        PlayerPrefs.SetFloat(_keyIlv, ilv);
    }

    public static float LoadILV()
    {
        return PlayerPrefs.GetFloat(_keyIlv, 5f);
    }

    public static void SaveIAV(float iav)
    {
        PlayerPrefs.SetFloat(_keyIav, iav);
    }

    public static float LoadIAV()
    {
        return PlayerPrefs.GetFloat(_keyIav, 1f);
    }

    public static void SaveFriction(float friction)
    {
        PlayerPrefs.SetFloat(_keyFriction, friction);
    }

    public static float LoadFriction()
    {
        return PlayerPrefs.GetFloat(_keyFriction, 0.5f);
    }

    public static void SaveAngle(float angle)
    {
        PlayerPrefs.SetFloat(_keyAngle, angle);
    }

    public static float LoadAngle()
    {
        return PlayerPrefs.GetFloat(_keyAngle, 0f);
    }

    public static void SaveBounciness(float bounciness)
    {
        PlayerPrefs.SetFloat(_keyBounciness, bounciness);
    }

    public static float LoadBounciness()
    {
        return PlayerPrefs.GetFloat(_keyBounciness, 0.5f);
    }

    public static void SaveThrows(int throws)
    {
        PlayerPrefs.SetInt(_keyThrows, throws);
    }

    public static int LoadThrows()
    {
        return PlayerPrefs.GetInt(_keyThrows, 10);
    }

    public static void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt(_keyCoins, coins);
    }

    public static int LoadCoins()
    {
        return PlayerPrefs.GetInt(_keyCoins, 100);
    }
}
