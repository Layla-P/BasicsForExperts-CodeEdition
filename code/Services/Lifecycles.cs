namespace BasicsForExperts.Web.Services;

public class Lifecycles
{
    private readonly List<int> _intList = new();

    public Lifecycles()
    {
        var rand = new Random();
        var i = 3;
        while (i > 0)
        {
            var next = rand.Next(0, 10);
            _intList.Add(next);
            i--;
        }
    }
    
    public List<int> GetInts()
    {
        return _intList;
    }
}