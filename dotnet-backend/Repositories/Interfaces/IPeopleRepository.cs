using System.Collections.Generic;
using System.Threading.Tasks;
using webapi;

public interface IPeopleRepository
{
    List<People> GetAll();

    People AddPeople(People newPeople);

    void UpdatePeople(int id, People updatePeopleFromBody);

    void DeletePeople(int id);

    People GetPeopleById(int id);

}
