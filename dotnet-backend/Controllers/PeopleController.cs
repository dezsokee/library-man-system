using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]

public class PeopleController : ControllerBase {

    private readonly IPeopleRepository _repository;

    public PeopleController(IPeopleRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("api/v1/peoples")]
    public ActionResult<IEnumerable<People>> GetPeoples() {
        List<People> DBPeopleList = _repository.GetAll().ToList();
        
        if(DBPeopleList.Count == 0) {
            return NotFound("There are no peoples in the database");
        }

        return Ok(DBPeopleList);
    }

    [HttpPost]
    [Route("api/v1/addPeople")]
    public ActionResult<People> AddPeople(People newPeople) {
        if(newPeople == null) {
            return BadRequest("Invalid people data");
        }

        if(newPeople.Age < 0) {
            return BadRequest("The year attribute can not be negative");
        }

        _repository.AddPeople(newPeople);

        return Created("", newPeople);   
    }

    [HttpPut]
    [Route("api/v1/updatePeople/{id}")]
    public ActionResult<People> updatePeople(int id, People updatePeopleFromBody) {
        if(id < 0) {
            return BadRequest("Invalid id");
        }

        _repository.UpdatePeople(id, updatePeopleFromBody);

        return Ok(updatePeopleFromBody);
    }

    [HttpDelete]
    [Route("api/v1/deletePeople/{id}")]
    public ActionResult<People> deletePeople (int id) {
        if(id < 0) {
            return BadRequest("Invalid id");
        }

        _repository.DeletePeople(id);
        return Ok();
    }

    [HttpGet]
    [Route("api/v1/peoples/{id}")]
    public ActionResult<People> GetPeopleById(int id) {
        
        if(id < 0) {
            return BadRequest("Invalid id");
        }
        
        var people = _repository.GetPeopleById(id);
        
        if(people == null) {
            return NotFound("There is no people with this id");
        }

        return Ok(people);
    }


}