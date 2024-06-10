using System.Net;
using System.Net.Mail;
using webapi;

public class PeopleRepository : IPeopleRepository
{
    private readonly BookContext _context;

    public PeopleRepository(BookContext context){
        _context = context;
    }

    public List<People> GetAll()
    {
        List<People> people = _context.Peoples.ToList();
        return people;
    }

    public People AddPeople(People newPeople)
    {
        _context.Peoples.Add(newPeople);
        _context.SaveChanges();
        return newPeople;
    }

    public void UpdatePeople(int id, People updatePeopleFromBody) {
        var people = _context.Peoples.Find(id);
        
        if (people != null) {
            people.Name = updatePeopleFromBody.Name;
            people.Age = updatePeopleFromBody.Age;
            people.Email = updatePeopleFromBody.Email;
            people.Address = updatePeopleFromBody.Address;
        }
        
        _context.SaveChanges();
    }

    public void DeletePeople(int id) {
        var people = _context.Peoples.Find(id);
        
        if(people != null) {
            _context.Peoples.Remove(people);
        }

        _context.SaveChanges();
    }

    public People GetPeopleById(int id) {
        var people = _context.Peoples.Find(id);

        if(people != null) {
            return people;
        }

        throw new SmtpException((SmtpStatusCode)HttpStatusCode.NotFound, "People not found");
    }

}