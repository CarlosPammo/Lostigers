using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDelegates.Model;
using System.Text.RegularExpressions;

namespace WpfDelegates
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private List<Contact> Contacts { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			Contacts = new List<Contact>
				           {
							   new Contact
								   {
                                        Id = 1,
										Name = "CAMILO",
										Lastname = "BARRON",
										Address = "CALLE AURELIO MELEAN 778",
										Telephone = "72771901"
								   },
								   new Contact
								   {
                                        Id = 2,
										Name = "EDWIN",
										Lastname = "CRESPO",
										Address = "AVENIDA ANICETO ARCE 864",
										Telephone = "60729598"
								   },
                                   new Contact
								   {
                                        Id = 3,
										Name = "BRAYER",
										Lastname = "VILLAGOMEZ",
										Address = "CALLE JUAN DE LA CRUZ 221",
										Telephone = "72464805"
								   },
				           };

			DGContacts.DataContext = Contacts;
			DGContacts.Items.Refresh();
		}

		private void BtnCerrar_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BtnNew_Click(object sender, RoutedEventArgs e)
		{
			EditarContacto editor = new EditarContacto();
			editor.OnAccept += AddNewCoctact;
			editor.Show();
		}

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Contact selected = (Contact)DGContacts.SelectedItem;
            EditarContacto editor = new EditarContacto(selected);
            editor.OnAccept += EditContact;
            editor.Show();
        }

		private void BtnSearch_Click(object sender, RoutedEventArgs e)
		{
            DGContacts.DataContext = Contacts
                // Obtiene todos los contactos cuya propiedad Name 
                // Contenga el texto del texbnox Search
                .Where(c => c.Name.Contains(TbSearch.Text));
            DGContacts.Items.Refresh();
		}

		private void AddNewCoctact(Contact contact)
		{
			Contacts.Add(contact);
			DGContacts.DataContext = Contacts;
			DGContacts.Items.Refresh();
		}

        private void EditContact(Contact contact)
        {
            DGContacts.Items.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Contact selected = (Contact)DGContacts.SelectedItem;
            Contacts.Remove(selected);
            DGContacts.Items.Refresh();
        }
	}
}
