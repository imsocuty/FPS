public class Player_Data
{
    private int HP; // 적기체의 체력

    public Player_Data(int _HP)  // 생성자
    {
        HP = _HP;
    }
    // Player_Data Player = new Player_Data(50); -> 체력이 50인 적의 데이터

    public void decreaseHP(int damage)  // damage만큼 체력을 깎는다.
    {
        HP -= damage;
    }
    // Player_Data player = new Player_Data(50); -> 체력이 50인 적의 데이터
    // player.decreaseHP(20); -> 체력을 20만큼 깎는다.

    public int getHP()
    {
        return HP;
    }
}
    // Player_Data player= new Player_Data(50); -> 체력이 50인 적의 데이터
    // player.getHP(); -> 현재 체력을 반환

       
