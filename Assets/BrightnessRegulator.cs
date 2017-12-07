using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {

    Material myMaterial;    // Materialを入れる

    private float minEmissoin = 0.3f;   // Emissionの最小値
    private float magEmissoin = 2.0f;   // Emissionの強度

    private int degree = 0; // 角度
    private int speed = 10; // 発光速度

    Color defaultColor = Color.white;   // ターゲットのデフォルトの色


    // Use this for initialization
    void Start () {
        //** タグによって光らせる色を変える **************************
        if(tag == "SmallStarTag")   // SmallStarの場合
        {
            this.defaultColor = Color.white;
        }
        else if(tag == "LargeStarTag")  // LargeStarの場合
        {
            this.defaultColor = Color.yellow;
        }
        else if(tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.blue;
        }
        //****************************************************************

        // オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //  オブジェクトの最初の色の設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmissoin);
    }

    // Update is called once per frame
    void Update () {
		if(this.degree >= 0)
        {
            // 光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmissoin + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmissoin);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            // 現在の角度を小さくする
            this.degree -= this.speed;
        }
	}

    // 衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        this.degree = 180;  // 角度を180に設定
    }
}
