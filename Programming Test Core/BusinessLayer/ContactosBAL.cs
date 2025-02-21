using Programming_Test_Core.BusinessLayer.Interface;
using Programming_Test_Core.DataLayer.Interface;
using Programming_Test_Core.Entity;

namespace Programming_Test_Core.BusinessLayer
{
    public class ContactosBAL : IContactoBAL
    {
        public IContactoDAL _ContactosDAL;
        public ContactosBAL(IContactoDAL ContactosDAL)
        {
            _ContactosDAL = ContactosDAL;
        }

        public List<Contacto> Delete(int Id)
        {
            return _ContactosDAL.Delete(Id);
        }

        public Contacto GetContacts(int Id)
        {
            return _ContactosDAL.GetContacts(Id);
        }

        public List<Contacto> ObtenerContactos(string frase)
        {
            return _ContactosDAL.ObtenerContactos(frase);
        }
    }
}
