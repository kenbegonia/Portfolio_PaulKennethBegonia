using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

public class BulletDesignerWindow : EditorWindow {

    Texture2D headerSectionTexture;
    Texture2D bulletSectionTexture;
    Texture2D bulletIconTexture;
    Texture2D bulletIconSecond;

    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);

    Rect headerSection;
    Rect bulletSection;
    Rect bulletIconSection;
    Rect bulletIconScnSecond;

    GUISkin skin;
    GUISkin buttonSkin;

    static BulletData bulletData;
    public static BulletData bulletInfo { get { return bulletData; } }

    float iconSize = 80;

    [MenuItem("Window/Projectile Designer v0.1")]
    static void OpenWindow()
    {
        BulletDesignerWindow window = (BulletDesignerWindow)GetWindow(typeof(BulletDesignerWindow));
        window.minSize = new Vector2(250, 250);
        window.Show();
    }

    void OnEnable()
    {
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("GUIstyles/BulletLabelSkin");
        buttonSkin = Resources.Load<GUISkin>("GUIstyles/ButtonSkin");
    }

    public static void InitData()
    {
        bulletData = (BulletData)ScriptableObject.CreateInstance(typeof(BulletData));
    }

    void OnGUI()
    {
        DrawLayouts();
        DrawBulletSettings();
        DrawHeader();
    }

    void InitTextures()
    {
        headerSectionTexture = Resources.Load<Texture2D>("Icons/Sniper2");
        bulletSectionTexture = Resources.Load<Texture2D>("Icons/Section");
        bulletIconTexture = Resources.Load<Texture2D>("Icons/Bullet1");
        bulletIconSecond = Resources.Load<Texture2D>("Icons/Bullet2");
    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 75;

        bulletSection.x = 0;
        bulletSection.y = 75;
        bulletSection.width = Screen.width;
        bulletSection.height = Screen.width - 75;

        bulletIconSection.x = (bulletSection.x + bulletSection.width / 2f) - 90;
        bulletIconSection.y = bulletSection.y + 10;
        bulletIconSection.width = iconSize;
        bulletIconSection.height = iconSize;

        bulletIconScnSecond.x = (bulletSection.x + bulletSection.width / 2f) - 5;
        bulletIconScnSecond.y = bulletSection.y + 10;
        bulletIconScnSecond.width = iconSize;
        bulletIconScnSecond.height = iconSize;


        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(bulletSection, bulletSectionTexture);
        GUI.DrawTexture(bulletIconSection, bulletIconTexture);
        GUI.DrawTexture(bulletIconScnSecond, bulletIconSecond);
    }

    void DrawBulletSettings()
    {
        GUILayout.BeginArea(bulletSection);

        GUILayout.Space(iconSize + 11);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage type: ", skin.GetStyle("Label"));
        bulletData.dmgType = (BulletDmgType)EditorGUILayout.EnumPopup(bulletData.dmgType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(12);

        if (GUILayout.Button("Create", GUILayout.Height(40))) 
        {
            GeneralSettings.OpenWindow();
        }

        GUILayout.EndArea();
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Projectile Designer v0.1", skin.GetStyle("Header1"));
        GUILayout.EndArea();
    }
}

public class GeneralSettings:EditorWindow
{
    static GeneralSettings window;

    public static void OpenWindow()
    {
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(200, 200);
        window.Show();
    }

    void OnGUI()
    {
        DrawSettings((BulletData)BulletDesignerWindow.bulletInfo);
    }

    void DrawSettings(BulletData b_Data)
    {
        b_Data.b_Name = EditorGUILayout.TextField("Projectile name: ", b_Data.b_Name);
        b_Data.b_Mass = EditorGUILayout.FloatField("Projectile mass: ", b_Data.b_Mass);
        b_Data.b_Velocity = EditorGUILayout.FloatField("Projectile max velocity: ", b_Data.b_Velocity);
        b_Data.b_Damage = EditorGUILayout.FloatField("Projectile basic damage: ", b_Data.b_Damage);
        b_Data.hasAnimation = EditorGUILayout.Toggle("Has animation? ", b_Data.hasAnimation);

        if (b_Data.hasAnimation != false)
        {
            EditorGUILayout.HelpBox("Reminder: Please uncheck 'has animation' box if animation is not yet available.", MessageType.Warning);
            b_Data.animation = (Animation)EditorGUILayout.ObjectField("Projectile animation: ", b_Data.animation, typeof(Animation));
        }

        b_Data.b_Prefab = (GameObject)EditorGUILayout.ObjectField("Projectile prefab: ", b_Data.b_Prefab, typeof(GameObject));

        if (b_Data.b_Name == null || b_Data.b_Name.Length < 2)
        {
            EditorGUILayout.HelpBox("Reminder: Please input a name for the new projectile. [Should be longer than two characters]", MessageType.Warning);
        }

        if (GUILayout.Button("Finish and save new projectile...", GUILayout.Height(40)))
        {
            SaveBulletSettings();
            window.Close();
        }
    }

    void SaveBulletSettings()
    {
        string prefabPath;
        string newPrefabPath = "Assets/Prefabs/Bullets/";
        string dataPath = "Assets/Resources/BulletData/Data/";

        dataPath += BulletDesignerWindow.bulletInfo.b_Name + ".asset";
        AssetDatabase.CreateAsset(BulletDesignerWindow.bulletInfo, dataPath);

        newPrefabPath += BulletDesignerWindow.bulletInfo.b_Name + ".prefab";
        prefabPath = AssetDatabase.GetAssetPath(BulletDesignerWindow.bulletInfo.b_Prefab);

        AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        GameObject bulletPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));

        if (!bulletPrefab.GetComponent<Bullet>())
            bulletPrefab.AddComponent(typeof(Bullet));

        bulletPrefab.GetComponent<Bullet>().bulletData = BulletDesignerWindow.bulletInfo;
    }
}
