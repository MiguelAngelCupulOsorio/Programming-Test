using Programming_Test_Core.Entity;

namespace Programming_Test_Core.BusinessLayer.Interface
{
    public interface IContactoBAL
    {
        public Contacto GetContacts(int Id);
        public List<Contacto> Delete(int Id);
        public List<Contacto> ObtenerContactos(string frase);
    }
}
