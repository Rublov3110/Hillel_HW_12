using Microsoft.AspNetCore.Mvc;
using System;

namespace Hillel_HW_12.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotebookController : ControllerBase
    {

        public static List<MyFamiliar> MyFamiliarList { get; set; } = new List<MyFamiliar> { };

        [HttpPost]
        public MyFamiliar AddMyFamiliar([FromBody] CreateMyFamiliarRequest request)
        {
            var myFamiliar = new MyFamiliar
            {
                ID = MyFamiliarList.Count,
                Avatarka = request.Avatarka,
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age,
                Number = request.Number,
                Sity = request.Sity,
                Description = request.Description,
            };
            MyFamiliarList.Add(myFamiliar);
            return myFamiliar;
        }

        [HttpPut("{name}")]
        public IActionResult Put([FromRoute] string name, [FromRoute] string surname, [FromBody] CreateMyFamiliarRequest updatedMyFamiliar)
        {
            var person = MyFamiliarList.Find(x => x.Name == name && x.Surname == surname);
            if (person == null)
            {
                return NotFound();
            }

            person.Name = updatedMyFamiliar.Name;
            person.Avatarka = updatedMyFamiliar.Avatarka;
            person.Name = updatedMyFamiliar.Name;
            person.Surname = updatedMyFamiliar.Surname;
            person.Age = updatedMyFamiliar.Age;
            person.Number = updatedMyFamiliar.Number;
            person.Sity = updatedMyFamiliar.Sity;
            person.Description = updatedMyFamiliar.Description;
            return NoContent();
        }

        [HttpGet]
        public List<MyFamiliar> GetMyFamiliar()
        {
            return MyFamiliarList;
        }

        [HttpGet("{name}")]
        public MyFamiliar GetMyFamiliar([FromRoute] string name, [FromRoute] string surname)
        {
            return MyFamiliarList.FirstOrDefault(x => x.Name == name && x.Surname == surname);
        }

        [HttpDelete]
        public bool DeletMyFamiliar([FromRoute] string name, [FromRoute] string surname)
        {
            var myFamiliarList = MyFamiliarList.FirstOrDefault(x => x.Name == name && x.Surname == surname);
            if (myFamiliarList == null) return false;
            MyFamiliarList.Remove(myFamiliarList);
            return true;
        }

    }
}