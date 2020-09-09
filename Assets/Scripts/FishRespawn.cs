using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵の出現を制御するコンポーネント
public class FishRespawn : MonoBehaviour
{
    public FishMovement[] m_enemyPrefabs; // 敵のプレハブを管理する配列
    public float m_interval; // 出現間隔（秒）

    private float m_timer; // 出現タイミングを管理するタイマー

    // 毎フレーム呼び出される関数
    private void Update()
    {
        // 出現タイミングを管理するタイマーを更新する
        m_timer += Time.deltaTime;

        // まだ敵が出現するタイミングではない場合、
        // このフレームの処理はここで終える
        if ( m_timer < m_interval ) return;

        // 出現タイミングを管理するタイマーをリセットする
        m_timer = 0;

        // 出現する敵をランダムに決定する
        var enemyIndex = Random.Range( 0, m_enemyPrefabs.Length );

        // 出現する敵のプレハブを配列から取得する
        var enemyPrefab = m_enemyPrefabs[ enemyIndex ];

        float x = Random.Range(11.0f, 11.5f);
		float y = Random.Range(-4.0f, 0.0f);
		float z = Random.Range(0.0f, 2.0f);

        // 敵のゲームオブジェクトを生成する
        var enemy = Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
        // 敵を初期化する
        enemy.Init();
    }
}

