using AddressBookWPF.MVVM.Models;
using AddressBookWPF.MVVM.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using FluentAssertions;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Xunit.Abstractions;


namespace WpfApp.Tests
{
    public class ContactsViewModel_Tests
    {
        private ContactsViewModel viewModel;
        public ContactsViewModel_Tests()
        {
            viewModel = new ContactsViewModel();
        }


        [Fact]
        public void Should_Add_Contact_To_ContactList()
        {
            // act
            ContactModel contact = new ContactModel { FirstName = "Malin", LastName = "Eriksson", Email = "malin.eriksson@domain.com", PhoneNumber = "0701234567", StreetAddress = "Stadsvägen 1", PostalCode = "12345", City = "Örebro" };
            viewModel.Contacts.Add(contact);

            // assert
            viewModel.Contacts.Should().BeOfType<ObservableCollection<ContactModel>>();
            viewModel.Contacts.Should().Contain(contact);
        }
    }
}
