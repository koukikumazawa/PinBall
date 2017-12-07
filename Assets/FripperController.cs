using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;    // HingeJointコンポーネントを入れる

    private float defaultAngle = 20;    // 初期の傾き
    private float flickAngle = -20;    // 弾いた時の傾き


    // Use this for initialization
    void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>(); // HingJointコンポーネント取得
        setAngle(this.defaultAngle);    // フリッパーの傾きの設定

	}
	
	// Update is called once per frame
	void Update () {

        //** キーを押した時 **************************************************
        // 左矢印キーで左のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            setAngle(this.flickAngle);
        }

        // 右矢印キーで右のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            setAngle(this.flickAngle);
        }
        //**********************************************************************

        //** キーを離した時 **************************************************
        // 左フリッパーを戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            setAngle(this.defaultAngle);
        }

        // 右フリッパーを戻す
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            setAngle(this.defaultAngle);
        }
        //**********************************************************************
    }


    //  フリッパーの傾きの設定
    public void setAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
