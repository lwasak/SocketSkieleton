namespace SocketSkeleton.Dto;

public class TestResponse
{
    public int Id { get; }
    public string Name { get; }
    
    public TestResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}