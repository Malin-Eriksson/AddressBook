using AddressBookConsole.Models;
using AddressBookConsole.Services;

namespace AddressBookConsole.Tests
{
    public class AddressBookConsole_Tests
    {
        private Menu addressBook;
        Contact contact;

        public AddressBookConsole_Tests()
        {
            // arrange
            addressBook = new Menu();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            addressBook.contacts.Add(contact);
            addressBook.contacts.Add(contact);

            // assert
            Assert.Equal(2, addressBook.contacts.Count);

        }


        [Fact]
        public void Should_Remove_Contact_From_List()
        {
            // arrange 
            addressBook.contacts.Add(contact);
            addressBook.contacts.Add(contact);

            // act
            addressBook.contacts.Remove(contact);

            // assert
            Assert.Single(addressBook.contacts);
        }
    }
}
