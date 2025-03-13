namespace MediaAPI.Domain.Entities;

public class Media
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Director { get; private set; }
    public string Summary { get; private set; }

    // Construtor protegido para o EF Core
    protected Media() { }

    public Media(string name, string director, string summary)
    {
        Id = Guid.NewGuid();
        Name = name;
        Director = director;
        Summary = summary;
    }

    public Media(Guid id, string name, string director, string summary) : this(name, director, summary)
    {
        Id = id;
        Name = name;
        Director = director;
        Summary = summary;
    }

    public void Update(string name, string director, string summary)
    {
        Name = name;
        Director = director;
        Summary = summary;
    }
}
