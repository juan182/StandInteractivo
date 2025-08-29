[System.Serializable]
public class PlayerData
{
    public string name;
    public string email;
    public int age;
    public string city;
    public int score;

    public PlayerData(string name, string email, int age, string city, int score)
    {
        this.name = name;
        this.email = email;
        this.age = age;
        this.city = city;
        this.score = score;
    }
}
