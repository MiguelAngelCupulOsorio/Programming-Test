using Programming_Test_Core.Entity;

namespace Programming_Test_Core.DataLayer.Interface
{
    public interface IContactoDAL
    {
        public Contacto GetContacts(int Id);
        public List<Contacto> Delete(int Id);
        public List<Contacto> ObtenerContactos(string frase);
    }
}
