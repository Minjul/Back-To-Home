using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public sealed class Define 
{
    public enum SceneName
    {
        title,
        mainMenu,
        uITest,
        park,
        trainStation
    }

    //Resources Path

    public const string MainMenuPath = "UI/Menu";

    public const string TransitionPath = "UI/Transitions";

    public const string MemClouds1Path = "Environment/Clouds/Cloud_1";
    public const string MemClouds2Path = "Environment/Clouds/Cloud_2";
    public const string MemClouds3Path = "Environment/Clouds/Cloud_3";
    public const string MemClouds4Path = "Environment/Clouds/Cloud_4";
    public const string MemClouds5Path = "Environment/Clouds/Cloud_5";


    public const string FruitBrake = "Object/Fruits/FruitBrake";

    public const string Clouds1Path = "Environment/Clouds/NewCloud_1";
    public const string Clouds2Path = "Environment/Clouds/NewCloud_2";
    public const string Clouds3Path = "Environment/Clouds/NewCloud_3";

    public const string Car1 = "Object/Car/Car1";
    public const string Car2 = "Object/Car/Car2";
    public const string Car3 = "Object/Car/Car3";
    public const string Car4 = "Object/Car/Car4";


    //for MiniGame Path
    #region Parkour MiniGame Path

    //Level-EasyType
    public const string EasyType1 = "MiniGame/LevelType/Easy/EasyType1";
    public const string EasyType2 = "MiniGame/LevelType/Easy/EasyType2";
    public const string EasyType3 = "MiniGame/LevelType/Easy/EasyType3";

    //Level-NormalType

    //Level-HardType

    #endregion
    //GameObject names


}
