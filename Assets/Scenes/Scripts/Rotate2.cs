using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.UI;  public class Rotate2 : MonoBehaviour {             int modenum = 1;//デフォルト値を1に設定してあげれば始め必ずInputModeだが、動く。何故？ 
      InputField inputField;       InputField inputField2;
      InputField inputField3;        Text text;       Text text2;       Text text3; 
      int xs ;
      int ys ;       int zs ;     //この変数にそれぞれ値を渡せれば70行目のQuaternionが反応。         public void InputMode(){           Debug.Log("Inputモードです");          modenum = 1;          Debug.Log(modenum);                    }         public void RotationMode(){            Debug.Log("Rotationモードです");           modenum = 2;           Debug.Log(modenum);          }       // Use this for initialization         void Start () {

          if (modenum == 1)
          {

            inputField = GameObject.Find("InputField").GetComponent<InputField>();//InputFieldのInputFieldコンポーネントを呼んでいる             text = GameObject.Find("Text").GetComponent<Text>();//Text(Inputfield下)オブジェクトのTextコンポーネントを呼んでいる。              inputField2 = GameObject.Find("InputField2").GetComponent<InputField>();
            text2 = GameObject.Find("Text2").GetComponent<Text>();

            inputField3 = GameObject.Find("InputField3").GetComponent<InputField>();
            text3 = GameObject.Find("Text3").GetComponent<Text>();            } 
        }
    
        public void InputTextX()         {            text.text = inputField.text;//「.text」はtextの”文字列”という意味の関数。的な？           xs = int.Parse(text.text);           //それぞれの入力値を数値化してint型にぶち込む          }          public void InputTextY(){

          text2.text = inputField2.text;           ys = int.Parse(text2.text);          }          public void InputTextZ(){            text3.text = inputField3.text;           zs = int.Parse(text3.text);          }          public void RoleButton(){            if (modenum == 1){             transform.localRotation = Quaternion.Euler(xs, ys, zs);           }

        } 
    // Update is called once per frame
        void Update(){ 
           if (modenum == 2)           {             // 左右カーソルキー入力に応じて回転方向を決定             float speedx = 0.0f;             if (Input.GetKey(KeyCode.RightArrow)) { speedx += -90.0f; }             if (Input.GetKey(KeyCode.LeftArrow)) { speedx += 90.0f; }              // Y軸(Vector3.up)周りを１フレーム分の角度だけ回転させるQuaternionを作成。(Quaternionの関数という意味。原義の「四元数」とは…)             Quaternion rotys = Quaternion.AngleAxis(speedx * Time.deltaTime, Vector3.up);              float speedy = 0.0f;             if (Input.GetKey(KeyCode.DownArrow)) { speedy += -90.0f; }             if (Input.GetKey(KeyCode.UpArrow)) { speedy += 90.0f; }              Quaternion rotxs = Quaternion.AngleAxis(speedy * Time.deltaTime, Vector3.right);              float speedz = 0.0f;             if (Input.GetKey(KeyCode.S)) { speedz += -90.0f; }             if (Input.GetKey(KeyCode.A)) { speedz += 90.0f; }              Quaternion rotzs = Quaternion.AngleAxis(speedz * Time.deltaTime, Vector3.forward);               // 元の回転済みのRotation値にプラスして上書きする             transform.localRotation = rotys * transform.localRotation;              transform.localRotation = rotxs * transform.localRotation;              transform.localRotation = rotzs * transform.localRotation;              //Debug.Log(transform.localRotation);             }
        }  }  
