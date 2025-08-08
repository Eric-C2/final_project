namespace final_project.Data;
using final_project.Models;
using final_project.Interfaces;
using System.Linq;


public class ContactContextDAO : IContact
{
    public ContactContext _context;

    public ContactContextDAO(ContactContext context)
    {
        _context = context;
    }

    public Contact? GetContact(int? id)
    {
        return _context.Contacts.Where(x => x.Id.Equals(id)).FirstOrDefault();
    }

    public List<Contact> First5Contacts()
    {
        return _context.Contacts.Take(5).ToList();
    }

    public int? AddContact(Contact contact)
    {
        try
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public int? DeleteContact(int id)
    {
        var contact = this.GetContact(id);

        if (contact == null)
            return null;

        try
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public int? UpdateContact(Contact contact)
    {
        var ContactToUpdate = this.GetContact(contact.Id);
        if (ContactToUpdate == null)
            return null;

        ContactToUpdate.ContactFirstName    = contact.ContactFirstName;
        ContactToUpdate.ContactLastName     = contact.ContactLastName;
        ContactToUpdate.ContactCountryCode  = contact.ContactCountryCode;
        ContactToUpdate.ContactPhoneNumber  = contact.ContactPhoneNumber;

        try
        {
            _context.Contacts.Update(ContactToUpdate);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}