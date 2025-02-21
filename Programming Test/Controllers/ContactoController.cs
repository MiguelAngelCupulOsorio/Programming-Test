using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programming_Test_Core.BusinessLayer.Interface;
using Programming_Test_Core.Entity;
using System.Diagnostics.Contracts;
using static Programming_Test_Core.DataLayer.ContactosDAL;

namespace Programming_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private IContactoBAL _ContactoBAL;

        public ContactoController(IContactoBAL contactoBAL)
        {
            _ContactoBAL = contactoBAL;
        }

        [HttpGet]
        public IActionResult ObtenerContactos([FromQuery] string Frase)
        {
            try
            {
                if (string.IsNullOrEmpty(Frase)) return BadRequest();
                return Ok(_ContactoBAL.ObtenerContactos(Frase));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerContacto(int id)
        {
            try
            {
                Contacto _contacto = _ContactoBAL.GetContacts(id);
                if (_contacto == null) return NotFound();
                return Ok(_contacto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarContacto(int id)
        {
            try
            {
                _ContactoBAL.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
