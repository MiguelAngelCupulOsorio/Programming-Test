using Programming_Test_Core.DataLayer.Interface;
using Programming_Test_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Test_Core.DataLayer
{
    public class ContactosDAL : IContactoDAL
    {
        public List<Contacto> GetContacts()
        {
            List<Contacto> Contactos = new List<Contacto>
             {
                new Contacto { Id = 1, Nombre = "Abbigail Wunsch", Telefono = "123-456-7890", AddressLines = new List<string>{ "Calle 1", "Ciudad A" } },
                new Contacto { Id = 2, Nombre = "Zakary Mayer", Telefono = "987-654-3210", AddressLines = new List<string>{ "Calle 2", "Ciudad B" } },
                new Contacto { Id = 3, Nombre = "Zoila Daugherty II", Telefono = "986-653-3211", AddressLines = new List<string>{ "Calle 3", "Ciudad C" } },
                new Contacto { Id = 4, Nombre = "Theresa Gorczany", Telefono = "985-112-5678", AddressLines = new List<string>{ "Calle 4", "Ciudad D" } }
             };
            return Contactos;
        }
        public List<Contacto> Delete(int Id)
        {
            List<Contacto> contactos = GetContacts();
            Contacto _contacto = contactos.Find(x => x.Id == Id);

            if(_contacto != null)
                contactos.Remove(_contacto);

            return contactos;
        }
        public List<Contacto> ObtenerContactos(string frase)
        {
            List<Contacto> Contactos = GetContacts();

            if (frase == "") throw new Exception("Parametro [frase] vacio");

            var contactosFiltrados = string.IsNullOrEmpty(frase) ? Contactos : Contactos.Where(c => c.Nombre.ToLower().Contains(frase.ToLower())).ToList();

            return contactosFiltrados.OrderBy(c => c.Nombre).ToList();
        }
        public Contacto GetContacts(int Id)
        {
            List<Contacto> contactos = GetContacts();
            return contactos.Find(x => x.Id == Id);
        }
    }
}
