using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // フィールドでサイズを入れるための変数を作成する
    private float Left, Right, Top, Bottom;

    // カメラから見た画面左下の座標を入れる変数
    Vector3 LeftBottom;

    // カメラから見た画面左上の座標を入れる変数
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        // 子オブジェクトの数だける＾ぷ処理を行う
        foreach (Transform child in gameObject.transform)
        {
            // 子オブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.x >= Right)
            {
                Right = child.transform.localPosition.x;
            }

            // 子オブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.x <= Left)
            {
                Left = child.transform.localPosition.x;
            }

            // 子オブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.z >= Top)
            {
                Top = child.transform.localPosition.z;
            }

            // 子オブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.z <= Bottom)
            {
                Bottom = child.transform.localPosition.z;
            }
        }

        // カメラとプレイヤーの距離を測る（表示画面の四隅を設定するために必要）
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        // スクリーン画面左下の位置を設定する
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        // スクリーン画面左下の位置を設定する
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;

        // 右矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 右方向に0.01動く
            pos.x += 0.01f;
        }

        // 左矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 左方向に0.01動く
            pos.x -= 0.01f;
        }

        // 上矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 上方向に0.01動く
            pos.z += 0.01f;
        }

        // 下矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 下方向に0.01動く
            pos.z -= 0.01f;
        }
        transform.position = new Vector3(
            Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top)
            );
    }
}
