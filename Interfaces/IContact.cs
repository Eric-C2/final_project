using final_project.Models;

namespace final_project.Interfaces
{
    public interface IContact
    {
        Contact? GetContact(int? id);

        List<Contact> First5Contacts();

        int? AddContact(Contact contact);

        int? DeleteContact(int id);

        int? UpdateContact(Contact contact);
    }
}
