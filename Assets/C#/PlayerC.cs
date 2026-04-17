using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour{
    public Animator Player_Animator_Controller;
    private CharacterController controller;
    private Vector3 moveDirection;
    public float speed = 2f;
    public float jumpForce = 5f;
    public float gravity = 9.8f;
    public int RoateSpeed = 80;

    public Image PlayerHPBar_HP;
    public int PlayerHP = 100;

    public GameObject PlayerSword;
    public bool PlayerSwordEnabled = false;

    public bool PlayerAttacking = false;

private void Start(){
    controller = GetComponent<CharacterController>();
    Player_Animator_Controller = GetComponent<Animator>();
    //gameObject PlayerHPBar_HP = GameObject.Find("HP");
    //PlayerHPBar_HP = 
}

private void Update(){
    // 檢查角色是否在地面上
    if (controller.isGrounded || isGrounded()){
        
        float RotateX = Input.GetAxis("Horizontal");
        transform.Rotate(0,RotateX * Time.deltaTime * RoateSpeed, 0);
        // 取得玩家輸入
        float moveZ = Input.GetAxis("Vertical");
        speed = Input.GetKey(KeyCode.LeftShift) ? 4 : 2;
        Player_Animator_Controller.SetFloat("WalkSpeed", Mathf.Abs(moveZ * speed));

        // 計算移動方向
        moveDirection = new Vector3(0f, 0f, moveZ * speed);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // 處理跳躍
        if (Input.GetButtonDown("Jump")){
            Player_Animator_Controller.SetTrigger("PlayerJump");
            moveDirection.y = jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.B)){
            Player_Animator_Controller.SetTrigger("PlayerBoxing");
        }
        if (Input.GetKeyDown(KeyCode.T) && PlayerSwordEnabled){
            Player_Animator_Controller.SetTrigger("PlayerSwordATK");
        }
        PlayerAttacking = Player_Animator_Controller.GetFloat("SwordATKTime") > 0.01f? true : false;

    }

    // 處理重力
    moveDirection.y -= gravity * Time.deltaTime;

    // 移動角色
    controller.Move(moveDirection * Time.deltaTime);

    }
bool isGrounded(){
    float groundCheckDistance = 1f;
    return Physics.Raycast(transform.position,Vector3.down,groundCheckDistance);
}

private void OnTriggerEnter(Collider hit){
    if (hit.gameObject.name == "Sword"){
        PlayerSwordEnabled = true;
        Destroy(hit.gameObject);
        PlayerSword.SetActive(true);
        print("hit Sword");
    }
}

}

